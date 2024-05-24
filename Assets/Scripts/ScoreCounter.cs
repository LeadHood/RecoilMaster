using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] float score;
    TextMeshProUGUI textPrinter;

    private void Start()
    {
        textPrinter = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public float GiveScore()
    { 
    return score;
    }

    public void AddScore(float ScoreToAdd)
    {
        score += ScoreToAdd;
    }

    private void Update()
    {
        textPrinter.text = "Score: " + score;
    }
}
