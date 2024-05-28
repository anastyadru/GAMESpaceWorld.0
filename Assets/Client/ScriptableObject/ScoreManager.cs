// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text HighScoreText;
    
    [SerializeField] private Text ScoreText;

    public float score;
    public float highscore;
    private string highScoreKey = "HighScore";

    public void Start()
    {
        score = 0;
        StartCoroutine(UpdateScore());
    }
    
    public void Update()
    {
        HighScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("score").ToString();
    }

    IEnumerator UpdateScore()
    {
        if (other.CompareTag("lazerShot"))
        {
            if (other.GetComponent<Collider>().gameObject.CompareTag("Enemy"))
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
    }
    
    private void UpdateScoreText()
    {
        ScoreText.text = "SCORE: " + score.ToString();
    }
}