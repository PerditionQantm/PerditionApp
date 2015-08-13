using UnityEngine;
using System.Collections;

public class PanelMainMenu : MonoBehaviour, IPanelControllable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnOpen() {
		Debug.Log ("Main menu was opened!");
	}

	public void OnClose() {
		Debug.Log ("Main menu was closed.");
	}
}
