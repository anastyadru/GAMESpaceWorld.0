// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour, IPoolable
{
    private float initialSpeed = 100;
    private float speedMultiplier = 1.05f;
    
    private ObjectPool bulletPool;
    private EnemyController enemyController;
    private Rigidbody rb;

    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
        enemyController = FindObjectOfType<EnemyController>();
        rb = GetComponent<Rigidbody>();
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
            rb.velocity = new Vector3(0, 0, -currentSpeed);
        }
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}