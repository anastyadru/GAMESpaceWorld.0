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
    
    // public GameObject lazerShot;
    // public Transform lazerGun;
    
    // public void Start()
    // {
        // UpdateBonusText();
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot") && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
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
            // Действия при использовании бонуса
            bonus = 0; // Сброс бонусов после использования
            UpdateBonusText();
        }
    }
}