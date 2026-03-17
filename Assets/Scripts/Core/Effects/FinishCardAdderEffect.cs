

using UnityEngine;

public class FinishCardAdderEffect : EventUntilEventEffect<CardLeaveFromLibEvent, GameEndEvent> {
    
    public static Book book;
    public static int PageNum;
    public static int FinishCardThreshold;

    /// <summary>
    /// 监听书籍封底卡条件并加入手牌的效果
    /// </summary>
    /// <param name="listenBook">监听的书籍</param>
    public FinishCardAdderEffect(Book listenBook) : base(OnCardLeaveFromLib) {
        book = listenBook;
        PageNum = listenBook.ContainCards.Count;
        FinishCardThreshold = listenBook.FinishThreshold;
    }

    static void OnCardLeaveFromLib(CardLeaveFromLibEvent e) {
        if(Library.Instance.CountCardByBook(book.Id) <= (PageNum - FinishCardThreshold)) {
            Debug.Log($"{book.Name} 书的封底牌条件已达成");
            Player.Instance.DrawFinalCard(book);
        }
    }
}