// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour
{
    public AudioSource audio_;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume")) audio_.volume = 1;
    }

    private void Update()
    {
        audio_.volume = PlayerPrefs.GetFloat("volume");
    }
}