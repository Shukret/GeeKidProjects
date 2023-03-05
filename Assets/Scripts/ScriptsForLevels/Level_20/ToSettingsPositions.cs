using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSettingsPositions : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 startPosition;
    public float distance;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.localPosition;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    public void TryToSettings()
    {
        distance = Vector3.Distance(startPosition, rectTransform.localPosition);
        if (distance < 1)
        {
            levelManager.ToSettings();
        }
    }
}
