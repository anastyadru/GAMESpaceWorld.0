// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WindowManager : MonoBehaviour
// {
    // private static WindowManager instance;
    
    // private Stack<BaseWindow> windowStack = new Stack<BaseWindow>();
    
    // public static WindowManager Instance
    // {
        // get
        // {
            // if (instance == null)
            // {
                // instance = FindObjectOfType<WindowManager>();
                // if (instance == null)
                // {
                    // GameObject container = new GameObject("WindowManager");
                    // instance = container.AddComponent<WindowManager>();
                // }
            // }
            
            // return instance;
        // }
    // }

    // private void Awake()
    // {
        // windowStack = new Stack<BaseWindow>();
    // }

    // public void Open(WindowID windowID)
    // {
        // BaseWindow window = GetWindow(windowID);
        // if (window != null)
        // {
            // window.gameObject.SetActive(true);
            // window.OnOpened();
            // windowStack.Push(window);
        // }
    // }

    // public void CloseLast()
    // {
        // if (windowStack.Count > 0)
        // {
            // BaseWindow window = windowStack.Pop();
            // window.OnClosed();
            // window.gameObject.SetActive(false);
        // }
    // }

    private BaseWindow GetWindow(WindowID windowID)
    {
        switch (windowID)
        {
            case WindowID.Heroes:
                return FindObjectOfType<HeroesWindow>();
            case WindowID.Settings:
                return FindObjectOfType<SettingsWindow>();
            case WindowID.Exit:
                return FindObjectOfType<ExitWindow>();
            case WindowID.ChoiceLeft:
                return FindObjectOfType<ChoiceLeftWindow>();
            case WindowID.ChoiceRight:
                return FindObjectOfType<ChoiceRightWindow>();
            case WindowID.Confirm:
                return FindObjectOfType<ConfirmWindow>();
            case WindowID.Pause:
                return FindObjectOfType<PauseWindow>();
            case WindowID.Continue:
                return FindObjectOfType<ContinueWindow>();
            case WindowID.SoundEffects:
                return FindObjectOfType<SoundEffectsWindow>();
            case WindowID.Music:
                return FindObjectOfType<MusicWindow>();
            case WindowID.MainMenu:
                return FindObjectOfType<MainMenuWindow>();
            case WindowID.PlayAgain:
                return FindObjectOfType<PlayAgainWindow>();
            default:
                return null;
        }
    }
}