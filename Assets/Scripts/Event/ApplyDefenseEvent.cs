using UnityEngine;

public class ApplyDefenseEvent : Event<ApplyDefenseEvent>{
    public class Pre : Event<Pre>{
        public Node node;
        public Defense defense;
    }

    public class Post : Event<Post> {
        public Node node;
        public Defense defense;
    }
}
