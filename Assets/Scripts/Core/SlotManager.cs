using System.Collections.Generic;
using UnityEngine;

public class SlotManager
{
    private static SlotManager instance;

    public static SlotManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new SlotManager();
                
            }
            return instance;
        }

    }

    private SlotManager()
    {
        for(int i = 0 ; i < 6 ; i++)
        {
            actionSlots.Add(new Slot());
            bonusActionSlots.Add(new Slot());
        }
    }


    private List<Slot> actionSlots = new List<Slot>();

    private List<Slot> bonusActionSlots = new List<Slot>();

    public List<Slot> ActionSlots => actionSlots;
    public List<Slot> BonusActionSlots => bonusActionSlots;

    public Slot GetActionSlot(int index)
    {
        return actionSlots[index];
    }

    public Slot GetBonusActionSlot(int index)
    {
        return bonusActionSlots[index];
    }

    public List<Slot> GetAllActionSlots()
    {
        return actionSlots;
    }

    public List<Slot> GetAllBonusActionSlots()
    {
        return bonusActionSlots;
    }

}
