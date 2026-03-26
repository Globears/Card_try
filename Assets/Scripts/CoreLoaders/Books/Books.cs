using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 负责加载所有书籍数据的静态类
/// </summary>
public static class Books {
    public static MultiKeyDictionary<int, string, Book> books = new MultiKeyDictionary<int ,string, Book>();
    public static Book heartLibSet, basicKnifeHandling;
    public static void Load() {
        heartLibSet = new Book(01,"HeartLibSet",4,MindPhase.Prefix.Leadership,"B01C01","B01C02","B01C03","B01C04");
        heartLibSet.AddFinalCard("B01C05");
        books.Add(01,"HeartLibSet",heartLibSet);

        basicKnifeHandling = new Book(02,"BasicKnifeHandling",3,MindPhase.Prefix.Leadership,"B02C01","B02C02","B02C03","B02C04");
        basicKnifeHandling.AddFinalCard("B02C05");
        books.Add(02,"BasicKnifeHandling",basicKnifeHandling);
        
    }
}