// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("PlayAgain window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("PlayAgain window closed");
    }
}