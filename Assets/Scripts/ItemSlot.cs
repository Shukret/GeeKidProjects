using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject yesIndicator, target;
    public delegate void EventHandler();
    public event EventHandler Notify;
    public bool isUse;

    private void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !isUse)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            isUse = true;
            eventData.pointerDrag.GetComponent<DragDrop>().itemslot = this;
            if (eventData.pointerDrag.GetComponent<DragDrop>().isTrue)
            {
                levelManager.Victory();
                levelManager.useVictoryTry();
                Notify?.Invoke();
                Instantiate(yesIndicator, target.transform);
            }
        }
    }
    private void OnMouseEnter()
    {
        Debug.Log("Коснулись");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
