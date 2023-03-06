using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiOndicatorVibration : MonoBehaviour
{
    private SaveManager saveManager;
    void Awake()
    {
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
        if (saveManager.isVibrationOn)
            Handheld.Vibrate();
    }

}
