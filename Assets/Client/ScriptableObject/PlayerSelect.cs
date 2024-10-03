// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    private GameObject[] characters;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("SelectPlayer", 0);
        characters = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }

        SetActiveCharacter(index);
    }

    public void SelectLeft()
    {
        ChangeSelection(-1);
    }

    public void SelectRight()
    {
        ChangeSelection(1);
    }

    private void ChangeSelection(int direction)
    {
        SetActiveCharacter(index);
        index = (index + direction + characters.Length) % characters.Length;
        SetActiveCharacter(index);
    }

    private void SetActiveCharacter(int activeIndex)
    {
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        characters[activeIndex].SetActive(true);
    }

    public void StartScene()
    {
        PlayerPrefs.SetInt("SelectPlayer", index);
        SceneManager.LoadScene("Game");
    }
}