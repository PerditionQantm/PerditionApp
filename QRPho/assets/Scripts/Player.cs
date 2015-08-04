using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;


public class Player : MonoBehaviour
{
	public Text txtDebugList;
	public Text txtAP;
	public Text txtResults;
	public Text txtDice;

	public int iActionPoints = 0;
	public int iDeceptionPoints = 0;
	public int iEvidence = 0;
	public List<GameItem> l_items;

	public float fIntuitionSensingScale = 0.0f;
	public float fPerceptionJudgingScale = 0.0f;
	public float fFeelingThinkingScale = 0.0f;
	public float fIntroversionExtraversionScale = 0.0f;

	public DiceRollBasic diceRoller;
	public AudioSource asDiceRoll;

	void Start() {
		l_items = new List<GameItem>();
		diceRoller.asDiceRoll = asDiceRoll;
		diceRoller.iDiceAmount = 4;
		diceRoller.txtAP = txtAP;
		diceRoller.txtResults = txtDice;
	}

	void Update() {
		//iItemCount = plyInv.l_items.Count;
	}

	public void ClearAP() {
		iActionPoints = 0;
	}
}
