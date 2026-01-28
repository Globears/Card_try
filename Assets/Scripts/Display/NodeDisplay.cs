using TMPro;
using UnityEngine;

public class NodeDisplay : MonoBehaviour
{
    public Node node;

    public Vector2Int nodePosition;

    public TextMeshPro text;
    public void Bind(Node node)
    {
        this.node = node;
        nodePosition = node.Position;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if(node == null)
        {
            return;
        }

        text.text = "";

        //展示节点的受伤、心相状态
        text.text += "被毁：" + node.damage.ToString();

        //节点的心相是字典
        text.text += "\n" + "坚定：" + node.MindPhases[MindPhase.Suffix.Firmness].ToString();
        text.text += "\n" + "自信：" + node.MindPhases[MindPhase.Suffix.Confidence].ToString();
        text.text += "\n" + "温柔：" + node.MindPhases[MindPhase.Suffix.Tenderness].ToString();
        text.text += "\n" + "责任：" + node.MindPhases[MindPhase.Suffix.Responsibility].ToString();
        

    }

    void OnMouseExit()
    {
        text.text = null;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
