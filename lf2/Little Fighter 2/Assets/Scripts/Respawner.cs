using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    RespawnController rc;

    private Vector3 oldPosition;
    private Vector3 oldScale;

    public EnemyDestroyer enemyDestroyer;

    // Start is called before the first frame update
    void Start()
    {
        rc = GameObject.FindGameObjectWithTag("GameController").
                 GetComponent<RespawnController>();
        rc.Register(this);

        oldPosition = transform.position;
        oldScale = transform.localScale;
    }

    public void Respawn()
    {
        Debug.Log(this + "RESPAWNING");
        transform.position = oldPosition;
        transform.localScale = oldScale;
    }
}
