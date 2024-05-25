// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour, IPoolable
{
    public float speed = 100;
    
    private ObjectPool bulletPool;

    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
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
    
    public void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
    }

    public void OnHit()
    {
        OnRelease(); // Деактивируем пулю
        bulletPool.Release(this); // Возвращаем пулю в пул для повторного использования
    }
}