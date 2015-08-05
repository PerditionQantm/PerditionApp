using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class DiceRollBasic : MonoBehaviour {

	public AudioSource asDiceRoll;

	public string sResults;
	public Text txtAP;

	private int[] a_iDice;
	public int iDiceAmount = 6;
	public int iSuccessThreshold = 2;

	public bool bDoublePerfectSuccess = true;

	// Use this for initialization
	void Start () {
		ResetDice(iDiceAmount);
	}

	public void ResetDice(int amount) {
		iDiceAmount = amount;
		a_iDice = new int[iDiceAmount];
	}
	
	// Update is called once per frame
	void Update () {
		sResults = "Results: ";
		for (int i = 0; i < a_iDice.Length - 1; i++) {
			if (a_iDice[i] < iSuccessThreshold) {
				sResults += " <color=red>" + a_iDice[i].ToString() + "</color>";
			}
			else {
				if (bDoublePerfectSuccess && a_iDice[i] == 6) {
					sResults += " <color=yellow>" + a_iDice[i].ToString() + "</color>";
				}
				else {
					sResults += " <color=white>" + a_iDice[i].ToString() + "</color>";
				}
			}
		}
	}

	public void Roll(int amount, bool bonus = false) {
		asDiceRoll.Play();

		if (bonus) {
			ResetDice(amount + 1);
		}
		else {
			ResetDice(amount);
		}

		for (int i = 0; i < iDiceAmount; i++) {
			a_iDice[i] = Random.Range(1, 7);
		}
	}

	public int GetDoubleSuccesses() {
		int j = 0;
		
		for (int i = 0; i < iDiceAmount; i++) {
			if (a_iDice[i] == 6 && bDoublePerfectSuccess) {
				j++;
			}
		}
		
		return j;
	}

	public int GetSuccesses() {
		int j = 0;
		
		for (int i = 0; i < iDiceAmount - 1; i++) {
			if (a_iDice[i] >= iSuccessThreshold) {
				if (a_iDice[i] == 6 && bDoublePerfectSuccess) {
					j += 2;
				}
				else {
					j++;
				}
			}
		}
		
		return j;
	}

	public int GetFailures() {
		int j = 0;
		
		for (int i = 0; i < iDiceAmount; i++) {
			if (a_iDice[i] < iSuccessThreshold) {
				j++;
			}
		}
		
		return j;
	}

	public int GetEpicFailures() {
		int j = 0;

		for (int i = 0; i < iDiceAmount; i++) {
			if (a_iDice[i] <= 1) {
				j++;
			}
		}

		return j;
	}
}
