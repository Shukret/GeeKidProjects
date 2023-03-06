using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;
    [SerializeField] private bool isRemove;
    // Start is called before the first frame update
    void Awake()
    {
        if (isRemove)
        {
            itemSlot = GetComponent<ItemSlot>();
            itemSlot.Notify += RemoveMethod;
        }
        
    }

    private void RemoveMethod()
    {
        Debug.Log("sdasd");
        Destroy(gameObject);
    }
}
