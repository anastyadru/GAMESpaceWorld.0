// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private Text BonusText;
    
    public float bonus = 0f;
    private bool isUltimateReady = false;
    
    private static BonusManager instance;

    public static BonusManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BonusManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<BonusManager>();
                    singletonObject.name = typeof(BonusManager).ToString() + " (Singleton)";
                }
            }
            return instance;
        }
    }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
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