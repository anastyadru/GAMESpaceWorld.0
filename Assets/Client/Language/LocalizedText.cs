using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Localization;

public class LocalizedText : MonoBehaviour
{
    public TextObject textObject;
    public Text textComponent;

    private void Start()
    {
        LocalizationManager.OnLanguageChanged += UpdateText;
        UpdateText();
    }

    private void OnDestroy()
    {
        LocalizationManager.OnLanguageChanged -= UpdateText;
    }

    private void UpdateText()
    { 
        if (textComponent != null)
        {
            string language = LocalizationManager.CurrentLanguage;
            string text = textObject.GetText(language);
            textComponent.text = text;
        }
    }
}