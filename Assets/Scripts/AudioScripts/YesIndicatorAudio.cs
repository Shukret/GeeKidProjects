using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesIndicatorAudio : MonoBehaviour
{
   
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().audioYesIndicator.Play();
    }

}
