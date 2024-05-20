// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // IPoolable
{
    private float speed = 250f;
    private float smoothness = 3f;
    private float projectileSpeedMultiplier = 1.05f;

    private Vector3 targetPosition;
    
    public GameObject lazerShot1;
    public Transform lazerGun1;
    private float nextShotTime;
    
    public int health;
    
    // private ObjectPool bulletPool;
    
    // private void Awake()
    // {
        // bulletPool = FindObjectOfType<ObjectPool>();
    // }
    
    public void Start()
    {
        GenerateNewTargetPosition();
    }

    public void GenerateNewTargetPosition()
    {
        float randomX = Random.Range(-700f, 0f);
        targetPosition = new Vector3(randomX, transform.position.y, transform.position.z);
    }
    
    public void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 10f)
        {
            GenerateNewTargetPosition();
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
        
        if (Time.time > nextShotTime)
        {
            Shoot();
        }
    }
    
    public void Shoot()
    {
        BulletControllerEnemy bullet = bulletPool.Get<BulletControllerEnemy>();
        bullet.transform.position = lazerGun1.position;
        bullet.gameObject.SetActive(true);
        nextShotTime = Time.time + 5f;
    }
    
    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}