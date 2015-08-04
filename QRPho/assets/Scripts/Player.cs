using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public enum HouseLocation
{
		NONE = -2,
		DEAD = -1,
		FRONTYARD,
		BACKYARD,
		HALL,
		STAIRWELL,
		LOUNGE,
		KITCHEN,
//DINING,
		MASTERBED,
		CHILDBED,
		BATHROOM,
		BALCONY,
}

public class Player : MonoBehaviour
{

		//public Inventory plyInv;
		public int iItemCount = 0;
		public int iLastItemCount = 0;

		public HouseLocation eLocation;
		public HouseLocation eNextMovement;

		public Text txtDebugList;

	public int iActionPoints;
	public int iDeceptionPoints;

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
		void Start ()
		{
				//
		}
	
		// Update is called once per frame
		void Update ()
		{
				//iItemCount = plyInv.l_items.Count;

				if (iItemCount != iLastItemCount) {
						iLastItemCount = iItemCount;

						Recalculate ();
						txtDebugList.text = "Intuition/Sensing: " + fIntuitionSensingScale.ToString () +
								"\nPerception/Judging: " + fPerceptionJudgingScale.ToString () +
								"\nFeeling/Thinking: " + fFeelingThinkingScale.ToString () +
								"\nIntroversion/Extraversion: " + fIntroversionExtraversionScale.ToString ();
				}
		}

		public void Recalculate ()
		{
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

		public void ConfirmRoom ()
		{
				eLocation = eNextMovement;
		}

		public static HouseLocation[] getPossibleMovements (HouseLocation room)
		{
				switch (room) {
				case HouseLocation.BACKYARD:
						{
								return new HouseLocation[]{HouseLocation.FRONTYARD, HouseLocation.HALL};
						}
				case HouseLocation.BALCONY:
						{
								return new HouseLocation[]{HouseLocation.CHILDBED, HouseLocation.MASTERBED};
						}
				case HouseLocation.BATHROOM:
						{
								return new HouseLocation[]{HouseLocation.MASTERBED, HouseLocation.STAIRWELL};
						}
				case HouseLocation.DEAD:
						{
								return new HouseLocation[]{};
						}
				case HouseLocation.FRONTYARD:
						{
								return new HouseLocation[]{HouseLocation.BACKYARD, HouseLocation.HALL};
						}
				case HouseLocation.HALL:
						{
								return new HouseLocation[] {
										HouseLocation.FRONTYARD,
										HouseLocation.BACKYARD,
										HouseLocation.LOUNGE,
										HouseLocation.KITCHEN,
										HouseLocation.STAIRWELL
								};
						}
				case HouseLocation.KITCHEN:
						{
								return new HouseLocation[]{HouseLocation.LOUNGE, HouseLocation.HALL};
						}
				case HouseLocation.LOUNGE:
						{
								return new HouseLocation[] {HouseLocation.HALL, HouseLocation.KITCHEN};
						}
				case HouseLocation.MASTERBED:
						{
								return new HouseLocation[] {HouseLocation.BALCONY, HouseLocation.BATHROOM, HouseLocation.CHILDBED};
						}
				case HouseLocation.STAIRWELL:
						{
								return new HouseLocation[] {
										HouseLocation.HALL,
										HouseLocation.MASTERBED,
										HouseLocation.CHILDBED,
										HouseLocation.BATHROOM
								};
						}
				default:
						{
								return null;
						}
				}
		}

		public static string[] getLocationNames (HouseLocation[] locations)
		{
				List<string> stringList = new List<string> ();
				foreach (HouseLocation loc in locations) {
						stringList.Add (loc.ToString ().ToLower ());
				}
				return stringList.ToArray ();
		}

	public void ClearAP() {
		iActionPoints = 0;
	}
}
