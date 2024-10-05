// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public int currentWave = 0;
    public int[] waveSizes = { 3, 5, 4, 6, 8, 9, 8 };
    
    public float enemyHealthMultiplier = 1.05f;
    public int remainingEnemies;
    public HealthManagerEnemy enemyHealth;
    public Image bar;

    public void Start()
    {
        GenerateWave(waveSizes[currentWave], transform.position, 1.0f);
    }

    public void DeductEnemy()
    {
        enemyHealth.TakeDamage();
        --remainingEnemies;
        
        if (remainingEnemies == 0)
        {
            EndWave();
        }
    }
    
    private void EndWave()
    {
        currentWave++;
        if (currentWave < waveSizes.Length)
        {
            float newEnemyHealth = enemyHealth.fill * Mathf.Pow(enemyHealthMultiplier, currentWave);
            GenerateWave(waveSizes[currentWave], transform.position, newEnemyHealth);
        }
        else
        {
            EndGame();
        }
    }
    
    public void GenerateWave(int enemyCount, Vector3 startPosition, float initialEnemyHealth)
    {
        remainingEnemies = enemyCount;
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, startPosition + new Vector3(Random.Range(-100f, 100f), 0, 0), transform.rotation);
            HealthManagerEnemy enemyHealthComponent = enemy.GetComponent<HealthManagerEnemy>();
            enemyHealthComponent.bar = bar;
            enemyHealthComponent.fill = initialEnemyHealth;
        }
    }
    
    public void EndGame()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}