using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCkick : MonoBehaviour
{
    private LevelManager levelManager;
    [SerializeField] private bool isVictory;
    [SerializeField] private GameObject yesIndicator, noIndicator;
    // Start is called before the first frame update
    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        if (isVictory)
        {
            GetComponent<Button>().onClick.AddListener(levelManager.Victory);
            GetComponent<Button>().onClick.AddListener(CreateYesIndicator);
            GetComponent<Button>().onClick.AddListener(BlockButtonClick);
            levelManager.useVictoryTry();
        }
        
        else GetComponent<Button>().onClick.AddListener(NoVictory);
    }

    // Update is called once per frame
    
    private void NoVictory()
    {
        Instantiate(noIndicator, transform);
        levelManager.useTry();
    }
    private void CreateYesIndicator()
    {
        Instantiate(yesIndicator, transform);
    }
    private void BlockButtonClick()
    {

        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
}
