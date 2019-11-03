using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public Rigidbody2D rb;
    public float damage = 0.2f;

    void OnEnable()
    {
        rb.velocity = transform.right * ballSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyDestroyer enemy = hitInfo.GetComponent<EnemyDestroyer>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        gameObject.SetActive(false);
    }
}
