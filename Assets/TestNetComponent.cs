using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestNetComponent : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		int a=3;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("IsClient: " + Network.isClient + isClient + NetworkClient.active);
        Debug.Log("IsServer: " + Network.isServer + isServer + NetworkServer.active);
        //Debug.Log("AT LEAST I WORK AS WELL");
        
    }
}
