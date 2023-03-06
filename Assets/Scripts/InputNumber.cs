using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputNumber : MonoBehaviour
{
    [SerializeField] public GameObject[] buttonsNumbers;
    [SerializeField] public TMP_Text textInput;
    [SerializeField] public string trueNumber;
    [SerializeField] private GameObject yesIndicator, noIndicator;
    private bool isVictory;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        for (int i = 0; i < buttonsNumbers.Length; i++)
        {
            buttonsNumbers[i].GetComponentInChildren<TMP_Text>().fontSize = 100;
            buttonsNumbers[i].GetComponentInChildren<TMP_Text>().text = i.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InputNumbers(string numbers)
    {
        if (textInput.text.Length < 6)
            textInput.text += numbers;
    }
    public void Input()
    {
        if (!isVictory)
        {
            if (textInput.text == trueNumber)
            {
                levelManager.Victory();
                levelManager.useVictoryTry();
                Instantiate(yesIndicator, textInput.gameObject.transform);
                isVictory = true;
            }
            else
            {
                Instantiate(noIndicator, textInput.gameObject.transform);
                levelManager.useTry();
            }
        }          
    }
    public void Delete()
    {
        textInput.text = "";
    }
}
