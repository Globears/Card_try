using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 负责加载所有书籍数据的静态类
/// </summary>
public static class Books {
    public static Dictionary<string, Book> books = new Dictionary<string, Book>();
    public static Book heartLibSet, basicKnifeHandling;
    public static void Load() {
        heartLibSet = new Book(01,"HeartLibSet");
        heartLibSet.Cards.Add(Cards.GetPrototypeById("B01C01"));
        heartLibSet.Cards.Add(Cards.GetPrototypeById("B01C02"));
        heartLibSet.Cards.Add(Cards.GetPrototypeById("B01C03"));
        heartLibSet.Cards.Add(Cards.GetPrototypeById("B01C04"));
        heartLibSet.FinalCards.Add(Cards.GetPrototypeById("B01C05"));
        heartLibSet.FinishThreshold = 4;

        basicKnifeHandling = new Book(02,"BasicKnifeHandling");
        basicKnifeHandling.Cards.Add(Cards.GetPrototypeById("B02C01"));
        basicKnifeHandling.Cards.Add(Cards.GetPrototypeById("B02C02"));
        basicKnifeHandling.Cards.Add(Cards.GetPrototypeById("B02C03"));
        basicKnifeHandling.Cards.Add(Cards.GetPrototypeById("B02C04"));
        basicKnifeHandling.FinalCards.Add(Cards.GetPrototypeById("B02C05"));
        basicKnifeHandling.FinishThreshold = 3;

    }
}