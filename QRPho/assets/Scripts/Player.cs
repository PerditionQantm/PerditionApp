using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Player : MonoBehaviour {

	//public Inventory plyInv;
	public int iItemCount = 0;
	public int iLastItemCount = 0;

	public Text txtDebugList;

//	//N
//	[Tooltip("Intuition (N, Subjective/Deductive)")]
//	public float fTotalIntuition;
//	//F
//	[Tooltip("Feeling (F, Subjective/Inductive)")]
//	public float fTotalFeeling;
//	//S
//	[Tooltip("Sensing (S, Subjective/Deductive)")]
//	public float fTotalSensing;
//	//T
//	[Tooltip("Thinking (T, Subjective/Inductive)")]
//	public float fTotalThinking;
//	//P
//	[Tooltip("Perception (P, Objective/Deductive)")]
//	public float fTotalPerception;
//	//I
//	[Tooltip("Introversion (I, Objective/Inductive)")]
//	public float fTotalIntroversion;
//	//J
//	[Tooltip("Judging (J, Objective/Deductive)")]
//	public float fTotalJudging;
//	//E
//	[Tooltip("Extraversion (E, Objective/Inductive)")]
//	public float fTotalExtraverson;

	public float fIntuitionSensingScale = 0.0f;
	public float fPerceptionJudgingScale = 0.0f;
	public float fFeelingThinkingScale = 0.0f;
	public float fIntroversionExtraversionScale = 0.0f;

	// Use this for initialization
	void Start () {
		//
	}
	
	// Update is called once per frame
	void Update () {
		//iItemCount = plyInv.l_items.Count;

		if (iItemCount != iLastItemCount) {
			iLastItemCount = iItemCount;

			Recalculate();
			txtDebugList.text = "Intuition/Sensing: " + fIntuitionSensingScale.ToString() +
					"\nPerception/Judging: " + fPerceptionJudgingScale.ToString() +
					"\nFeeling/Thinking: " + fFeelingThinkingScale.ToString() +
					"\nIntroversion/Extraversion: " + fIntroversionExtraversionScale.ToString();
		}
	}

	public void Recalculate() {
//		foreach (GameItem item in plyInv.l_items) {
//			fIntuitionSensingScale += item.fIntuition;
//			fIntuitionSensingScale -= item.fSensing;
//
//			fPerceptionJudgingScale += item.fPerception;
//			fPerceptionJudgingScale -= item.fJudging;
//
//			fFeelingThinkingScale += item.fFeeling;
//			fFeelingThinkingScale -= item.fThinking;
//
//			fIntroversionExtraversionScale += item.fIntroversion;
//			fIntroversionExtraversionScale -= item.fExtraversion;
//		}
	}
}
