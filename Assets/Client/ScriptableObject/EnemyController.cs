// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    private int currentWave = 0;
    private int[] waveSizes = { 2, 4, 3, 5, 7, 11, 7 };
    
    private float enemyHealthMultiplier = 1.05f;
    private int remainingEnemies;
    public HealthManagerEnemy enemyHealth;
    public Image bar;
    // public double fill = 1f;

    public void Start()
    {
        GenerateWave(waveSizes[currentWave], transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot"))
        {
            Destroy(other.gameObject);
            enemyHealth.TakeDamage();
            remainingEnemies--;
            if (remainingEnemies == 0)
            {
                currentWave++;
                if (currentWave < waveSizes.Length)
                {
                    GenerateWave(waveSizes[currentWave], transform.position);
                }
                else
                {
                    EndGame();
                }
            }
        }
    }
    
    private void GenerateWave(int enemyCount, Vector3 startPosition)
    {
        remainingEnemies = enemyCount;
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, startPosition, transform.rotation);
            float randomX = UnityEngine.Random.Range(-100f, 100f);
            enemy.transform.position += new Vector3(randomX, 0, 0);
            HealthManagerEnemy enemyHealth = enemy.GetComponent<HealthManagerEnemy>();
            enemyHealth.bar = bar;
        }
    }
    
    private void EndGame()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}