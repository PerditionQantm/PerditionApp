using UnityEngine;
using System.Collections;

public class SearchPhase : FSM_State<TurnController> {

	public string sDisplayName = "Search Phase";
	
	public override void Begin (TurnController obj) {
		//Reset Turn Variables
	}
	
	public override void Resume (TurnController obj) {
		//Reset Turn Variables
	}
	
	public override void Run (TurnController obj) {
		//Wait
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			obj.FSM.PopUntilBottom();
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
