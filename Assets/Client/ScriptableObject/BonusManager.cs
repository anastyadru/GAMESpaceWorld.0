// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

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
        foreach (GameObject enemyObject in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemyObject);
        }
    }
}