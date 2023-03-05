using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    private LevelManager levelManager;
    [SerializeField] private float waitForSeconds;
    [SerializeField] private GameObject yesIndicator, target;
    private float time;
    private bool isVictory;
    // Start is called before the first frame update
    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        levelManager.NotifyClick += ZeroTime;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > waitForSeconds && !isVictory)
        {
            Instantiate(yesIndicator, target.transform);
            levelManager.Victory();
            levelManager.useVictoryTry();
            levelManager.NotifyClick -= ZeroTime;
            isVictory = true;
        }
    }

    private IEnumerator WaitForVictory(float wait)
    {
        yield return new WaitForSeconds(wait);
        Instantiate(yesIndicator, target.transform);
        levelManager.Victory();
        levelManager.useVictoryTry();
    }
    public void ZeroTime()
    {
        time = 0;
    }
}
