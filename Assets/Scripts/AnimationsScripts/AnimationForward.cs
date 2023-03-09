using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationForward : MonoBehaviour
{
    [SerializeField] Vector3 vector = new Vector3(1.5f, 1.5f, 1.5f);
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(vector, 2f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
