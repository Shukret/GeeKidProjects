using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : MonoBehaviour
{
    [SerializeField] private string targetTextTag;
    [SerializeField] private Vector3 rotation;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject target = GameObject.FindGameObjectWithTag(targetTextTag);
        transform.position = target.transform.position;
        transform.rotation = Quaternion.Euler(rotation);
    }

}
