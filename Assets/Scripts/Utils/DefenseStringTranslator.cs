using System.Collections.Generic;

public static class DefenseStringTranslator{
    public static string DefenseSequencesToString(List<DefenseSequence> defenseSequences) {
        string result = "";
        foreach (DefenseSequence defenseSequence in defenseSequences) {
            result += DefenseSequenceToString(defenseSequence);
        }
        return result;
    }
    
    public static string DefenseSequenceToString(DefenseSequence defenseSequence) {
        string result = "";
        foreach(Defense defense in defenseSequence.Sequence) {
            result += defense.Power;
            result += defense.Position;
            result += " ";
        }
        return result;
    }

    public static string ListDefenseToString(List<Defense> defenses) {
        string result = "";
        foreach(Defense defense in defenses) {
            result += defense.Power;
            result += defense.Position;
            result += " ";
        }
        return result;
    }
}