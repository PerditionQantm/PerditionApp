using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.Networking;

public class GameClient : MonoBehaviour {

	NetworkClient netClient;

	// Use this for initialization
	void Start() {
		
	}

	public void ConnectToServer() {
		netClient.Connect("localhost", 7777);
	}
	
	// Update is called once per frame
	void Update() {
	
	}
}
