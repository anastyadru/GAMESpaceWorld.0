// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    
    private float score;
    private float highScore;
    private const string HighScoreKey = "HighScore";

    public void Start()
    {
        highScore = PlayerPrefs.GetFloat(HighScoreKey, 0f);
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                score += enemy.health;
                UpdateUI();
            }
            
            if (score > highscore)
            {
                highScore = score;
                PlayerPrefs.SetFloat(HighScoreKey, highScore);
            }
        }
    }
    
    private void UpdateUI()
    {
        scoreText.text = $"SCORE: {score}";
        highScoreText.text = $"HIGHSCORE: {highScore}";
    }
}