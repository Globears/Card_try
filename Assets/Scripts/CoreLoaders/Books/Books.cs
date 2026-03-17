using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 负责加载所有书籍数据的静态类
/// </summary>
public static class Books {
    public static MultiKeyDictionary<int, string, Book> books = new MultiKeyDictionary<int ,string, Book>();
    public static Book heartLibSet, basicKnifeHandling;
    public static void Load() {
        heartLibSet = new Book(01,"HeartLibSet");
        heartLibSet.Cards.Add(Cards.GetPrototypeById("B01C01"));
        heartLibSet.Cards.Add(Cards.GetPrototypeById("B01C02"));
        heartLibSet.Cards.Add(Cards.GetPrototypeById("B01C03"));
        heartLibSet.Cards.Add(Cards.GetPrototypeById("B01C04"));
        heartLibSet.FinalCards.Add(Cards.GetPrototypeById("B01C05"));
        heartLibSet.FinishThreshold = 4;
        books.Add(01,"HeartLibSet",heartLibSet);

        basicKnifeHandling = new Book(02,"BasicKnifeHandling");
        basicKnifeHandling.Cards.Add(Cards.GetPrototypeById("B02C01"));
        basicKnifeHandling.Cards.Add(Cards.GetPrototypeById("B02C02"));
        basicKnifeHandling.Cards.Add(Cards.GetPrototypeById("B02C03"));
        basicKnifeHandling.Cards.Add(Cards.GetPrototypeById("B02C04"));
        basicKnifeHandling.FinalCards.Add(Cards.GetPrototypeById("B02C05"));
        basicKnifeHandling.FinishThreshold = 3;
        books.Add(02,"BasicKnifeHandling",basicKnifeHandling);
        
    }
}