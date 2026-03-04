using UnityEngine;

/// <summary>
/// 操控信标的显示的物体的脚本
/// </summary>
public class BeaconDisplay : MonoBehaviour
{
    public Beacon beacon;

    void Start()
    {
        beacon = Beacon.Instance;
    }

    void Update()
    {
        Node node = Beacon.Instance.GetCurrentNode();
        NodeDisplay nodeDisplay = GridLayoutManager.Instance.GetNodeDisplay(node);
        transform.position = nodeDisplay.transform.position;
    }

}
