// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageManager : MonoBehaviour
{
    private static PageManager instance;
    private BasePage currentPage;

    public static PageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PageManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("PageManager");
                    instance = container.AddComponent<PageManager>();
                }
            }
            
            return instance;
        }
    }

    public void Open(PageID pageID, object parameters = null)
    {
        if (currentPage != null)
        {
            currentPage.OnClosed();
            Destroy(currentPage.gameObject);
        }

        BasePage page = GetPage(pageID);
        if (page != null)
        {
            GameObject pageObject = Instantiate(page.gameObject);
            currentPage = pageObject.GetComponent<BasePage>();
            currentPage.OnOpened(parameters);
        }
    }

    private BasePage GetPage(PageID pageID)
    {
        switch (pageID)
        {
            case PageID.Menu:
                return FindObjectOfType<MenuPage>();
            case PageID.Heroes:
                return FindObjectOfType<HeroesPage>();
            case PageID.Game:
                return FindObjectOfType<GamePage>();
            case PageID.GameOver:
                return FindObjectOfType<GameOverPage>();
            case PageID.GameOverWinnigs:
                return FindObjectOfType<GameOverWinnigsPage>();
            default:
                return null;
        }
    }
}