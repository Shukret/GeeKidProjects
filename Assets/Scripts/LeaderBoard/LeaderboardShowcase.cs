using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using Dan.Models;
using UnityEngine.UI;

public class LeaderboardShowcase : MonoBehaviour
{
    [SerializeField] private string _leaderboardPublicKey = "e1129413ce2b17349497c07112ff5e408ef8c3122c3e950dc93c395b21124591";
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private GameObject content;
    [SerializeField] private int maxLeader;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SettingsManager settingsManager;

    private int _playerScore;
    void Start()
    {
        ShowRatingZero();
        Load();
        ShowScore();
    }
    private void ShowRatingZero()
    {
        Mark_RatingLeader[] mark_ratingLeader = content.GetComponentsInChildren<Mark_RatingLeader>();
        int indexer = 0;
        Image image;
        for (int i = 0; i < mark_ratingLeader.Length; i++)
        {
            image = mark_ratingLeader[i].gameObject.GetComponent<Image>();
            if (indexer == 0) 
            {
                image.sprite = sprites[0];
                indexer++;
            }
            else if (indexer == 1)
            {
                image.sprite = sprites[1];
                indexer++;
            }
            else
            {
                image.sprite = sprites[2];
                indexer = 0;
            }
            if (saveManager.Langeage == Language.Russian)
                mark_ratingLeader[i].gameObject.GetComponentsInChildren<TMP_Text>()[0].text = $"{i + 1}. Загрузка";
            if (saveManager.Langeage == Language.English)
                mark_ratingLeader[i].gameObject.GetComponentsInChildren<TMP_Text>()[0].text = $"{i + 1}. Loading";
        }
    }
    private void ShowScore()
    {
        _playerScoreText.text = "Твой счет: " + saveManager.Score;
    }
    public void AddPlayerScore()
    {
        saveManager.Score++;
        _playerScoreText.text = "Твой счет: " + saveManager.Score;
    }
    public void Load() => LeaderboardCreator.GetLeaderboard(_leaderboardPublicKey, OnLeaderboardLoaded);
    public void LoadUsersName() => LeaderboardCreator.GetLeaderboard(_leaderboardPublicKey, LoadUsersNames);
    private void LoadUsersNames(Entry[] entries) 
    {
        settingsManager.usersName = new string[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            settingsManager.usersName[i] = entries[i].Username;
        }
    }
    private void OnLeaderboardLoaded(Entry[] entries)
    {
        Entry[] leaderEntry = new Entry[50];
        Mark_RatingLeader[] leader = content.GetComponentsInChildren<Mark_RatingLeader>();
        GameObject[] leaderObj = new GameObject[leader.Length];
        for (int i = 0; i < leader.Length; i++)
        {
            leaderObj[i] = leader[i].gameObject;
        }
        foreach (var entryField in leaderObj)
        {
            entryField.GetComponentsInChildren<TMP_Text>()[0].text = "";
            entryField.GetComponentsInChildren<TMP_Text>()[1].text = "";
        }
        for (int i = 0; i < entries.Length; i++)
        {
            if (i == maxLeader) return;
            if (entries[i].Username == saveManager.UserName)
                leaderObj[i].GetComponentsInChildren<TMP_Text>()[0].text = $"{i + 1}. Вы";
            else
                leaderObj[i].GetComponentsInChildren<TMP_Text>()[0].text = $"{i + 1}. {entries[i].Username}";
            leaderObj[i].GetComponentsInChildren<TMP_Text>()[1].text = $"{entries[i].Score}";
        }
        for (int i = 0; i < entries.Length; i++)
        {

        }
    }
    public void Submit()
    {

        LeaderboardCreator.UploadNewEntry(_leaderboardPublicKey, saveManager.UserName, saveManager.Score, OnUploadComplete);

    }
    private void OnUploadComplete(bool success)
    {
        if (success) Load();
    }
}
