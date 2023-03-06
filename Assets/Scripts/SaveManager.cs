using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private int lastLevel, ideas , score;
    [SerializeField] private string userName;
    [SerializeField] public bool isAudioOn, isVibrationOn, isMusicOn;
    [SerializeField] private bool[] isClueOpen;
    [SerializeField] private int[] countTry;

    private void Awake()
    {
        Load();
        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().StartGame();
        AudioManager audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        if (isMusicOn) audioManager.music.volume = 1;
        else audioManager.music.volume = 0;
    }
    public int LastLevel
    {
        get
        {         
            return lastLevel;
        }
        set
        {
            lastLevel = value;
            Save();
        }
    }
    public bool IsAudioOn
    {
        get
        {
            return isAudioOn;
        }
        set
        {
            isAudioOn = value;
            Save();
        }
    }
    private bool IsVibrationOn
    {
        get
        {
            return IsVibrationOn;
        }
        set
        {
            IsVibrationOn = value;
            Save();
        }
    }
    public bool IsMusicOn
    {
        get
        {
            return isMusicOn;
        }
        set
        {
            isMusicOn = value;
            Save();
        }
    }
    public int Ideas
    {
        get
        {
            return ideas;
        }
        set
        {
            ideas = value;
            Save();
        }
    }
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            Save();
        }
    }
    public string UserName
    {
        get
        {
            return userName;
        }
        set
        {
            userName = value;
            Save();
        }
    }

    public void SetIsClueOpen(bool value, int index)
    {
        isClueOpen[index] = value;
        Save();
    }
    public void SetIsClueOpen(bool[] values)
    {
        isClueOpen = values;
        Save();
    }

    public void SetCountTry(int value, int index)
    {
        countTry[index] = value;
        Save();
    }
    public void SetCoutTry(int[] values)
    {
        countTry = values;
        Save();
    }
    public bool GetIsClueOpen(int index)
    {
        return isClueOpen[index];
    }
    public bool[] GetIsClueOpen()
    {
        return isClueOpen;
    }
    public int GetCountTry(int index)
    {
        return countTry[index];
    }
    public int[] GetCountTry()
    {
        return countTry;
    }

    public void CountryTryIncrement(int index)
    {
        countTry[index]++;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetString("Exist", "Exist");
        PlayerPrefs.SetInt("lastLevel", lastLevel);
        PlayerPrefs.SetInt("ideas", ideas);
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetString("userName", userName);
        string stringIsAudioMusicVibrationOn = isAudioOn.ToString() + "," + isMusicOn.ToString() + "," + isVibrationOn.ToString();
        PlayerPrefs.SetString("stringIsAudioMusicVibrationOn", stringIsAudioMusicVibrationOn);
        string stringIsClueOpen = "";
        for (int i = 0; i < isClueOpen.Length; i++)
        {
            if (i == isClueOpen.Length - 1)
                stringIsClueOpen += isClueOpen[i].ToString();
            else
                stringIsClueOpen += isClueOpen[i].ToString() + ",";
        }
        PlayerPrefs.SetString("isClueOpen", stringIsClueOpen);
        string stringCountTry = "";
        for (int i = 0; i < countTry.Length; i++)
        {
            if (i == countTry.Length - 1)
                stringCountTry += countTry[i].ToString();
            else
                stringCountTry += countTry[i].ToString() + ",";
        }
        PlayerPrefs.SetString("countTry", stringCountTry);
        PlayerPrefs.Save();
    }
    private void Load()
    {
        if (PlayerPrefs.HasKey("Exist"))
        {
            lastLevel = PlayerPrefs.GetInt("lastLevel");
            ideas = PlayerPrefs.GetInt("ideas");
            score = PlayerPrefs.GetInt("score");
            userName = PlayerPrefs.GetString("userName");
            string stringIsAudioMusicVibrationOn = PlayerPrefs.GetString("stringIsAudioMusicVibrationOn");
            isAudioOn = Convert.ToBoolean(stringIsAudioMusicVibrationOn.Split(',')[0]);
            isMusicOn = Convert.ToBoolean(stringIsAudioMusicVibrationOn.Split(',')[1]);
            isVibrationOn = Convert.ToBoolean(stringIsAudioMusicVibrationOn.Split(',')[2]);
            string stringIsClueOpen = PlayerPrefs.GetString("isClueOpen");
            string[] stringsIsClueOpen = stringIsClueOpen.Split(',');
            for (int i = 0; i < stringsIsClueOpen.Length; i++)
            {
                isClueOpen[i] = Convert.ToBoolean(stringsIsClueOpen[i]);
            }
            string stringCountTry = PlayerPrefs.GetString("countTry");
            string[] stringsCountTry = stringCountTry.Split(',');
            for (int i = 0; i < countTry.Length; i++)
            {
                countTry[i] = Convert.ToInt32(stringsCountTry[i]);
            }
        }
        
    }
    
}
