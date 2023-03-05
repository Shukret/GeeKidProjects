using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOnEnableSettings : MonoBehaviour
{
    public delegate void OnEnableHandler();
    public event OnEnableHandler NotifyEnable;
    // Start is called before the first frame update
    void OnEnable()
    {
        NotifyEnable?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
