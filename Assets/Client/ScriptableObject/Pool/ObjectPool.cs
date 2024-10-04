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
    
    public int initialPoolSize = 50; // Начальный размер пула
    public int maxPoolSize = 100; // Максимальный размер пула
    public int increaseAmount = 10; // Количество объектов для увеличения пула
    
    public void Start()
    {
        PrePool<BulletControllerPlayer>(bulletPrefabPlayer, initialPoolSize);
        PrePool<BulletControllerEnemy>(bulletPrefabEnemy, initialPoolSize);
        PrePool<Enemy>(prefabEnemy, 10);
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
            poolSizes.Add(type, count);
        }
    }


    public T Get<T>() where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        
        if (poolDictionary.ContainsKey(type))
        {
            if (poolDictionary[type].Count == 0)
            {
                // Если пул пустой, создаем новый объект до максимального размера
                if (poolSizes[type] < maxPoolSize)
                {
                    int toAdd = Math.Min(maxPoolSize - poolSizes[type], increaseAmount); // Добавляем по increaseAmount объектов
                    PrePool(Instantiate(poolDictionary[type].Peek() as T), toAdd); // Используем существующий префаб
                }
            }

            if (poolDictionary[type].Count > 0)
            {
                IPoolable obj = poolDictionary[type].Dequeue();
                obj.gameObject.SetActive(true); // Активируем объект перед использованием
                return (T)obj;
            }
        }

        return null; // Возвращаем null, если нет доступных объектов
    }

    public void Release<T>(T poolableObject) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDictionary.ContainsKey(type))
        {
            poolDictionary[type].Enqueue(poolableObject);
            poolableObject.OnRelease();
            poolableObject.gameObject.SetActive(false); // Деактивируем объект при возврате в пул
        }
    }
    
    public BulletControllerPlayer GetPlayerBullet()
    {
        return Get<BulletControllerPlayer>();
    }

    public void ReleasePlayerBullet(BulletControllerPlayer bullet)
    {
        Release(bullet);
    }

    public BulletControllerEnemy GetEnemyBullet()
    {
        return Get<BulletControllerEnemy>();
    }

    public void ReleaseEnemyBullet(BulletControllerEnemy bullet)
    {
        Release(bullet);
    }
}