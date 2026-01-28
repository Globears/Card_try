using System.Collections.Generic;
using UnityEngine;

public class GridLayoutManager : MonoBehaviour
{
    private static GridLayoutManager instance;  

    public static GridLayoutManager Instance
    {
        get
        {

            return instance;
        }

    }



    public List<NodeDisplay> nodeDisplays = new List<NodeDisplay>();

    private float width = 16, height = 8;

    private Vector2 position;

    [SerializeField]
    private NodeDisplay nodeDisplayPrefab;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //为每个Node生成NodeDisplay并绑定
        foreach(NodeDisplay nodeDisplay in nodeDisplays)
        {
            nodeDisplay.Bind(GridManager.Instance.GetNodeAt(nodeDisplay.nodePosition));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public NodeDisplay GetNodeDisplay(Node node)
    {
        foreach (NodeDisplay nodeDisplay in nodeDisplays)
        {
            if (nodeDisplay.node == node)
            {
                return nodeDisplay;
            }
        }
        return null;
    }
}
