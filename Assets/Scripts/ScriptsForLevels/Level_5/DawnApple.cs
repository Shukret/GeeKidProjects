using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DawnApple : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] private AccelerationController accController;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        accController.VictoryNitify += Down;
    }
    private void Down()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 10;
    }
}
