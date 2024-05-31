// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
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
        PrePool<BulletControllerPlayer>(bulletPrefabPlayer, 50);
        PrePool<BulletControllerEnemy>(bulletPrefabEnemy, 50);
        PrePool<Enemy>(PrefabEnemy, 30);
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
            else 
            {
                // Если пулл пуст, создаем новый объект и добавляем его в пулл
                T newObj = GameObject.Instantiate(prefabEnemy) as T;
                newObj.gameObject.SetActive(true);
                return newObj;
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