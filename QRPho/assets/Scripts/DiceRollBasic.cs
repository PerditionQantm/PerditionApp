using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class DiceRollBasic : MonoBehaviour {

	public AudioSource asDiceRoll;

	public Text txtOutput;

	List<int> l_iDice;
	public int iDiceAmount = 6;

	// Use this for initialization
	void Start () {
		l_iDice = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {
		txtOutput.text = "Results: ";
		foreach (int die in l_iDice) {
			txtOutput.text += " " + die.ToString();
		}
	}


}
