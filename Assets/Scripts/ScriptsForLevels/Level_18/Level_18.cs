using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_18 : MonoBehaviour
{
    [SerializeField] private AccelerationController accelerationController;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Awake()
    {
        accelerationController.VictoryNitify += Coup;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Coup()
    {
        rectTransform.rotation = Quaternion.Euler(0f, 0f, 180f);
    }
}
