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
    // private string highScoreKey = "HighScore";

    public void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot"))
        {
            score += 3;
            UpdateScoreText();
        }
    }
    
    private void UpdateScoreText()
    {
        ScoreText.text = "SCORE: " + score.ToString();
    }
}