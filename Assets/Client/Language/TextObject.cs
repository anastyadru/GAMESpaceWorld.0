using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Text Object", menuName = "Localization/TextObject")]
public class TextObject : ScriptableObject
{
    public Dictionary<string, string> texts = new Dictionary<string, string>();

    public void AddText(string language, string text)
    {
        texts[language] = text;
    }

    public string GetText(string language)
    {
        if (texts.ContainsKey(language))
        {
            return texts[language];
        }
        else
        {
            Debug.LogError("Text not found for language: " + language);
            return "";
        }
    }
}