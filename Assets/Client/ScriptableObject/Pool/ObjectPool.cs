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

    public void Start()
    {
        PrePool<BulletControllerPlayer>(bulletPrefabPlayer, 200, playerPoolDictionary);
        PrePool<BulletControllerEnemy>(bulletPrefabEnemy, 200, enemyPoolDictionary);
        PrePool<Enemy>(PrefabEnemy, 50, enemyPoolDictionary);
    }

    public void PrePool<T>(T prefab, int count, Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (!poolDict.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = new Queue<IPoolable>();
            for (int i = 0; i < count; i++)
            {
                T obj = GameObject.Instantiate(prefab) as T;
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDict.Add(type, objectPool);
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