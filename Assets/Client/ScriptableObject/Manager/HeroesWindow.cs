// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroesWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("Heroes window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Heroes window closed");
    }
}