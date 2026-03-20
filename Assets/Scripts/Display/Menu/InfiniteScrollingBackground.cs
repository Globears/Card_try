using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfiniteScrollingBackground : MonoBehaviour
{
    [Header("背景设置")]
    [SerializeField] private Image[] backgroundImages; // 3个背景图片
    [SerializeField] private float scrollSpeed = 1f; // 滚动速度
    [SerializeField] private bool scrollRight = false; // 滚动方向，false为向左，true为向右
    
    [Header("边界设置")]
    [SerializeField] private float imageWidth = 0f; // 图片宽度，如果为0则自动获取
    
    [Header("停顿效果设置")]
    [SerializeField] private bool enablePause = true; // 是否启用停顿效果
    [SerializeField] private float pauseInterval = 5f; // 停顿间隔时间（秒）
    [SerializeField] private bool useRandomPauseInterval = false; // 是否使用随机停顿间隔
    [SerializeField] private float minPauseInterval = 3f; // 随机停顿最小间隔
    [SerializeField] private float maxPauseInterval = 7f; // 随机停顿最大间隔
    
    [SerializeField] private float pauseDuration = 2f; // 停顿持续时间（秒）
    [SerializeField] private bool useRandomPauseDuration = false; // 是否使用随机停顿持续时间
    [SerializeField] private float minPauseDuration = 1f; // 随机停顿最小持续时间
    [SerializeField] private float maxPauseDuration = 3f; // 随机停顿最大持续时间
    
    [SerializeField] private AnimationCurve pauseCurve = null; // 停顿曲线（缓停）
    [SerializeField] private float speedRecoveryDuration = 1f; // 速度恢复持续时间（秒）
    [SerializeField] private AnimationCurve recoveryCurve = null; // 速度恢复曲线
    
    [Header("停止速度设置（缓停最终速度）")]
    [SerializeField] private bool useRandomStopSpeed = false; // 是否使用随机停止速度
    [SerializeField] private float minStopSpeed = 0f; // 最小停止速度乘数（0=完全停止，0.2=保留20%速度）
    [SerializeField] private float maxStopSpeed = 0f; // 最大停止速度乘数
    
    [Header("上下浮动效果设置")]
    [SerializeField] private bool enableVerticalFloat = true; // 是否启用上下浮动
    [SerializeField] private float floatInterval = 3f; // 浮动间隔时间（秒）
    [SerializeField] private bool useRandomFloatInterval = false; // 是否使用随机浮动间隔
    [SerializeField] private float minFloatInterval = 2f; // 随机浮动最小间隔
    [SerializeField] private float maxFloatInterval = 5f; // 随机浮动最大间隔
    [SerializeField] private float floatUpDuration = 1f; // 上升持续时间（秒）
    [SerializeField] private float floatUpDistance = 30f; // 上升距离（像素）
    [SerializeField] private AnimationCurve floatUpCurve = null; // 上升曲线
    [SerializeField] private float holdTimeAtTop = 0.5f; // 在顶部停留时间（秒）
    [SerializeField] private float floatDownDuration = 1f; // 下降持续时间（秒）
    [SerializeField] private AnimationCurve floatDownCurve = null; // 下降曲线
    
    private RectTransform[] rectTransforms;
    private float singleWidth; // 单个图片宽度
    private int imageCount;
    
    // 停顿相关变量
    private bool isPausing = false;
    private float currentSpeedMultiplier = 1f;
    private float currentStopSpeed = 0f; // 记录本次停顿最终速度
    private Coroutine pauseCoroutine;
    
    // 浮动相关变量
    private bool isFloating = false;
    private float[] originalYPositions; // 存储每个图片的原始Y坐标
    private Coroutine floatCoroutine;
    
    void Awake()
    {
        // 初始化默认曲线（如果未在Inspector中设置）
        if (pauseCurve == null || pauseCurve.keys.Length == 0)
        {
            pauseCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
        }
        
        if (recoveryCurve == null || recoveryCurve.keys.Length == 0)
        {
            recoveryCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        }
        
        if (floatUpCurve == null || floatUpCurve.keys.Length == 0)
        {
            floatUpCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        }
        
        if (floatDownCurve == null || floatDownCurve.keys.Length == 0)
        {
            floatDownCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
        }
        
        // 确保随机范围有效
        if (minStopSpeed > maxStopSpeed)
        {
            float temp = minStopSpeed;
            minStopSpeed = maxStopSpeed;
            maxStopSpeed = temp;
        }
    }
    
    void Start()
    {
        imageCount = backgroundImages.Length;
        rectTransforms = new RectTransform[imageCount];
        originalYPositions = new float[imageCount];
        
        // 获取所有背景的RectTransform组件
        for (int i = 0; i < imageCount; i++)
        {
            if (backgroundImages[i] != null)
            {
                rectTransforms[i] = backgroundImages[i].GetComponent<RectTransform>();
                originalYPositions[i] = rectTransforms[i].anchoredPosition.y;
            }
        }
        
        // 获取图片宽度
        if (imageWidth <= 0)
        {
            if (rectTransforms[0] != null)
            {
                singleWidth = rectTransforms[0].rect.width;
            }
            else
            {
                Debug.LogError("无法获取图片宽度，请手动设置 imageWidth 值！");
                return;
            }
        }
        else
        {
            singleWidth = imageWidth;
        }
        
        // 初始化背景位置
        ArrangeBackgrounds();
        
        // 启动协程
        if (enablePause)
        {
            StartPauseCycle();
        }
        
        if (enableVerticalFloat)
        {
            StartFloatCycle();
        }
    }
    
    void Update()
    {
        // 计算移动距离（应用速度乘数）
        float moveDistance = scrollSpeed * currentSpeedMultiplier * Time.deltaTime;
        if (!scrollRight)
        {
            moveDistance = -moveDistance;
        }
        
        // 移动所有背景
        for (int i = 0; i < imageCount; i++)
        {
            if (backgroundImages[i] == null) continue;
            
            Vector3 newPosition = rectTransforms[i].anchoredPosition;
            newPosition.x += moveDistance;
            rectTransforms[i].anchoredPosition = newPosition;
        }
        
        // 检查并重置位置
        CheckAndReposition();
    }
    
    void CheckAndReposition()
    {
        for (int i = 0; i < imageCount; i++)
        {
            if (backgroundImages[i] == null) continue;
            
            float currentX = rectTransforms[i].anchoredPosition.x;
            
            if (scrollRight)
            {
                // 向右滚动：当图片完全移出右侧时，移动到最左边
                if (currentX >= singleWidth)
                {
                    // 找到最左边的图片位置
                    float leftmostX = GetLeftmostPosition();
                    // 将当前图片放到最左边
                    float newX = leftmostX - singleWidth;
                    rectTransforms[i].anchoredPosition = new Vector3(newX, rectTransforms[i].anchoredPosition.y, 0);
                }
            }
            else
            {
                // 向左滚动：当图片完全移出左侧时，移动到最右边
                if (currentX <= -singleWidth)
                {
                    // 找到最右边的图片位置
                    float rightmostX = GetRightmostPosition();
                    // 将当前图片放到最右边
                    float newX = rightmostX + singleWidth;
                    rectTransforms[i].anchoredPosition = new Vector3(newX, rectTransforms[i].anchoredPosition.y, 0);
                }
            }
        }
    }
    
    // 获取最左边图片的X坐标
    float GetLeftmostPosition()
    {
        float leftmost = float.MaxValue;
        for (int i = 0; i < imageCount; i++)
        {
            if (backgroundImages[i] != null)
            {
                float x = rectTransforms[i].anchoredPosition.x;
                if (x < leftmost)
                {
                    leftmost = x;
                }
            }
        }
        return leftmost;
    }
    
    // 获取最右边图片的X坐标
    float GetRightmostPosition()
    {
        float rightmost = float.MinValue;
        for (int i = 0; i < imageCount; i++)
        {
            if (backgroundImages[i] != null)
            {
                float x = rectTransforms[i].anchoredPosition.x;
                if (x > rightmost)
                {
                    rightmost = x;
                }
            }
        }
        return rightmost;
    }
    
    void ArrangeBackgrounds()
    {
        // 自动排列背景图片，确保无缝衔接
        for (int i = 0; i < imageCount; i++)
        {
            if (backgroundImages[i] == null) continue;
            
            float xPos = i * singleWidth;
            rectTransforms[i].anchoredPosition = new Vector3(xPos, originalYPositions[i], 0);
        }
    }
    
    // 启动停顿循环
    void StartPauseCycle()
    {
        if (pauseCoroutine != null)
        {
            StopCoroutine(pauseCoroutine);
        }
        pauseCoroutine = StartCoroutine(PauseCycle());
    }
    
    // 停顿循环协程
    IEnumerator PauseCycle()
    {
        while (true)
        {
            // 计算本次停顿间隔（支持随机）
            float waitTime = useRandomPauseInterval ? Random.Range(minPauseInterval, maxPauseInterval) : pauseInterval;
            yield return new WaitForSeconds(waitTime);
            
            // 开始缓停效果（传入本次停止速度）
            float targetStopSpeed = useRandomStopSpeed ? Random.Range(minStopSpeed, maxStopSpeed) : minStopSpeed; // 如果未启用随机，则使用minStopSpeed作为固定值（兼容旧行为）
            // 如果未启用随机且 minStopSpeed 和 maxStopSpeed 都为0，则 targetStopSpeed 为0（完全停止）
            yield return StartCoroutine(SlowDownToStop(targetStopSpeed));
            
            // 计算本次停顿持续时间（支持随机）
            float actualPauseDuration = useRandomPauseDuration ? Random.Range(minPauseDuration, maxPauseDuration) : pauseDuration;
            yield return new WaitForSeconds(actualPauseDuration);
            
            // 逐渐恢复速度（从当前停止速度恢复到1）
            yield return StartCoroutine(RecoverSpeed(targetStopSpeed));
        }
    }
    
    // 缓停效果（减速到指定目标速度）
    IEnumerator SlowDownToStop(float targetSpeed)
    {
        isPausing = true;
        float elapsedTime = 0f;
        float startMultiplier = currentSpeedMultiplier;
        
        while (elapsedTime < speedRecoveryDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / speedRecoveryDuration;
            // 使用停顿曲线控制速度变化
            float curveValue = pauseCurve.Evaluate(t);
            currentSpeedMultiplier = Mathf.Lerp(startMultiplier, targetSpeed, curveValue);
            yield return null;
        }
        
        currentSpeedMultiplier = targetSpeed;
        currentStopSpeed = targetSpeed;
    }
    
    // 恢复速度（从指定起始速度恢复到1）
    IEnumerator RecoverSpeed(float startSpeed)
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < speedRecoveryDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / speedRecoveryDuration;
            // 使用恢复曲线控制速度变化
            float curveValue = recoveryCurve.Evaluate(t);
            currentSpeedMultiplier = Mathf.Lerp(startSpeed, 1f, curveValue);
            yield return null;
        }
        
        currentSpeedMultiplier = 1f;
        isPausing = false;
    }
    
    // 启动浮动循环
    void StartFloatCycle()
    {
        if (floatCoroutine != null)
        {
            StopCoroutine(floatCoroutine);
        }
        floatCoroutine = StartCoroutine(FloatCycle());
    }
    
    // 浮动循环协程
    IEnumerator FloatCycle()
    {
        while (true)
        {
            // 计算本次浮动间隔（支持随机）
            float waitTime = useRandomFloatInterval ? Random.Range(minFloatInterval, maxFloatInterval) : floatInterval;
            yield return new WaitForSeconds(waitTime);
            
            // 开始浮动效果
            yield return StartCoroutine(ApplyFloatEffect());
        }
    }
    
    // 应用浮动效果（上升 -> 停留 -> 下降）
    IEnumerator ApplyFloatEffect()
    {
        isFloating = true;
        
        // 1. 上升阶段
        float elapsedTime = 0f;
        while (elapsedTime < floatUpDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / floatUpDuration;
            float curveValue = floatUpCurve.Evaluate(t);
            float currentYOffset = Mathf.Lerp(0f, floatUpDistance, curveValue);
            
            // 对所有图片应用Y轴偏移
            for (int i = 0; i < imageCount; i++)
            {
                if (backgroundImages[i] != null && rectTransforms[i] != null)
                {
                    Vector3 newPosition = rectTransforms[i].anchoredPosition;
                    newPosition.y = originalYPositions[i] + currentYOffset;
                    rectTransforms[i].anchoredPosition = newPosition;
                }
            }
            
            yield return null;
        }
        
        // 确保到达最高点
        for (int i = 0; i < imageCount; i++)
        {
            if (backgroundImages[i] != null && rectTransforms[i] != null)
            {
                Vector3 newPosition = rectTransforms[i].anchoredPosition;
                newPosition.y = originalYPositions[i] + floatUpDistance;
                rectTransforms[i].anchoredPosition = newPosition;
            }
        }
        
        // 2. 在顶部停留
        yield return new WaitForSeconds(holdTimeAtTop);
        
        // 3. 下降阶段
        elapsedTime = 0f;
        while (elapsedTime < floatDownDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / floatDownDuration;
            float curveValue = floatDownCurve.Evaluate(t);
            float currentYOffset = Mathf.Lerp(floatUpDistance, 0f, curveValue);
            
            // 对所有图片应用Y轴偏移
            for (int i = 0; i < imageCount; i++)
            {
                if (backgroundImages[i] != null && rectTransforms[i] != null)
                {
                    Vector3 newPosition = rectTransforms[i].anchoredPosition;
                    newPosition.y = originalYPositions[i] + currentYOffset;
                    rectTransforms[i].anchoredPosition = newPosition;
                }
            }
            
            yield return null;
        }
        
        // 确保回到原始位置
        for (int i = 0; i < imageCount; i++)
        {
            if (backgroundImages[i] != null && rectTransforms[i] != null)
            {
                Vector3 newPosition = rectTransforms[i].anchoredPosition;
                newPosition.y = originalYPositions[i];
                rectTransforms[i].anchoredPosition = newPosition;
            }
        }
        
        isFloating = false;
    }
    
    // 公共方法：设置滚动速度
    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
    
    // 公共方法：获取当前速度
    public float GetScrollSpeed()
    {
        return scrollSpeed * currentSpeedMultiplier;
    }
    
    // 公共方法：切换滚动方向
    public void ToggleDirection()
    {
        scrollRight = !scrollRight;
    }
    
    // 公共方法：重置背景位置
    public void ResetPositions()
    {
        ArrangeBackgrounds();
        // 重置Y坐标存储
        for (int i = 0; i < imageCount; i++)
        {
            if (rectTransforms[i] != null)
            {
                originalYPositions[i] = rectTransforms[i].anchoredPosition.y;
            }
        }
    }
    
    // 公共方法：手动触发停顿
    public void TriggerPause()
    {
        if (enablePause && pauseCoroutine != null)
        {
            StopCoroutine(pauseCoroutine);
            pauseCoroutine = StartCoroutine(PauseCycle());
        }
    }
    
    // 公共方法：手动触发浮动
    public void TriggerFloat()
    {
        if (enableVerticalFloat && !isFloating)
        {
            if (floatCoroutine != null)
            {
                StopCoroutine(floatCoroutine);
            }
            floatCoroutine = StartCoroutine(ApplyFloatEffect());
            // 重新启动循环
            StartFloatCycle();
        }
    }
    
    // 公共方法：设置浮动间隔
    public void SetFloatInterval(float interval)
    {
        floatInterval = interval;
        if (enableVerticalFloat)
        {
            StartFloatCycle();
        }
    }
    
    // 公共方法：设置上升距离
    public void SetFloatUpDistance(float distance)
    {
        floatUpDistance = distance;
    }
    
    // 编辑器下调试用，显示图片边界
    void OnDrawGizmosSelected()
    {
        if (rectTransforms != null && rectTransforms.Length > 0)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < rectTransforms.Length; i++)
            {
                if (rectTransforms[i] != null)
                {
                    Vector3 worldPos = rectTransforms[i].TransformPoint(Vector3.zero);
                    Gizmos.DrawWireCube(worldPos, new Vector3(singleWidth, rectTransforms[i].rect.height, 0));
                }
            }
        }
    }
}