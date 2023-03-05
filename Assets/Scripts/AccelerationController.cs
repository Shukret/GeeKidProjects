using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

enum Action
{
    lnclineLeft,
    lnclineRight,
    lnclineForward,
    shake,
}
public class AccelerationController : MonoBehaviour
{
    public delegate void VictoryHandler();
    public event VictoryHandler VictoryNitify;
    private LevelManager levelManager;
    [SerializeField] private Action action;
    [SerializeField] private Text X, Y, Z;
    [SerializeField] private int numberShake;
    [SerializeField] private GameObject target, yesIndicator;
    private int counterShake;
    private bool isVictory = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 acc = Input.acceleration;
        if (action == Action.lnclineLeft && acc.x < -0.4f && !isVictory)
        {
            VictoryAcceleration();
        }
        if (action == Action.lnclineRight && acc.x > 0.4f && !isVictory)
        {
            VictoryAcceleration();
        }
        if (action == Action.shake && acc.sqrMagnitude > 5f && !isVictory)
        {
            counterShake++;
            if (counterShake >= numberShake)
            {
                VictoryAcceleration();
            }           
        }
        if (action == Action.lnclineForward && acc.y > 0.7f && !isVictory)
        {
            VictoryAcceleration();

        }
        if (X != null && Y != null && Z != null)
        {
            X.text = "X: " + acc.x.ToString();
            Y.text = "Y: " + acc.y.ToString();
            Z.text = "Z: " + acc.z.ToString();
        }
        
    }
    private void VictoryAcceleration()
    {
        levelManager.Victory();
        levelManager.useVictoryTry();
        VictoryNitify?.Invoke();
        levelManager.useVictoryTry();
        isVictory = true;
        Instantiate(yesIndicator, target.transform);
    }
}
