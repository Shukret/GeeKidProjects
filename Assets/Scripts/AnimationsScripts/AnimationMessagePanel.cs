using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationMessagePanel : MonoBehaviour
{
    [SerializeField] private Transform _panel;
    [SerializeField] private float time;

 
    private void OnEnable()
    {
        _panel.localScale = new Vector3(0f, 0f, 0f);
        _panel.DOScale(new Vector3(1f, 1f, 1f), time);
    }
    

}
