using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public List<Respawner> respawnableObjects;

    void Awake()
    {
        respawnableObjects = new List<Respawner>();
    }

    public void Register(Respawner obj)
    {
        respawnableObjects.Add(obj);
    }

    public void Respawn()
    {
        Debug.Log("Repawning....");
        foreach(Respawner obj in respawnableObjects)
        {
            obj.Respawn();
        }
    }
}
