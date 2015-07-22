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
	}
	
	// Update is called once per frame
	void Update () {
		txtInfo.text = FSM.PeekTop().ToString();
	}

	void LateUpdate() {
		FSM.Update();
	}
}
