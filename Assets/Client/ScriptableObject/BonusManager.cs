// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private Text BonusText;
    
    public float bonus = 0f;
    
    public GameObject lazerShot; // Префаб снаряда
    public Transform lazerGun; // Позиция для выстрела
    
    private bool isUltimateReady = false;
    
    public void Start()
    {
        UpdateBonusText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot") && other.CompareTag("Enemy"))
        {
            bonus += 5;
            UpdateBonusText();
        }
    }
    
    private void Update()
    {
        if (bonus >= 100)
        {
            UseBonus();
        }
    }
    
    private void UpdateBonusText()
    {
        BonusText.text = "BONUS: " + bonus.ToString();
    }

    private void UseBonus()
    {
        if (Input.GetButton("Fire2"))
        {
            if (lazerShot != null)
            {
                EnemyController enemy = lazerShot.GetComponent<EnemyController>();
                if (enemy != null && enemy.fill >= 50)
                {
                    enemy.fill -= 50;
                }
            }
        }
    }
}