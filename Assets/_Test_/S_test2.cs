using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_test2 : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
        //rb.AddForce(transform.right * 0.1f, ForceMode2D.Impulse);
        rb.velocity = new Vector2(-1f, rb.velocity.y);
    }
}
