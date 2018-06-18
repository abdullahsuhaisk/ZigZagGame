using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = player.position - transform.position;
	}

    private void LateUpdate()
    {
        transform.position = player.position - offset;
    }
}
