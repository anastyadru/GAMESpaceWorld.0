// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable
{
    private float smoothness = 3f;
    private Vector3 targetPosition;
    
    public GameObject lazerShot1;
    public Transform lazerGun1;
    private float nextShotTime;
    
    public int health = 100;
    
    private ObjectPool bulletPool;
    
    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>() ?? new GameObject("ObjectPool").AddComponent<ObjectPool>();
    }
    
    private void Start()
    {
        GenerateNewPosition();
    }

    private void GenerateNewPosition()
    {
        targetPosition = new Vector3(UnityEngine.Random.Range(-700f, 0f), transform.position.y, transform.position.z);
    }
    
    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 10f)
        {
            GenerateNewPosition();
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
        
        if (Time.time > nextShotTime)
        {
            Shoot();
        }
    }
    
    public void Shoot()
    {
        BulletControllerEnemy bullet = bulletPool?.Get<BulletControllerEnemy>(bulletPool.enemyPoolDictionary);
        if (bullet == null)
        {
            GameObject newBulletObject = Instantiate(lazerShot1, lazerGun1.position, Quaternion.identity);
            bullet = newBulletObject.GetComponent<BulletControllerEnemy>();
        }

        if (bullet != null)
        {
            bullet.transform.position = lazerGun1.position;
            bullet.gameObject.SetActive(true);
            nextShotTime = Time.time + 1.5f;
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Enemy took {damage} damage. Health now: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ScoreManager.Instance.AddScore(100);
        Debug.Log("Enemy died.");
        OnRelease();
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
        EnemyController.Instance.DeductEnemy();
    }
}