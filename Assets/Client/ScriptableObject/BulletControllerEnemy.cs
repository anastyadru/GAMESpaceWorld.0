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
        else
        {
            OnRelease(); // Если пуля сталкивается с чем-то, кроме игрока, она возвращается в пул
        }
    }
    
    public void OnHit()
    {
        OnRelease();
        bulletPool.Release(this);
    }
    public void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}