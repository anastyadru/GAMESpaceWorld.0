// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNext : MonoBehaviour
{
    public bool NextGame;
    private GameObject nextGameMenu;
    
    void Update()
    {
        if (Input.GetKeyDown("Next"))
        {
            LoadMenu();
        }
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}