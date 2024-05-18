// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ObjectPool : MonoBehaviour
// {
    // private Dictionary<MonoBehaviour, Queue<MonoBehaviour>> poolDictionary = new Dictionary<MonoBehaviour, Queue<MonoBehaviour>>();

    // public void Start()
    // {
        // PrePool<BulletControllerPlayer>(bulletPrefabPlayer, 20);
        // PrePool<BulletControllerEnemy>(bulletPrefabEnemy, 10);
        // PrePool<Enemy>(PrefabEnemy, 10);
    // }

    // public void PrePool<T>(T prefab, int count) where T : MonoBehaviour, IPoolable
    // {
        // if (!poolDictionary.ContainsKey(prefab))
        // {
            // Queue<MonoBehaviour> objectPool = new Queue<MonoBehaviour>();
            // for (int i = 0; i < count; i++)
            // {
                // T obj = GameObject.Instantiate(prefab);
                // obj.gameObject.SetActive(false);
                // objectPool.Enqueue(obj);
            // }

            // poolDictionary.Add(prefab, objectPool);
        // }
    // }

    // public T Get<T>() where T : MonoBehaviour, IPoolable
    // {
        // if (poolDictionary.ContainsKey(T))
        // {
            // Queue<MonoBehaviour> objectPool = poolDictionary[T];
            // if (objectPool.Count > 0)
            // {
                // T obj = objectPool.Dequeue();
                // obj.gameObject.SetActive(true);
                // return obj;
            // }
        // }

        // return null;
    // }

    // public void Release<T>(T poolableObject) where T : MonoBehaviour, IPoolable
    // {
        // if (poolDictionary.ContainsKey(T))
        // {
            // Queue<MonoBehaviour> objectPool = poolDictionary[T];
            // objectPool.Enqueue(poolableObject);
            // poolableObject.OnRelease();
        // }
    // }
// }