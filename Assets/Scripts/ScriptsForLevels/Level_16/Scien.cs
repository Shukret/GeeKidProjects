using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scien : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;
    [SerializeField] private Sprite sprite;
    // Start is called before the first frame update
    void Awake()
    {
        itemSlot.Notify += newSprite;
    }

    private void newSprite()
    {
        GetComponent<Image>().sprite = sprite;
    }
}
