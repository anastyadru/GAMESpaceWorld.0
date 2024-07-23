// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class HealthManagerEnemy : MonoBehaviour
{
    public float fill = 100f;
    public Image bar;

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