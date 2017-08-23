using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DummyMovement : MonoBehaviour {

    Vector3 startPos;
    float time = 0.0f;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (NetworkServer.active)
        {

            time += Time.deltaTime;
            transform.position = new Vector3(startPos.x, startPos.y + 3.0f*Mathf.Sin(time), startPos.z);
        }
	}
}
