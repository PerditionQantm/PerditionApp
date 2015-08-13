using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Photon;

using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class RoomItem
{
	public RoomInfo info;
	public Button.ButtonClickedEvent thingToDo;
}

public class RoomList : PunBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
