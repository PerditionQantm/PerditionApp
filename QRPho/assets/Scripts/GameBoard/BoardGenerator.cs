using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardGenerator : MonoBehaviour {

	public List<BoardLocation> s_l_locations;

	// Use this for initialization
	void Start () {
		s_l_locations = new List<BoardLocation>();

//		BoardLocation loc = new BoardLocation();
//		loc.bExterior = false;
//		//loc.iExits;
//		s_l_locations.Add(loc);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
