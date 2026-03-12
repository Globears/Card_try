using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 负责加载所有书籍数据的静态类
/// </summary>
public static class Books {
    public static Dictionary<string, Book> books = new Dictionary<string, Book>();
    public static Book heartLibSet, basicKnifeHandling;
    public static void Load() {
        heartLibSet = new Book("HeartLibSet");
        heartLibSet.Cards.Add(Cards.spiritOrHeartLib);
        heartLibSet.Cards.Add(Cards.knowledgeOrBook);
        heartLibSet.Cards.Add(Cards.bondOrSupporter);
        heartLibSet.Cards.Add(Cards.changeOrLevel);
        heartLibSet.FinalCards.Add(Cards.futureOrEnding);
        heartLibSet.FinishThreshold = 4;

        basicKnifeHandling = new Book("BasicKnifeHandling");
        basicKnifeHandling.Cards.Add(Cards.slashOrResist);
        basicKnifeHandling.Cards.Add(Cards.sideParryOrSheathe);
        basicKnifeHandling.Cards.Add(Cards.swordHoldingOrArmTraining);
        basicKnifeHandling.Cards.Add(Cards.breathSkillOrDodge);
        basicKnifeHandling.FinalCards.Add(Cards.crossSlashOrArmed);
        basicKnifeHandling.FinishThreshold = 3;

    }
}