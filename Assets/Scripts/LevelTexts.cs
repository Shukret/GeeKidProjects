using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTexts : MonoBehaviour
{
    [SerializeField] private string descriptionTextsEng;
    [SerializeField] private string descriptionTextsRus;

    [SerializeField] private string messageTextsEng;
    [SerializeField] private string messageTextsRus;

    [SerializeField] private string clueTextsEng;
    [SerializeField] private string clueTextsRus;



    public string ShowDescriptionText(Language language)
    {
        if(language == Language.English)
        {
            return descriptionTextsEng.ToUpper();
        }
        if(language == Language.Russian)
        {
            return descriptionTextsRus.ToUpper();
        }
        return null;
    }

    public string ShowClueText(Language language)
    {
        if (language == Language.English)
        {
            return clueTextsEng.ToUpper();
        }
        if (language == Language.Russian)
        {
            return clueTextsRus.ToUpper();
        }
        return null;
    }

    public string ShowMessageText(Language language)
    {
        if (language == Language.English)
        {
            return messageTextsEng.ToUpper();
        }
        if (language == Language.Russian)
        {
            return messageTextsRus.ToUpper();
        }
        return null;
    }
}
