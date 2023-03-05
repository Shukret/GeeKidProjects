using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    private int count = 0;
    private LevelManager levelManager;
    [SerializeField] private float timeDown;
    [SerializeField] private GameObject yesIndicator, noIndicator, target;
    private float time;

    private void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }
    public void ButtonDown()
    {
        count++;
        if (count >=5)
        {
            levelManager.Victory();
            levelManager.useVictoryTry();
            Instantiate(yesIndicator, target.transform);
            Destroy(gameObject);
            

        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeDown)
        {
            time = 0;
            if (count > 0 && count < 5)
            {
                levelManager.useTry();
                Instantiate(noIndicator, transform);
            }
            count = 0;
        }
    }
}
