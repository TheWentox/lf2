using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Rocket")
        {
            col.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
