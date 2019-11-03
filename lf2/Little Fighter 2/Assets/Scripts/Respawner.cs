using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    RespawnController rc;

    private Vector3 oldPosition;
    private Vector3 oldScale;

    // Start is called before the first frame update
    void Start()
    {
        rc = GameObject.FindGameObjectWithTag("GameController").
                 GetComponent<RespawnController>();
        rc.Register(this);

        oldPosition = this.GetComponent<Transform>().position;
        oldScale = this.GetComponent<Transform>().localScale;
    }

    public void Respawn()
    {
        Debug.Log(this + "RESPAWNING");
        this.GetComponent<Transform>().position = oldPosition;
        this.GetComponent<Transform>().localScale = oldScale;
        //this.GetComponent<EnemyDestroyer>().mana = 1.0f;
        //this.GetComponent<EnemyDestroyer>().SetManaBar(1.0f);
        //this.GetComponent<EnemyDestroyer>().health = 1.0f;
        //this.GetComponent<EnemyDestroyer>().SetHealthBar(1.0f);
    }
}
