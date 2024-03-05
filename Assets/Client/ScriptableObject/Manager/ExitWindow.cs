// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExitWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("Exit window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Exit window closed");
    }
}