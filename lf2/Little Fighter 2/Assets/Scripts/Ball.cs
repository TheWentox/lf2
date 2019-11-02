using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public Rigidbody2D rb;


    void Start()
    {
        rb.velocity = transform.right * ballSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
    }
}
