﻿using UnityEngine;
using System.Collections;

public class SelectionPhase : FSM_State<TurnController> {

	public string sDisplayName = "Selection Phase";
	
	public override void Begin (TurnController obj) {
		//Reset Turn Variables
	}
	
	public override void Resume (TurnController obj) {
		//Reset Turn Variables
	}
	
	public override void Run (TurnController obj) {
		//Wait
		if (Input.GetKeyDown(KeyCode.D)) {
			obj.FSM.PushState(new ActionPhase());
		}
	}
	
	public override void Pause (TurnController obj) {
		//Does nothing; to review
	}
	
	public override void End (TurnController obj) {
		//Does nothing; to review
	}

	public override string ToString() {
		return sDisplayName;
	}
}
