using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed;
    float xMove = 0;
    float YMove = 0;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateDirVel();
    }

    void UpdateInput()
    {
        xMove = Input.GetAxis("Horizontal");
        YMove = Input.GetAxis("Vertical");
    }
    void UpdateDirVel()
    {
        Vector2 dir = new Vector2(xMove, YMove).normalized;

        rb.velocity = dir * speed;
    }
}
