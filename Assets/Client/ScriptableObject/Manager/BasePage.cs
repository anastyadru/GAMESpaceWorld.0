// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasePage : MonoBehaviour
{
    public virtual void OnOpened(object parameters) { }
    public virtual void OnClosed() { }
}