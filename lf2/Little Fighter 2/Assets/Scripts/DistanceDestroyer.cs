using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDestroyer : MonoBehaviour
{
    private Vector3 startPosition;
    public float MaxDistance = 10;

    // Start is called before the first frame update
    void OnEnable()
    {
        startPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = GetComponent<Transform>().position;
        Vector3 movement = currentPos - startPosition;
        float distance = movement.magnitude;

        if(distance > MaxDistance)
        {
            this.gameObject.SetActive(false);
        }
    }
}
