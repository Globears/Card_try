using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyInfoDisplay : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        List<Enemy> enemies = EnemyManager.Instance.GetEnemies();
        string displayText = "";
        foreach (Enemy enemy in enemies){
            string atkSesDisplay = "";
            foreach (string atk in enemy.attackSequences) {
                atkSesDisplay += atk;
            }
            displayText += $"Name:{enemy.name} Atk:{atkSesDisplay}\n";
        }
        text.text = displayText;
    }
}
