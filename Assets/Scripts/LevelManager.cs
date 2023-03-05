using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public delegate void ClickButton();
    public event ClickButton NotifyClick;
    [SerializeField] private string[] clueText, messages, missionDesc;
    [SerializeField] private GameObject levelsPanel, messagePanel, settingsPanel, selectLevelsPanel, cluePanel, ratingPanel, inputUserNamePanel;
    [SerializeField] private TMP_Text numberLevels, clueTextPlace, ideasCounter, textMessage, textMission;
    [SerializeField] private Button buttonNext;
    [SerializeField] private GameObject conten;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int maxLevel, maxCountTry;
    [SerializeField] private GameObject targetSpawn;
    [SerializeField] private Color[] colors;
    [SerializeField] private LeaderboardShowcase LeaderboardShowcase;
    
    private GameObject useLevel;
    private int useLevelNumber;

    private Button[] buttonsComponents;
    private Star[] starsComponents;
    private Lock[] locksComponents;
    private Block[] blocksComponents;

    public List<GameObject> prefabList;
    
    public void addClue(int removeIdeas)
    {
        NotifyClick?.Invoke();
        if (cluePanel.active == true)
        {
            cluePanel.SetActive(false);
        }
        else
        {
            if (saveManager.isClueOpen[useLevelNumber - 1])
            {
                cluePanel.SetActive(true);
                clueTextPlace.text = clueText[useLevelNumber - 1];
            }
            else
            {
                if (saveManager.ideas < removeIdeas)
                {
                    //Предлагаем купить идеи
                }
                else
                {
                    saveManager.ideas -= removeIdeas;
                    UpdateIdeas();
                    cluePanel.SetActive(true);
                    clueTextPlace.text = clueText[useLevelNumber - 1];
                    saveManager.isClueOpen[useLevelNumber - 1] = true;
                }
            }
        }
        
    }
    public void addIdeas(int countIdeas)
    {
        NotifyClick?.Invoke();
        saveManager.ideas += countIdeas;
        UpdateIdeas();
    }
    public void SkipLevel(int removeIdeas)
    {
        NotifyClick?.Invoke();
        if (saveManager.ideas < removeIdeas)
        {
            //Предлагаем купить
        }
        else
        {
            if (saveManager.lastLevel == useLevelNumber)
            {
                saveManager.ideas -= removeIdeas;
                Victory();
                UpdateIdeas();
                saveManager.countTry[useLevelNumber - 1] = maxCountTry;
            }
            
        }    
    }
    public void UpdateIdeas()
    {
        ideasCounter.text = saveManager.ideas.ToString();
    }
    public void OffAllPanel()
    {
        selectLevelsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        levelsPanel.SetActive(false);
        messagePanel.SetActive(false);
        cluePanel.SetActive(false);
        ratingPanel.SetActive(false);
        inputUserNamePanel.SetActive(false);
    }
    public void Victory()
    {
        StartCoroutine(WaitVictory(1f));
    }
    public void NextLevel()
    {
        Destroy(useLevel);
        if (maxLevel < useLevelNumber)
            ToSelectLevels();
        else
        {
            Spawn(useLevelNumber);
        }
        
    }

    private IEnumerator WaitVictory(float time)
    {
        yield return new WaitForSeconds(time);

        messagePanel.SetActive(true);
        textMessage.text = messages[useLevelNumber - 1];
        useLevelNumber++;
        if(useLevelNumber > saveManager.lastLevel) saveManager.lastLevel++;     
        buttonNext.onClick.RemoveAllListeners();
        buttonNext.onClick.AddListener(NextLevel);
    }
    private void OnEnable()
    {
        UpdateIdeas();
    }
    public void Awake()
    {

        if (saveManager.lastLevel > maxLevel) ToSelectLevels();
        else
        {
            OffAllPanel();
            Spawn(saveManager.lastLevel);
        }

    }
    private void ShowSelectLevels()
    {
        buttonsComponents = conten.GetComponentsInChildren<Button>();
        starsComponents = conten.GetComponentsInChildren<Star>();
        locksComponents = conten.GetComponentsInChildren<Lock>();
        blocksComponents = conten.GetComponentsInChildren<Block>();
        int indexer = 1;

        for (int i = 0; i < buttonsComponents.Length; i++)
        {
            buttonsComponents[i].gameObject.GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();
            Image image = buttonsComponents[i].gameObject.GetComponent<Image>();
            TMP_Text text = buttonsComponents[i].gameObject.GetComponentInChildren<TMP_Text>();
            text.fontSize = 180;
            if (indexer == 1)
            {
                image.sprite = sprites[0];
                text.color = colors[0];
                indexer++;
            }              
            else if (indexer == 2)
            {
                image.sprite = sprites[1];
                text.color = colors[1];
                indexer++;
            }               
            else
            {
                image.sprite = sprites[2];
                text.color = colors[2];
                indexer = 1;
            }
                
            if (i + 1 < saveManager.lastLevel)
            {
                blocksComponents[i].gameObject.SetActive(false);
                locksComponents[i].gameObject.SetActive(false);
            }
            if (i + 1 == saveManager.lastLevel)
            {
                blocksComponents[i].gameObject.SetActive(false);
                locksComponents[i].gameObject.SetActive(false);
                starsComponents[i].gameObject.SetActive(false);
            }
            if (i + 1 > saveManager.lastLevel)
            {
                starsComponents[i].gameObject.SetActive(false);
            }
        }
    }
    private void CloseSelectLevels()
    {
        if (buttonsComponents != null)
        {
            for (int i = 0; i < buttonsComponents.Length; i++)
            {
                blocksComponents[i].gameObject.SetActive(true);
                locksComponents[i].gameObject.SetActive(true);
                starsComponents[i].gameObject.SetActive(true);
            }
        }
        
    }
    public void ToSelectLevels()
    {
        OffAllPanel();
        selectLevelsPanel.SetActive(true);
        ShowSelectLevels();
    }
    public void ToSettings()
    {
        OffAllPanel();
        settingsPanel.SetActive(true);
    }
    public void ToLevel()
    {
        OffAllPanel();
        CloseSelectLevels();
        if (useLevel == null)//Если у нас панель уровня пуста
        {
            if (saveManager.lastLevel > maxLevel) Spawn(maxLevel);
            else Spawn(saveManager.lastLevel);
        }
        else
        {
            levelsPanel.SetActive(true);
            Spawn(useLevelNumber);
        }
            
    }
    public void RepeatLevel()
    {
        Spawn(useLevelNumber);
    }

    public void Spawn(int numberLevel)
    {
        OffAllPanel();
        CloseSelectLevels();//включаем все звезды и замки чтобы потом сработал GetComponent
        useLevelNumber = numberLevel;
        if (useLevel != null) Destroy(useLevel);
        int index = numberLevel - 1;
        levelsPanel.SetActive(true);
        useLevel = Instantiate(prefabList[index], targetSpawn.transform);
        numberLevels.text = "УРОВЕНЬ " + numberLevel.ToString();
        textMission.text = missionDesc[index];

    }
    public void useTry()
    {
        if (saveManager.countTry[useLevelNumber - 1] < maxCountTry)
        {
            saveManager.countTry[useLevelNumber - 1]++;     
        }
    }
    public void useVictoryTry()
    {
        if (saveManager.countTry[useLevelNumber - 1] < maxCountTry)
        {
            LeaderboardShowcase.AddPlayerScore();
            saveManager.countTry[useLevelNumber - 1] = maxCountTry;
        }
    }
}
