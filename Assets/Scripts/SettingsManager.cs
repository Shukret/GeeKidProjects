using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Sprite audioOn, audioOff, vibrationOn, vibrationOff, musicOn, musicOff;
    [SerializeField] private Image audioImage, vibrationImage, musicImage;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private EventOnEnableSettings settingsPanelEvent;
    [SerializeField] private GameObject ratingPanel, inputUserNamePanel;
    [SerializeField] private TMP_InputField inputUserName;
    [SerializeField] private GameObject errorUserName;
    [SerializeField] private LeaderboardShowcase leaderboardShowcase;

    private LevelManager levelManager;
    private bool isAudioOn, isVibrationOn, isMusicOn;

    private void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        settingsPanelEvent.NotifyEnable += LoadSwitch;
        settingsPanelEvent.NotifyEnable += ShowButtonAudioAndVibrationAndMusic;

    }

    public void LoadSwitch()
    {
        isAudioOn = saveManager.isAudioOn;
        isVibrationOn = saveManager.isVibrationOn;
        isMusicOn = saveManager.isMusicOn;       
    }
    public void ShowButtonAudioAndVibrationAndMusic()
    {
        if (isAudioOn)
        {
            //включаем звук
            audioImage.sprite = audioOn;
        }
        else
        {
            //выключаем звук
            audioImage.sprite = audioOff;
        }
        if (isVibrationOn)
        {
            //включаем вибрацию
            vibrationImage.sprite = vibrationOn;
        }
        else
        {
            //выключаем включаем вибрацию
            vibrationImage.sprite = vibrationOff;
        }
        if (isMusicOn)
        {
            //включаем музыку
            musicImage.sprite = musicOn;
        }
        else
        {
            //выключаем музыку
            musicImage.sprite = musicOff;
        }
    }
    public void SwitchAudio()
    {
        if (isAudioOn)
        {
            //выключаем звук
            isAudioOn = !isAudioOn;
            audioImage.sprite = audioOff;
        }
        else
        {
            //включаем звук
            isAudioOn = !isAudioOn;
            audioImage.sprite = audioOn;
        }
        saveManager.isAudioOn = isAudioOn;
    }
    public void SwitchVibration()
    {
        if (isVibrationOn)
        {
            //выключаем вибрацию
            isVibrationOn = !isVibrationOn;
            vibrationImage.sprite = vibrationOff;
        }
        else
        {
            //включаем включаем вибрацию
            isVibrationOn = !isVibrationOn;
            vibrationImage.sprite = vibrationOn;
        }
        saveManager.isVibrationOn = isVibrationOn;
    }
    public void SwitchMusic()
    {
        if (isMusicOn)
        {
            //выключаем музыку
            isMusicOn = !isMusicOn;
            musicImage.sprite = musicOff;
        }
        else
        {
            //включаем музыку
            isMusicOn = !isMusicOn;
            musicImage.sprite = musicOn;
        }
        saveManager.isMusicOn = isMusicOn;
    }
    public void Repost()
    {
        //Делаем репост
        StartCoroutine(TakeScreenshotAndShare());
    }
    public void Shop()
    {
        //открываем мазагин
    }
    public void Rating()
    {
        if (saveManager.userName == "" || saveManager.userName == null)
        {
            levelManager.OffAllPanel();
            inputUserNamePanel.SetActive(true);
        }
        else
        {
            levelManager.OffAllPanel();
            ratingPanel.SetActive(true);
            leaderboardShowcase.Submit();
        }
        
    }
    public void Like()
    {
        //оцениваем игру
    }
    public void Policy()
    {
        //Смотрим политику конфиденциальности
        Application.OpenURL("https://docs.unity3d.com/ScriptReference/Application.OpenURL.html");
    }
    public void InputUserName()
    {
        saveManager.userName = inputUserName.text;
        leaderboardShowcase.CheckUserName();
        if (saveManager.userName == "DoubleName")
        {
            StartCoroutine(ShowErrorUserName(3, "Такое имя уже существует!"));
            
        }
        else if (saveManager.userName == "" || saveManager.userName == null)
        {
            StartCoroutine(ShowErrorUserName(3, "Вы не ввели имя!"));
        }
        else
        {
            levelManager.OffAllPanel();
            ratingPanel.SetActive(true);
            leaderboardShowcase.Submit();
        }
        
    }
    public void EnglishLanguage()
    {
        //Включаем английский язык
    }
    public void RussianLangeage()
    {
        //Включаем русский язык
    }
    private IEnumerator ShowErrorUserName(int time, string textError)
    {
        errorUserName.SetActive(true);
        errorUserName.GetComponent<TMP_Text>().text = textError;
        yield return new WaitForSeconds(time);
        errorUserName.SetActive(false);
    }
    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("Subject goes here").SetText("Hello world!").SetUrl("https://github.com/yasirkula/UnityNativeShare")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
    }
    private IEnumerator LoadImageAndShare()
    {
        Texture2D image = Resources.Load("Share", typeof(Texture2D)) as Texture2D;
        yield return new WaitForEndOfFrame();
        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, image.EncodeToPNG());

        new NativeShare().AddFile(filePath)
            .SetSubject("Subject goes here").SetText("Hello world!").SetUrl("https://github.com/yasirkula/UnityNativeShare")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }
}
