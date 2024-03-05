// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioToggler : MonoBehaviour
{
    public bool isOn;
    
    private void Start()
    {
        isOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        if (isOn)
        {
            AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0f;
        }
    }

    public void OnOffSounds()
    {
        if (!isOn)
        {
            AudioListener.volume = 1f;
            isOn = true;
        }
        else
        {
            AudioListener.volume = 0f;
            isOn = false;
        }

        PlayerPrefs.SetInt("SoundOn", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}