using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

	public float speed = 0.05f;
	public Transform target;
    private Transform tr;

    public Vector3 offset;

    void Start()
    {
        tr = GetComponent<Transform>();
        offset = target.position - tr.position;
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (target) {
            Vector3 anchorPos = tr.position + offset;
            Vector3 movement = target.position - anchorPos;

            Vector3 newCamPos = tr.position + movement*speed;
            tr.position = newCamPos;
		}
	}
}
