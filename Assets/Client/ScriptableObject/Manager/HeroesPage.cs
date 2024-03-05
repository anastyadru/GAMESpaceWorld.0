// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroesPage : BasePage
{
    public override void OnOpened(object parameters)
    {
        Debug.Log("Heroes page opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Heroes page closed");
    }
}