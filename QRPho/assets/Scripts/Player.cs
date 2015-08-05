using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;


public class Player : MonoBehaviour {

	public Text txtAP;
	public Text txtDice;
	public Text txtDeception;
	public Text txtLastRoll;
	public Text txtSuccess;

	public bool bUseDeception {get; set;}

	public int iActionPoints = 0;
	public int iDeceptionPoints = 0;
	public int iEvidence = 0;
	public int iDice = 4;
	public List<GameItem> l_items;

	public int iLastSuccess;

	public float fIntuitionSensingScale = 0.0f;
	public float fPerceptionJudgingScale = 0.0f;
	public float fFeelingThinkingScale = 0.0f;
	public float fIntroversionExtraversionScale = 0.0f;

	public DiceRollBasic diceRoller;

	void Start() {
		l_items = new List<GameItem>();
		
		diceRoller.iDiceAmount = iDice;
	}

	void Update() {
		txtAP.text = "AP: " + iActionPoints.ToString();
		txtDice.text = "Dice:  " + iDice.ToString();
		txtDeception.text = "DP: " + iDeceptionPoints.ToString();
		txtLastRoll.text = "Result: " + diceRoller.sResults;
		txtSuccess.text = "Successes: " + iLastSuccess.ToString();
	}

	public void ClearAP() {
		iActionPoints = 0;
	}

	public void RollForItem() {
		if (iDeceptionPoints > 0) {
			diceRoller.Roll(iDice, bUseDeception);
			iDeceptionPoints--;
		}
		else {
			diceRoller.Roll(iDice);
		}
		
		iLastSuccess = diceRoller.GetSuccesses();
	}
}
