using UnityEngine;

public class Beacon
{
    private static Beacon instance;

    public static Beacon Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Beacon();
                
            }
            return instance;
        }

    }

    private Beacon()
    {
        Node node = GridManager.Instance.GetNodeAt(new Vector2Int(0, 0));
        this.node = node;
    }

    public Node node;

    public void MoveTo(Node node)
    {
        this.node = node;
    }

    public void MoveTo(Vector2Int position)
    {
        Node node = GridManager.Instance.GetNodeAt(position);
        this.node = node;
    }

    public Vector2Int Position
    {
        get
        {
            return node.Position;
        }
    }

    public Node GetCurrentNode()
    {
        return node;
    }
}