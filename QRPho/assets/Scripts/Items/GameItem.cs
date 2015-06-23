using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GAME_ITEMS {
	NONE = 0,
	BELL,
	BOOK,
	CANDLE,
	AXE,
	KNIFE,
	ROPE,
	TEDDY,
	SAMPLE
}

public enum GAME_ATTITUDE {
	NONE = 0,
	DYNAMIC,
	STATIC,
	PASSIVE,
	AGGRESSIVE
}

public class GameItem {

	public GAME_ITEMS itemType;

	public string sName;
	public string sDescription;

	public string sDynamicString;
	public string sStaticString;
	public string sPassiveString;
	public string sAggressiveString;


	//N
	[Tooltip("Intuition (N, Subjective/Deductive)")]
	public float fIntuition;
	//F
	[Tooltip("Feeling (F, Subjective/Inductive)")]
	public float fFeeling;
	//S
	[Tooltip("Sensing (S, Subjective/Deductive)")]
	public float fSensing;
	//T
	[Tooltip("Thinking (T, Subjective/Inductive)")]
	public float fThinking;
	//P
	[Tooltip("Perception (P, Objective/Deductive)")]
	public float fPerception;
	//I
	[Tooltip("Introversion (I, Objective/Inductive)")]
	public float fIntroversion;
	//J
	[Tooltip("Judging (J, Objective/Deductive)")]
	public float fJudging;
	//E
	[Tooltip("Extraversion (E, Objective/Inductive)")]
	public float fExtraversion;

	public GameItem() {
		//
	}
}
