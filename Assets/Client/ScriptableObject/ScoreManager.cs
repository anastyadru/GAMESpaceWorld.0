// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text HighScoreText;
    
    public float score = 0f;
    public float highscore = 0f;
    
    private static ScoreManager instance;
    
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<ScoreManager>();
                    singletonObject.name = typeof(ScoreManager).ToString() + " (Singleton)";
                }
            }
            return instance;
        }
    }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        UpdateScoreText();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot"))
        {
            AddScore(5);
        }
    }

    public void AddScore(float amount)
    {
        score += amount;
        UpdateScoreText();

        if (score > highscore)
        {
            highscore = score;
            HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
        }
    }

    private void UpdateScoreText()
    {
        ScoreText.text = "SCORE: " + score.ToString();
    }
}