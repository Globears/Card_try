using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatState : TurnState
{
    public CombatState()
    {
        title = "Combat State";
    }

    public override void Enter()
    {
        Debug.Log("进入战斗阶段");
        Combat();
    }

    public override void Exit()
    {
        
    }

    public override TurnState NextState()
    {
        DiscardState discardState = new DiscardState();
        return discardState;
    }

    public override void Update() {
        
    }

    public void Combat() {
        CombatStartEvent.Publish(new CombatStartEvent());
        //获取所有敌人
        List<Enemy> enemies = EnemyManager.Instance.GetEnemies();
        //从第0波次开始
        List<Card> allSlotCards = SlotManager.Instance.GetAllCardInSlots();
        //战斗核心流程，最多6波
        for(int rounds = 0; rounds < enemies.Count; rounds++) {
            //对于每个敌人的波次，先结算卡牌效果，再结算卡牌的防御，再令敌人攻击
            RoundStartEvent.Publish(new RoundStartEvent{roundNum = rounds});
            //获取该轮次对应的Slot上的卡牌
            Slot actionSlot = SlotManager.Instance.GetActionSlot(rounds);
            Slot bonusActionSlot = SlotManager.Instance.GetBonusActionSlot(rounds);
            Card actionCard = actionSlot.GetCard();
            Card bonusActionCard = bonusActionSlot.GetCard();

            //结算卡牌效果
            if(actionCard != null) {
                Debug.Log("主要行动卡牌："+actionCard.Name);
                CardResolveEvent.Pre.Publish(new CardResolveEvent.Pre{card = actionCard,index = rounds*2});
                actionCard?.ResolveActionEffects();
                CardResolveEvent.Post.Publish(new CardResolveEvent.Post{card = actionCard,index = rounds*2});
                Logger.historyActs.Add(actionCard.action);
                Logger.historyCards.Add(actionCard);
            } else { Debug.Log("无主要行动卡牌！"); }
            //结算额外卡牌效果
            if(bonusActionCard != null) {
                Debug.Log("附赠行动卡牌："+bonusActionCard.Name);
                CardResolveEvent.Pre.Publish(new CardResolveEvent.Pre{card = bonusActionCard,index = rounds*2+1});
                bonusActionCard?.ResolveBonusActionEffects();
                CardResolveEvent.Post.Publish(new CardResolveEvent.Post{card = bonusActionCard,index = rounds*2+1});
                Logger.historyCards.Add(bonusActionCard);
            } else { Debug.Log("无附赠行动卡牌！"); }

            //结算卡牌防御
            if(actionCard != null) {
                //ApplyDefenseEvent.pre和.post在Act内实现
                actionCard?.ResolveActionDefence();

                ActResolveEvent.Publish(new ActResolveEvent{act = actionCard.action});
            }
            bonusActionCard?.ResolveBonusActionDefence();

            //令该轮次的敌人攻击
            //int elapsedRounds = 0;

            enemies[rounds].Attack(rounds);

            // foreach(Enemy enemy in enemies)
            // {
            //     if(elapsedRounds + enemy.GetRounds() > rounds)
            //     {
            //         enemy.Attack(rounds - elapsedRounds);
            //     }
            //     else
            //     {
            //         elapsedRounds += enemy.GetRounds();
            //     }
            // }

            RoundEndEvent.Publish(new RoundEndEvent
            {roundNum = rounds,ActionCard = actionCard,BonusActionCard = bonusActionCard});
            
            //清除节点上的所有防御，为下一轮做准备
            foreach(Node node in GridManager.Instance.Nodes) {
                node.ClearDefense();
            }

        }
    }
}
