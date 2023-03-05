using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragColor : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool isRemove;
    // Start is called before the first frame update
    void Awake()
    {
        itemSlot.Notify += NextColor;
    }
    private void NextColor()
    {
        Image image = itemSlot.GetComponent<Image>();
        image.sprite = sprite;
        GetComponent<Image>().sprite = sprite;
        Destroy(gameObject);
    }
}
