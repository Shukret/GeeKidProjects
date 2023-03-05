using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationsIndicator : MonoBehaviour
{
    [SerializeField] private float timeScaler;
    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
        transform.DOScale(new Vector3(1f, 1f, 1f), timeScaler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
