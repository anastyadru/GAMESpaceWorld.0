// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public BulletControllerPlayer bulletPrefabPlayer;
    public BulletControllerEnemy bulletPrefabEnemy;
    public Enemy PrefabEnemy;
    
    public Dictionary<Type, Queue<IPoolable>> playerPoolDictionary = new Dictionary<Type, Queue<IPoolable>>();
    public Dictionary<Type, Queue<IPoolable>> enemyPoolDictionary = new Dictionary<Type, Queue<IPoolable>>();
    
    public int initialPoolSize = 35;
    public int maxPoolSize = 80;
    
    public void Start()
    {
        PrePool<BulletControllerPlayer>(bulletPrefabPlayer, initialPoolSize, playerPoolDictionary);
        PrePool<BulletControllerEnemy>(bulletPrefabEnemy, initialPoolSize, enemyPoolDictionary);
        PrePool<Enemy>(PrefabEnemy, 10, enemyPoolDictionary);
    }

    public void PrePool<T>(T prefab, int count, Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (!poolDict.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = new Queue<IPoolable>();
            for (int i = 0; i < count; i++)
            {
                T obj = Instantiate(prefab);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDict.Add(type, objectPool);
        }
    }

    public T Get<T>(Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDict.ContainsKey(type))
        {
            if (poolDict[type].Count == 0)
            {
                if (poolDict[type].Count < maxPoolSize)
                {
                    T prefab = null;
                    if (type == typeof(BulletControllerPlayer)) prefab = bulletPrefabPlayer as T;
                    else if (type == typeof(BulletControllerEnemy)) prefab = bulletPrefabEnemy as T;
                    else if (type == typeof(Enemy)) prefab = PrefabEnemy as T;

                    if (prefab != null)
                    {
                        PrePool(prefab, 1, poolDict);
                    }
                }
            }

            if (poolDict[type].Count > 0)
            {
                IPoolable obj = poolDict[type].Dequeue();
                return (T)obj;
            }
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