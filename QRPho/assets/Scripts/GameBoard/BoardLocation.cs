using UnityEngine;
using Deception;
using System.Collections;

public class BoardLocation {

	public string sName = "Room";
	public ROOM_EXIT_FLAGS iExits;
	public bool bExterior;

	public Sprite sprTile = null;
	
	public BoardLocation(string name, bool outside, ROOM_EXIT_FLAGS exits, Sprite appearance = null) {
		sName = name;
		iExits = exits;
		bExterior = outside;
		sprTile = appearance;
	}
}
