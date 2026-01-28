using TMPro;
using UnityEngine;

public class TurnTitleDisplay : MonoBehaviour
{
    public TextMeshProUGUI textMeshProComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProComponent.text = TurnStateMachine.Instance.GetCurrentState().title;
    }
}
