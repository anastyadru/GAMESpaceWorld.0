// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManagerEnemy : MonoBehaviour
{
    public double fill = 1f;
    public Image bar;

    public void TakeDamage()
    {
        fill -= 0.2;
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