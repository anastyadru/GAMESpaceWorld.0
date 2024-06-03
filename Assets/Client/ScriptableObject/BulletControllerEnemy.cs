// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour, IPoolable
{
    public float initialSpeed = 100;
    public float speedMultiplier = 1.05f;
    
    public ObjectPool bulletPool;
    private EnemyController enemyController;

    public void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
        enemyController = FindObjectOfType<EnemyController>();
    }

    public void OnTriggerEnter(Collider other)
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
    
    public void OnHit()
    {
        OnRelease();
        bulletPool.Release(this, bulletPool.enemyPoolDictionary);
    }
    
    public void Update()
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