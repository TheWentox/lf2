using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    RespawnController rc;

    private Vector3 oldPosition;
    private bool oldActiveness;
    private Vector3 oldScale;

    // Start is called before the first frame update
    void Start()
    {
        rc = GameObject.FindGameObjectWithTag("GameController").
                 GetComponent<RespawnController>();

        rc.register(this);

        oldPosition = this.GetComponent<Transform>().position;
        oldActiveness = this.gameObject.activeSelf;
        oldScale = this.GetComponent<Transform>().localScale;
    }

    public void respawn()
    {
        this.GetComponent<Transform>().position = oldPosition;
        this.gameObject.SetActive(oldActiveness);
        this.GetComponent<Transform>().localScale = oldScale;
    }
}
