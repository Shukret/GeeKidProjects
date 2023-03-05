using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTarget : MonoBehaviour
{
    private ItemSlot itemSlot;

    private void Awake()
    {
        itemSlot = GetComponent<ItemSlot>();
        itemSlot.Notify += Delete;
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
