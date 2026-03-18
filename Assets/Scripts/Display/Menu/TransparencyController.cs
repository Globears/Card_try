using UnityEngine;
using UnityEngine.UI;

public class TransparencyController : MonoBehaviour
{
    [Header("透明度设置")]
    [SerializeField] private float minAlpha = 0.35f;
    [SerializeField] private float maxAlpha = 0.45f;
    
    [Header("闪烁速度设置")]
    [SerializeField] private float flickerSpeed = 0.2f; // 变化间隔时间
    [SerializeField] private bool useSmoothTransition = true; // 是否平滑过渡
    
    private Image imageComponent;
    private float timer;
    private float targetAlpha;
    private float currentAlpha;
    
    void Start()
    {
        // 获取Image组件
        imageComponent = GetComponent<Image>();
        if (imageComponent == null)
        {
            Debug.LogError("未找到Image组件！");
            enabled = false;
            return;
        }
        
        // 初始化
        currentAlpha = imageComponent.color.a;
        SetNewTargetAlpha();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (useSmoothTransition)
        {
            // 平滑过渡到目标透明度
            if (timer >= flickerSpeed)
            {
                // 到达目标后立即设置新的目标
                SetNewTargetAlpha();
                timer = 0f;
            }
            
            // 使用Lerp进行平滑过渡
            float t = timer / flickerSpeed;
            currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, t);
        }
        else
        {
            // 直接跳变
            if (timer >= flickerSpeed)
            {
                SetNewTargetAlpha();
                currentAlpha = targetAlpha;
                timer = 0f;
            }
        }
        
        // 应用透明度
        ApplyAlpha(currentAlpha);
    }
    
    void SetNewTargetAlpha()
    {
        targetAlpha = Random.Range(minAlpha, maxAlpha);
    }
    
    void ApplyAlpha(float alpha)
    {
        Color color = imageComponent.color;
        color.a = alpha;
        imageComponent.color = color;
    }
    
    // 公共方法：设置透明度范围
    public void SetAlphaRange(float newMin, float newMax)
    {
        minAlpha = Mathf.Clamp01(newMin);
        maxAlpha = Mathf.Clamp01(newMax);
    }
    
    // 公共方法：设置闪烁速度
    public void SetFlickerSpeed(float speed)
    {
        flickerSpeed = Mathf.Max(0.01f, speed);
    }
}