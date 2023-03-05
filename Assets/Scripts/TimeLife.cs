using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLife : MonoBehaviour
{
    [SerializeField] private float timeLife;
    private float time;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeLife)
        {
            Destroy(gameObject);
        }    
    }
}
