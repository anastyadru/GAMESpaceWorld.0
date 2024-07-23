// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNext : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadMenu();
        }
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}