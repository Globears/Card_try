using System;
using System.Collections.Generic;
using UnityEngine;

public class Book
{
    public String Id;

    public List<Card> Cards = new List<Card>();

    public List<Card> FinalCards = new List<Card>();

    public int FinishThreshold = 0;

    //检测是否完书，以及完书时的效果函数
}

public class BookData
{
    
}
