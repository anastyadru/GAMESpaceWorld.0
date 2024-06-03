// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour, IPoolable
{
    private float initialSpeed = 100;
    private float speedMultiplier = 1.05f;
    
    private ObjectPool bulletPool;
    private EnemyController enemyController;

    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
        enemyController = FindObjectOfType<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.health -= 5;
            if (player.health <= 0)
            {
                player.OnRelease();
            }
            
            OnHit();
        }
    }
    
    private void OnHit()
    {
        OnRelease();
        bulletPool.Release(this, bulletPool.enemyPoolDictionary);
    }
    
    private void Update()
    {
        if (enemyController != null)
        {
            float currentSpeed = initialSpeed * Mathf.Pow(speedMultiplier, enemyController.currentWave);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -currentSpeed);
        }
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}