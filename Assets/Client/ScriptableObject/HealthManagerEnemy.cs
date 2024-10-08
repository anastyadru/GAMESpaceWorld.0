// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class HealthManagerEnemy : MonoBehaviour
{
    public float fill = 100f;
    public Image bar;

    private static HealthManagerEnemy instance;

    public static HealthManagerEnemy Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HealthManagerEnemy>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<HealthManagerEnemy>();
                    singletonObject.name = typeof(HealthManagerEnemy).ToString() + " (Singleton)";
                }
            }
            return instance;
        }
    }
    
    
    
    public void TakeDamage()
    {
        fill -= 20;
        bar.fillAmount = fill / 100;
        if (fill <= 0)
        {
            EndEnemy();
        }
    }

    private void EndEnemy()
    {
        gameObject.SetActive(false);
    }
}