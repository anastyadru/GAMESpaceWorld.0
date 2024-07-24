// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text HighScoreText;
    
    public float score = 0f;
    public float highscore = 0f;

    public void Start()
    {
        UpdateScoreText();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot"))
        {
            score += 5;
            // score += enemy.health;
            UpdateScoreText();
            
            // if (score > highscore)
            // {
                // highscore = score;
                // PlayerPrefs.SetFloat(highScoreKey, highscore);
                // HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
            // }
        }
    }

    private void UpdateScoreText()
    {
        ScoreText.text = "SCORE: " + score.ToString();
    }
}