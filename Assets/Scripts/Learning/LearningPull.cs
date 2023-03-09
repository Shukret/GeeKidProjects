using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LearningPull : MonoBehaviour
{
    [SerializeField] private GameObject pizza;
    [SerializeField] private GameObject[] forDelete;
    [SerializeField] private Vector3 vector;
    [SerializeField] private float timeMove;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(vector, timeMove).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pizza.transform.position = transform.position;
    }
    public void DeleteLearning()
    {
        for (int i = 0; i < forDelete.Length; i++)
        {
            Destroy(forDelete[i]);
        }
        Destroy(gameObject);
    }
}
