using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int iPlayerHealth = 4;
	public int iPlayerActionPoints = 3;
	public int iPlayerDeceptionPoints = 2;
	public int iExtraDice = 0;
	public int iExtraAttackDice = 0;
	public int iExtraArrestDice = 0;
	public int iExtraInspectDice = 0;
	public int iExtraEscapeDice = 0;
	public bool bIsStartOfYourTurn = false;
	public bool bIsYourTurn = false;
	public bool bIsEndOfYourTurn = false;
	public bool bEvidenceFound = false;
	public bool bWitnessInterviewed = false;
	public bool bBodyInspected = false;
	public bool bAllCluesGathered = false;
	public bool bButcherSelected = false;
	public bool bSheriffSelected = false;
	public bool bBlacksmithSelected = false;
	public bool bChoiceSelected = false;
	public bool bRoleFound = false;

	public RectTransform rectClues;
	public RectTransform rectCriminalChoice;
	public RectTransform rectCluesStart;
	public RectTransform rectCluesEnd;
	private float fMoveTimer = 0;
	public Image imButcher;
	public Image imSheriff;
	public Image imBlacksmith;
	public Image imEvidence;
	public Image imWitness;
	public Image imBody;
	
	public Sprite sCheckedBox;

	private float fTimer = 1;

	public Text textHealth;
	public Text textActionPoints;
	public Text textDeceptionPoints;
	public Text textGoal;
	public Text textQRResult;
	public Text textTurnNumber;

	public int iTurnCounter = 1;

	public Inventory invItems;

	public BoardLocation boardloc;
	
	void Start ()
	{	
		//boardloc.
	}

	void Update ()
	{
		iPlayerHealth = Mathf.Clamp (iPlayerHealth, 0, 4);
		iPlayerActionPoints = Mathf.Clamp (iPlayerActionPoints, 0, 3);
		iPlayerDeceptionPoints = Mathf.Clamp (iPlayerDeceptionPoints, 0, 3);
		fMoveTimer = Mathf.Clamp (fMoveTimer, 0, 1);

		textHealth.text = "Health = " + iPlayerHealth + "";
		textActionPoints.text = "Action Points = " + iPlayerActionPoints + "";
		textDeceptionPoints.text = "Deception Points = " + iPlayerDeceptionPoints + "";

		if (Input.GetKeyDown(KeyCode.P))
		{
			textQRResult.text = "i:matchbook";
		}

		if (Input.GetKeyDown(KeyCode.O))
		{
			textQRResult.text = "i:butchersknife";
		}

		if (bEvidenceFound)
		{
			imEvidence.overrideSprite = sCheckedBox;
		}

		if (bWitnessInterviewed)
		{
			imWitness.overrideSprite = sCheckedBox;
		}

		if (bBodyInspected)
		{
			imBody.overrideSprite = sCheckedBox;
		}

		if (bEvidenceFound && bWitnessInterviewed && bBodyInspected && !bAllCluesGathered)
		{
			fMoveTimer += Time.deltaTime;
			rectClues.transform.position = Vector3.Lerp (rectCluesStart.transform.position,
			                                             rectCluesEnd.transform.position,
			                                             fMoveTimer);
			if (fMoveTimer >= 1)
			{
				textGoal.text = "Choose who you deduce the criminal is";
				bAllCluesGathered = true;
			}
		}

		if (bAllCluesGathered && !bChoiceSelected)
		{
			fMoveTimer -= Time.deltaTime;
			rectCriminalChoice.transform.position = Vector3.Lerp (rectCluesStart.transform.position,
			                                                      rectCluesEnd.transform.position,
			                                                      fMoveTimer);
		}

		if (bButcherSelected || bBlacksmithSelected || bSheriffSelected)
		{
			fMoveTimer += Time.deltaTime;
			rectCriminalChoice.transform.position = Vector3.Lerp (rectCluesStart.transform.position,
			                                                      rectCluesEnd.transform.position,
			                                                      fMoveTimer);
			if (fMoveTimer >= 1)
			{
				bRoleFound = true;
				textGoal.text = "You are the Prodigal Son";
			}
		}

		if (bIsStartOfYourTurn)
		{
			iPlayerActionPoints = 3;
		}

		if (bIsEndOfYourTurn)
		{
			fTimer -= Time.deltaTime;
			bIsYourTurn = false;
			iPlayerActionPoints = 0;

			if (fTimer <= 0)
			{
				bIsEndOfYourTurn = false;
			}
		}

		textTurnNumber.text = "Turn " + iTurnCounter.ToString();
	}

	public void NextTurn() {
		iTurnCounter++;
		bIsEndOfYourTurn = false;
		bIsYourTurn = false;
		bIsStartOfYourTurn = true;
	}

	public void ButcherButton ()
	{
		bButcherSelected = true;
		bChoiceSelected = true;
		imButcher.overrideSprite = sCheckedBox;
	}

	public void SheriffButton ()
	{
		bSheriffSelected = true;
		bChoiceSelected = true;
		imSheriff.overrideSprite = sCheckedBox;
	}

	public void BlacksmithButton ()
	{
		bBlacksmithSelected = true;
		bChoiceSelected = true;
		imBlacksmith.overrideSprite = sCheckedBox;
	}

}
