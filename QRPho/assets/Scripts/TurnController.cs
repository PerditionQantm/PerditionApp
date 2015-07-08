using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnController : MonoBehaviour {

	public FSM_Core<TurnController> FSM;

	public Text txtInfo;

	// Use this for initialization
	void Start () {
		FSM = new FSM_Core<TurnController>();
		FSM.Init();
		FSM.Config(this, new SelectionPhase());

		FSM.PushState(new ActionPhase());
		FSM.PushState(new MovementPhase());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			Debug.Log("Before: " + FSM.ToString());
			FSM.DropToBottom();
			Debug.Log("After: " + FSM.ToString());
		}

		txtInfo.text = FSM.PeekTop().ToString();
	}

	void LateUpdate() {
		FSM.Update();
	}
}
