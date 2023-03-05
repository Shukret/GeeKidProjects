using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom_tuch : MonoBehaviour
{
    private Vector2 f0start, f1start;
    private RectTransform rt;
    [SerializeField] CanvasScaler canvasScaler;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();   
    }

    // Update is called once per frame
    void Update()
    {
        f0start = Input.GetTouch(0).position;
        f1start = Input.GetTouch(1).position;
        float distance = Vector2.Distance(f0start, f1start);
        rt.localScale = new Vector3(distance, distance, 1);

    }
}
