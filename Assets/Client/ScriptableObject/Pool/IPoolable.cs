// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IPoolable
{
    void OnRelease();
}