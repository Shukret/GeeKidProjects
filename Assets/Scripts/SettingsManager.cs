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
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private LangeageManager langeageManager;
    private LevelManager levelManager;
    private bool isAudioOn, isVibrationOn, isMusicOn;

    public string[] usersName;

    private void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        settingsPanelEvent.NotifyEnable += LoadSwitch;
        settingsPanelEvent.NotifyEnable += ShowButtonAudioAndVibrationAndMusic;
        
    }
    private void StartMusic()
    {
        if (saveManager.isMusicOn)
            audioManager.music.volume = 1;
        else
            audioManager.music.volume = 0;
    }

    public void LoadSwitch()
    {
        isAudioOn = saveManager.IsAudioOn;
        isVibrationOn = saveManager.isVibrationOn;
        isMusicOn = saveManager.IsMusicOn;       
    }
    public void ShowButtonAudioAndVibrationAndMusic()
    {
        if (isAudioOn)
        {
            //�������� ����
            audioImage.sprite = audioOn;
        }
        else
        {
            //��������� ����
            audioImage.sprite = audioOff;
        }
        if (isVibrationOn)
        {
            //�������� ��������
            vibrationImage.sprite = vibrationOn;
        }
        else
        {
            //��������� �������� ��������
            vibrationImage.sprite = vibrationOff;
        }
        if (isMusicOn)
        {
            //�������� ������
            musicImage.sprite = musicOn;
        }
        else
        {
            //��������� ������
            musicImage.sprite = musicOff;
        }
    }
    public void SwitchAudio()
    {
        if (isAudioOn)
        {
            //��������� ����
            isAudioOn = !isAudioOn;
            audioImage.sprite = audioOff;
        }
        else
        {
            //�������� ����
            isAudioOn = !isAudioOn;
            audioImage.sprite = audioOn;
        }
        saveManager.IsAudioOn = isAudioOn;
    }
    public void SwitchVibration()
    {
        if (isVibrationOn)
        {
            //��������� ��������
            isVibrationOn = !isVibrationOn;
            vibrationImage.sprite = vibrationOff;
        }
        else
        {
            //�������� �������� ��������
            isVibrationOn = !isVibrationOn;
            vibrationImage.sprite = vibrationOn;
        }
        saveManager.isVibrationOn = isVibrationOn;
    }
    public void SwitchMusic()
    {
        if (isMusicOn)
        {
            //��������� ������
            isMusicOn = !isMusicOn;
            musicImage.sprite = musicOff;
            audioManager.music.volume = 0;
        }
        else
        {
            //�������� ������
            isMusicOn = !isMusicOn;
            musicImage.sprite = musicOn;
            audioManager.music.volume = 1;
        }
        saveManager.IsMusicOn = isMusicOn;
    }
    public void Repost()
    {
        //������ ������
        StartCoroutine(LoadImageAndShare());
    }
    public void Shop()
    {
        //��������� �������
    }
    public void Rating()
    {
        leaderboardShowcase.LoadUsersName();
        if (saveManager.UserName == "" || saveManager.UserName == null)
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
        //��������� ����
    }
    public void Policy()
    {
        //������� �������� ������������������
        Application.OpenURL("https://disk.yandex.ru/i/_Wr_1Jz_PVOLMQ");
    }
    public void InputUserName()
    {
        if (CheckUserName(inputUserName.text))
        {
            StartCoroutine(ShowErrorUserName(3, "����� ��� ��� ����������!"));
            
        }
        else if (inputUserName.text == "" || inputUserName.text == null)
        {
            StartCoroutine(ShowErrorUserName(3, "�� �� ����� ���!"));
        }
        else
        {
            saveManager.UserName = inputUserName.text;
            levelManager.OffAllPanel();
            ratingPanel.SetActive(true);
            leaderboardShowcase.Submit();
        }
        
    }
    private bool CheckUserName(string name)
    {
        for( int i = 0; i < usersName.Length; i++)
        {
            if (usersName[i] == name) return true;
        }
        return false;
    }
    public void SwitchLangeage(string langString)
    {
        Language language = Language.Russian;
        if (langString == "English")
        {
            language = Language.English;
        }    
        if (langString == "�������")
        {
            language = Language.Russian;
        }
        langeageManager.SwitchLangeage(language);
        saveManager.Language = language;
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
            .SetSubject("Subject goes here").SetText("����� ������ �� ����").SetUrl("https://github.com/yasirkula/UnityNativeShare")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

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
