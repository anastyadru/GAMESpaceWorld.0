// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class BulletControllerPlayer : MonoBehaviour, IPoolable
{
    public float speed = 100;
    
    private ObjectPool bulletPool;
    private Rigidbody rb;

    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.health -= 20;
            if (enemy.health <= 0)
            {
                enemy.OnRelease();
            }
            
            OnHit();
        }
    }
    
    public void OnHit()
    {
        OnRelease();
        bulletPool.Release(this, bulletPool.playerPoolDictionary);
    }
    
    private void Update()
    {
        rb.velocity = new Vector3(0, 0, speed);
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}