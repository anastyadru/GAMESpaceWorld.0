// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    
    [SerializeField] private Text HighScoreText;
    
    public float score = 0f;
    public float highscore = 0f;
    private string highScoreKey = "HighScore";

    public void Start()
    {
        highscore = PlayerPrefs.GetFloat(highScoreKey, 0f);
        UpdateScoreText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("lazerShot") && other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                score += enemy.health;
                UpdateScoreText();
                if (score > highscore)
                {
                    highscore = score;
                    PlayerPrefs.SetFloat(highScoreKey, highscore);
                    HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
                }
            }
        }
    }
    
    private void UpdateScoreText()
    {
        ScoreText.text = "SCORE: " + score.ToString();
    }
}