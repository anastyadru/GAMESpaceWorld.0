// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour, IPoolable
{
    public float speed = 100;
    
    private ObjectPool bulletPool;
    private Transform playerTransform;

    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
                bulletPool.Release(this);
            }
        }
    }
    
    public void Update()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}