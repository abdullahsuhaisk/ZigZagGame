using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnvisible : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 fark = GameObject.Find("Player").transform.position - transform.position;
        float screen = Camera.main.orthographicSize;

        if (fark.z > screen+2) Destroy(gameObject);
        //Ezberle
		
	}
}
