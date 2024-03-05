// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("MainMenu window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("MainMenu window closed");
    }
}
