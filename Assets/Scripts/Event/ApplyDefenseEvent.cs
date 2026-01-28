using UnityEngine;

public class ApplyDefenseEvent : Event<ApplyDefenseEvent>
{
    public Node node;
    public Defense defense;
}
