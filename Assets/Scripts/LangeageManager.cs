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
            levelText.text = "Уровни";
            settingsText.text = "Настройки";
            shopText.text = "Магазин (скоро)";
            ratingText.text = "Рейтинг";
            likeText.text = "Оценить";
            repostText.text = "Поделиться";
            policyText.text = "Политика конфиденциальности";
            messageText.text = "Поздравляем!";
            ClueText.text = "Подсказка";
            ratingGlobalText.text = "Рейтинг";
            placeHolderText.text = "Введите свое имя";
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
