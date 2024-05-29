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

    private bool isUltimateReady = false;
    
    public void Start()
    {
        UpdateBonusText();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot"))
        {
            bonus += 4;
            UpdateBonusText();
        }
    }
    
    private void Update()
    {
        if (bonus >= 100)
        {
            isUltimateReady = true;
        }
        
        if (isUltimateReady && Input.GetButtonDown("Fire2"))
        {
            UseUltimate();
        }
    }
    
    private void UpdateBonusText()
    {
        BonusText.text = "BONUS: " + bonus.ToString();
    }

    private void UseUltimate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemies)
        {
            EnemyController enemy = enemyObject.GetComponent<EnemyController>();
        
            if (enemy != null)
            {
                enemy.fill -= 2.5f * enemy.baseDamage; // Наносим урон равный 250% от базового урона
            }
        }
    }
}