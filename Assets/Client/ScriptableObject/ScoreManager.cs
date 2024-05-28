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
        if (other.CompareTag("Enemy")) // Проверяем столкновение с врагом
        {
            bonus += 5;
            UpdateBonusText();
        }
    }
    
    private void UpdateBonusText()
    {
        BonusText.text = "BONUS: " + bonus.ToString();
    }
}