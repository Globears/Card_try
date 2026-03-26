using System.Collections.Generic;

namespace CogCards {
    public class Inclusiveness : CogCard {
        // 2包容
        // 如果你携带了领袖，投机者，朋友，守护者四种书籍各一本进入战斗，则第一回合开始时，你抽取每本书的各一张书页
        public Inclusiveness() : base("PFC03", "Inclusiveness", 3) {
        // 如果你携带了领袖，投机者，朋友，守护者四种书籍各一本进入战斗，则第一回合开始时，你抽取每本书的各一张书页
            Effect InclusivenessEffect = new NextEventEffect<TurnBeginEvent>(() => {
                if(IsInclusiveNessQualified(CardGameManager.currentDeck.books)){
                    Player.Instance.Draw(TAGS.LEADERSHIP);
                    Player.Instance.Draw(TAGS.GUARDIANSHIP);
                    Player.Instance.Draw(TAGS.FRIENDSHIP);
                    Player.Instance.Draw(TAGS.SPECULATOR);
                }
            });
            AddEffect(InclusivenessEffect);
        }

        public bool IsInclusiveNessQualified(List<Book> books) {
            List<MindPhase.Prefix> prefixHas = new List<MindPhase.Prefix>();
            if(books.Count != 4) return false;
            foreach(Book book in books) {
                if(prefixHas.Contains(book.prefix)) return false;
                prefixHas.Add(book.prefix);
            }
            return prefixHas.Count == 4
                && prefixHas.Contains(MindPhase.Prefix.Leadership)
                && prefixHas.Contains(MindPhase.Prefix.Friendship)
                && prefixHas.Contains(MindPhase.Prefix.Guardianship)
                && prefixHas.Contains(MindPhase.Prefix.Speculator);
        }
    }
}
