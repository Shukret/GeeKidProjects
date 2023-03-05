using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCollider : MonoBehaviour
{
    private LevelManager levelManager;
    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        levelManager.Victory();
        Destroy(gameObject);
    }
}
