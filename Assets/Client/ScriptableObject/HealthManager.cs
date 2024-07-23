// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Text HealthText;
    
    public float health = 100f;

    public void Start()
    {
        UpdateHealthText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot1"))
        {
            health -= 5;
            UpdateHealthText();
        }
    }
    
    public void Update()
    {
        if (health <= 0)
        {
            EndGame();
        }
    }
    
    private void UpdateHealthText()
    {
        HealthText.text = "HEALTH: " + health.ToString();
    }
    
    private void EndGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}