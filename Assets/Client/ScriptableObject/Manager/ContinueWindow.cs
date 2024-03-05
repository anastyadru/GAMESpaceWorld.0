// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContinueWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("Continue window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Continue window closed");
    }
}