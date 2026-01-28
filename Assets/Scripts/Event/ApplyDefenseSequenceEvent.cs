using UnityEngine;

public class ApplyDefenseSequenceEvent : Event<ApplyDefenseSequenceEvent>
{
    public DefenseSequence DefenseSequence;
    public Card card;
}
