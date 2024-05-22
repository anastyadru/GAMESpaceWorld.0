// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<Type, Queue<IPoolable>> poolDictionary = new Dictionary<Type, Queue<IPoolable>>();
    
    // public BulletControllerPlayer bulletPrefabPlayer;
    // public BulletControllerEnemy bulletPrefabEnemy;
    // public Enemy PrefabEnemy;

    public void Start()
    {
        PrePool<BulletControllerPlayer>(bulletPrefabPlayer, 20);
        PrePool<BulletControllerEnemy>(bulletPrefabEnemy, 10);
        PrePool<Enemy>(PrefabEnemy, 10);
    }

    public void PrePool<T>(T prefab, int count) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (!poolDictionary.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = new Queue<IPoolable>();
            for (int i = 0; i < count; i++)
            {
                T obj = GameObject.Instantiate(prefab) as T;
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(type, objectPool);
        }
    }

    public T Get<T>() where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDictionary.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = poolDictionary[type];
            if (objectPool.Count > 0)
            {
                T obj = objectPool.Dequeue() as T;
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        return null;
    }

    public void Release<T>(T poolableObject) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDictionary.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = poolDictionary[type];
            objectPool.Enqueue(poolableObject);
            poolableObject.OnRelease();
        }
    }
}