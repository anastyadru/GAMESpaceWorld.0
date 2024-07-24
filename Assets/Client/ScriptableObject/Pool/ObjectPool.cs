// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public BulletControllerPlayer bulletPrefabPlayer;
    public BulletControllerEnemy bulletPrefabEnemy;
    public Enemy PrefabEnemy;
    
    private Dictionary<Type, Queue<IPoolable>> poolDictionary = new Dictionary<Type, Queue<IPoolable>>();

    public void Start()
    {
        PrePool(bulletPrefabPlayer, 200);
        PrePool(bulletPrefabEnemy, 200);
        PrePool(prefabEnemy, 50);
    }

    private void PrePool<T>(T prefab, int count) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (!poolDictionary.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = new Queue<IPoolable>();
            for (int i = 0; i < count; i++)
            {
                T obj = Instantiate(prefab);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(type, objectPool);
        }
    }

    public T Get<T>(Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDict.ContainsKey(type) && poolDict[type].Count > 0)
        {
            IPoolable obj = poolDict[type].Dequeue();
            return (T)obj;
        }
    
        return null;
    }

    public void Release<T>(T poolableObject, Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDict.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = poolDict[type];
            objectPool.Enqueue(poolableObject);
            poolableObject.OnRelease();
        }
    }
    public BulletControllerPlayer GetPlayerBullet()
    {
        return Get<BulletControllerPlayer>(playerPoolDictionary);
    }

    public void ReleasePlayerBullet(BulletControllerPlayer bullet)
    {
        Release(bullet, playerPoolDictionary);
    }

    public BulletControllerEnemy GetEnemyBullet()
    {
        return Get<BulletControllerEnemy>(enemyPoolDictionary);
    }

    public void ReleaseEnemyBullet(BulletControllerEnemy bullet)
    {
        Release(bullet, enemyPoolDictionary);
    }
}