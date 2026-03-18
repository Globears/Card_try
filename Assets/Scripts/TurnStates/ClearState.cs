using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearState : TurnState
{

    public ClearState()
    {
        //该阶段负责：清除所有槽位里的卡牌，把它们弃掉。清除所有的敌人，清除所有的设防
        title = "Clear State";
    }

    public override void Enter() {
        Clear();
    }

    public override void Exit()
    {
        
    }

    public override TurnState NextState()
    {
        DrawState drawState = new DrawState();
        return drawState;
    }

    public override void Update() {
        
    }

    public void Clear() {
        
        //1.清除所有槽位里的卡牌，把它们置入坟墓
        List<Slot> actionSlots = SlotManager.Instance.GetAllActionSlots();
        foreach(Slot slot in actionSlots)
        {
            Card card = slot.GetCard();
            slot.Clear();
            Graveyard.Instance.Add(card);
        }

        List<Slot> bonusActionSlots = SlotManager.Instance.GetAllBonusActionSlots();
        foreach(Slot slot in bonusActionSlots)
        {
            Card card = slot.GetCard();
            slot.Clear();
            Graveyard.Instance.Add(card);
        }

        //2.清除所有敌人
        // List<Enemy> enemies = EnemyManager.Instance.GetEnemies();
        // foreach(Enemy enemy in enemies)
        // {
        //     EnemyManager.Instance.Remove(enemy);
        // }
        EnemyManager.Instance.ClearEnemies();

        //3.清除所有的设防
        List<Node> nodes = GridManager.Instance.Nodes;
        foreach(Node node in nodes)
        {
            node.ClearDefense();
        }

        TurnEndEvent.Publish(new TurnEndEvent());
    }
}
