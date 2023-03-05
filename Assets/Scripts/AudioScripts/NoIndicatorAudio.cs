using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoIndicatorAudio : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().audioNoIndicator.Play();
    }
}
