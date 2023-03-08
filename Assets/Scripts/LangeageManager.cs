using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Language
{
    English,
    Russian
}

public class LangeageManager : MonoBehaviour
{

    [SerializeField] private TMP_Text levelText, settingsText, shopText, ratingText, likeText, repostText, policyText, messageText, ClueText, ratingGlobalText, placeHolderText;
    [SerializeField] private SaveManager saveManager;

    private void Awake()
    {
        SwitchLangeage(saveManager.Langeage);
    }
    public void SwitchLangeage(Language language)
    {
        if (language == Language.Russian)
        {
            levelText.text = "������";
            settingsText.text = "���������";
            shopText.text = "������� (�����)";
            ratingText.text = "�������";
            likeText.text = "�������";
            repostText.text = "����������";
            policyText.text = "�������� ������������������";
            messageText.text = "�����������!";
            ClueText.text = "���������";
            ratingGlobalText.text = "�������";
            placeHolderText.text = "������� ���� ���";
        }
        if (language == Language.English)
        {
            levelText.text = "LEVELS";
            settingsText.text = "SETTINGS";
            shopText.text = "SHOP (SOON)";
            ratingText.text = "RATING";
            likeText.text = "ESTIMATE";
            repostText.text = "SHARE";
            policyText.text = "PRIVACY POLICY";
            messageText.text = "CONGRATULATIONS!";
            ClueText.text = "CLUE";
            ratingGlobalText.text = "RATING";
            placeHolderText.text = "ENTER YOUR NAME!";
        }
    }

}
