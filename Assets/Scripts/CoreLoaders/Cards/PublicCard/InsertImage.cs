using UnityEngine;

public class InsertImage : Card
{
// 插图 只有行动
// 1：信标当前位置，下一张卡牌的起始位置
// 如果没有下一张卡牌则为5
    public Effect instantEffect;
    public InsertImage()
    : base("B00C01","insert_image",MindPhase.Prefix.NOMINDPHASE,MindPhase.Suffix.NOMINDPHASE) {
        instantEffect = new Instant(() => {
            Debug.Log("1：信标当前位置，下一张卡牌的起始位置 如果没有下一张卡牌则为5");
            //TODO
        });
        action.AddEffect(instantEffect);
    }
}
