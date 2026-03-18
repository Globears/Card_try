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
        foreach (Enemy enemy in enemies)
        {
            displayText += $"Name: {enemy.Id}, Danger Level: {enemy.dangerLevel}, Rounds: {enemy.GetRounds()}\n";
        }
        text.text = displayText;
    }
}
