using System.Collections.Generic;
using UnityEngine;

public class CombatState : TurnState
{
    public CombatState()
    {
        title = "Combat State";
    }

    public override void Enter()
    {
        Debug.Log("Enterting Combat State");
        Update();
    }

    public override void Exit()
    {
        
    }

    public override TurnState NextState()
    {
        DiscardState discardState = new DiscardState();
        return discardState;
    }

    public override void Update()
    {

        //获取所有敌人
        List<Enemy> enemies = EnemyManager.Instance.GetEnemies();

        //从第0波次开始
        int rounds = 0;
        //战斗核心流程，最多6波
        for(rounds = 0; rounds < 3; rounds++)
        {
            //对于每个敌人的波次，先结算卡牌效果，再令敌人攻击

            //1.获取该轮次对应的Slot上的卡牌，并结算它的效果
            Slot actionSlot = SlotManager.Instance.GetActionSlot(rounds);
            Slot bonusActionSlot = SlotManager.Instance.GetBonusActionSlot(rounds);
            Card actionCard = actionSlot.GetCard();
            Card bonusActionCard = bonusActionSlot.GetCard();
            actionCard?.ResolveAction();
            bonusActionCard?.ResolveBonusAction();

            //2.令该轮次的敌人攻击
            int elapsedRounds = 0;
            foreach(Enemy enemy in enemies)
            {
                if(elapsedRounds + enemy.GetRounds() > rounds)
                {
                    enemy.Attack(rounds - elapsedRounds);
                }
                else
                {
                    elapsedRounds += enemy.GetRounds();
                }
            }

            //3.清除节点上的所有防御，为下一轮做准备
            foreach(Node node in GridManager.Instance.Nodes)
            {
                node.ClearDefense();
            }

        }
    }
}
