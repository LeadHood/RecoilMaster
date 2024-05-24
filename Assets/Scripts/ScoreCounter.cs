using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] int score;
    TextMeshProUGUI textPrinter;

    private void Start()
    {
        textPrinter = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public int GetScore()
    { 
        return score;
    }

    public void AddScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
    }

    private void Update()
    {
        textPrinter.text = "Score: " + score;
    }
}
