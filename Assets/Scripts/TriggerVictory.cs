using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVictory : MonoBehaviour
{
    private LevelManager levelManager;

    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.Victory();
    }
}
