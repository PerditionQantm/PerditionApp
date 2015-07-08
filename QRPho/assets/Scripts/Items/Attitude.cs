using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attitude {

	public string s_Name = "None";
	public string s_Description = "Meh";

//	//N
//	[Tooltip("Intuition (N, Subjective/Deductive)")]
//	public float fIntuition;
//	//F
//	[Tooltip("Feeling (F, Subjective/Inductive)")]
//	public float fFeeling;
//	//S
//	[Tooltip("Sensing (S, Subjective/Deductive)")]
//	public float fSensing;
//	//T
//	[Tooltip("Thinking (T, Subjective/Inductive)")]
//	public float fThinking;
//	//P
//	[Tooltip("Perception (P, Objective/Deductive)")]
//	public float fPerception;
//	//I
//	[Tooltip("Introversion (I, Objective/Inductive)")]
//	public float fIntroversion;
//	//J
//	[Tooltip("Judging (J, Objective/Deductive)")]
//	public float fJudging;
//	//E
//	[Tooltip("Extraversion (E, Objective/Inductive)")]
//	public float fExtraversion;

	public Dictionary<string, float> dMyersBriggsLookup;

	public Attitude() {
		//
	}

	public Attitude(string name, string desc) {
		s_Name = name;
		s_Description = desc;

		dMyersBriggsLookup = new Dictionary<string, float>();
		dMyersBriggsLookup.Add("intuition", 0.0f);
		dMyersBriggsLookup.Add("feeling", 0.0f);
		dMyersBriggsLookup.Add("sensing", 0.0f);
		dMyersBriggsLookup.Add("thinking", 0.0f);
		dMyersBriggsLookup.Add("perception", 0.0f);
		dMyersBriggsLookup.Add("introversion", 0.0f);
		dMyersBriggsLookup.Add("judging", 0.0f);
		dMyersBriggsLookup.Add("extraversion", 0.0f);
	}
}
