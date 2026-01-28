using UnityEngine;

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
