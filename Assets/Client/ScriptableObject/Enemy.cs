// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable
{
    private float speed = 250f;
    private float smoothness = 3f;
    private float projectileSpeedMultiplier = 1.05f;

    private Vector3 targetPosition;
    
    public GameObject lazerShot1;
    public Transform lazerGun1;
    private float nextShotTime;
    
    public int health = 100;
    
    private ObjectPool bulletPool;
    
    public void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
        
        if (bulletPool == null)
        {
            GameObject objectPoolObject = new GameObject("ObjectPool");
            bulletPool = objectPoolObject.AddComponent<ObjectPool>();
        }
    }
    
    public void Start()
    {
        GenerateNewTargetPosition();
    }

    public void GenerateNewTargetPosition()
    {
        float randomX = UnityEngine.Random.Range(-700f, 0f);
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
        if (bulletPool != null)
        {
            BulletControllerEnemy bullet = bulletPool.Get<BulletControllerEnemy>(bulletPool.enemyPoolDictionary);
            if (bullet != null)
            {
                bullet.transform.position = lazerGun1.position;
                bullet.gameObject.SetActive(true);
                nextShotTime = Time.time + 1.5f;
            }
        }
        else
        {
            GameObject newBulletObject = Instantiate(lazerShot1, lazerGun1.position, Quaternion.identity);
            BulletControllerEnemy newBullet = newBulletObject.GetComponent<BulletControllerEnemy>();
            if (newBullet != null)
            {
                newBullet.gameObject.SetActive(true);
                nextShotTime = Time.time + 1.5f;
            }
        }
    }
    
    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}