using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioIndicator : MonoBehaviour
{

    private SaveManager SaveManager;

    private void Awake()
    {
        SaveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
        if (SaveManager.IsAudioOn) GetComponent<AudioSource>().Play();
    }

}
