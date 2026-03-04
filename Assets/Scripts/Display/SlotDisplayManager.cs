using System.Collections.Generic;
using UnityEngine;

public class SlotDisplayManager : SingletonBehaviour<SlotDisplayManager>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<SlotDisplay> actionSlots = new List<SlotDisplay>();
    public List<SlotDisplay> bonusActionSlots = new List<SlotDisplay>();

    void Start()
    {
        //将槽位与它的Object绑定
        for(int i = 0; i < actionSlots.Count; i++)
        {
            actionSlots[i].slot = SlotManager.Instance.ActionSlots[i];
        }
        for(int i = 0; i < bonusActionSlots.Count; i++)
        {
            bonusActionSlots[i].slot = SlotManager.Instance.BonusActionSlots[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
