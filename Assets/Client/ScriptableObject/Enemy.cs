// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 250f;
    private float smoothness = 3f;
    private float projectileSpeedMultiplier = 1.05f;
    
    public int health = 100;

    private Vector3 targetPosition;
    
    public GameObject lazerShot1;
    public Transform lazerGun1;
    private float nextShotTime;
    
    public int health;

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
        GameObject bullet = Instantiate(lazerShot1, lazerGun1.position, Quaternion.identity);
        BulletControllerEnemy bulletController = bullet.GetComponent<BulletControllerEnemy>();
        bulletController.SetSpeedMultiplier(projectileSpeedMultiplier);
        nextShotTime = Time.time + 5f;
    }
    
    public void OnRelease()
    {
        // Действия при уничтожении врага
    }
}