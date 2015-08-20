using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiceCalculator : MonoBehaviour {

	public int iCurrentDiceAmount = 4;
	public int iTotalRollValue = 0;
	public int iRequiredRollValue = 5;

	public Text textRequiredValue;
	public Text textRolledValue;
	public Text textRollSuccessPrompt;
	public Button buRollDiceButton;

	private float fTimer = 1f;
	private bool bIsDiceBoardClosed = false;

	private int iPooledSearch = 0;
	private int iPooledSkill = 0;

	public bool bOpenedDiceRoller = false;
	public bool bAddUpDiceOnce = false;
	public bool bIsButtonPressed = false;
	public bool bIsDoneRolling = false;
	public bool bIsInspecting = false;
	public bool bIsSearching = false;
	public bool bIsOpenedScanner = false;
	public float fTimePassed = 2.0f;
	public bool bIsDoingSkill = false;
	public bool bIsAttacking = false;
	public bool bIsDefending = false;
	public bool bIsArresting = false;
	public bool bIsEscaping = false;

	public DiceRoller[] dice;

	public PlayerStats PlayerStats;
	private UIController UIController;

	void Start ()
	{
		UpdateDice(0);
		PlayerStats = GameObject.FindWithTag ("PlayerStats").GetComponent<PlayerStats>();
		UIController = GameObject.FindWithTag ("UIController").GetComponent<UIController>();
	}

	void Update () 
	{
		//Display dice requirements and roll
		textRequiredValue.text = "Required: " + iRequiredRollValue + "";
		textRolledValue.text = "Your Roll: " + iTotalRollValue + "";

		if(bIsDiceBoardClosed)
		{
			fTimer -= Time.deltaTime;
			if (fTimer <= 0)
			{
				buRollDiceButton.gameObject.SetActive (true);
				bIsDiceBoardClosed = false;
				fTimer = 1f;
			}
		}

		if (bIsDoneRolling && bIsSearching)
		{
			if (iTotalRollValue < iRequiredRollValue)
			{
				textRollSuccessPrompt.text = "You dont get to pick up any card";
				textRollSuccessPrompt.gameObject.SetActive (true);
				iPooledSearch = iTotalRollValue;
				fTimePassed -= Time.deltaTime;
				if (fTimePassed <= 0)
				{
					UIController.OpenCloseDiceRollerPanel();
					fTimePassed = 2;
				}
			}
			if (iRequiredRollValue <= iTotalRollValue && iTotalRollValue < 2*iRequiredRollValue)
			{
				textRollSuccessPrompt.text = "You get to pick up 1 card";
				textRollSuccessPrompt.gameObject.SetActive (true);
				if(!bIsOpenedScanner)
				{
					fTimePassed -= Time.deltaTime;
					if (fTimePassed <= 0)
					{
						UIController.OpenCloseScannerPanel();
						bIsOpenedScanner = true;
						fTimePassed = 2;
					}
				}
				iPooledSearch = 0;
			}
			if (2*iRequiredRollValue <= iTotalRollValue  && iTotalRollValue < 3*iRequiredRollValue)
			{
				textRollSuccessPrompt.text = "You get to pick up 2 cards";
				textRollSuccessPrompt.gameObject.SetActive (true);
				if(!bIsOpenedScanner)
				{
					fTimePassed -= Time.deltaTime;
					if (fTimePassed <= 0)
					{
						UIController.OpenCloseScannerPanel();
						bIsOpenedScanner = true;
						fTimePassed = 2;
					}
				}
				iPooledSearch = 0;
			}
			if (3*iRequiredRollValue <= iTotalRollValue && iTotalRollValue < 4*iRequiredRollValue)
			{
				textRollSuccessPrompt.text = "You get to pick up 3 cards";
				textRollSuccessPrompt.gameObject.SetActive (true);
				if(!bIsOpenedScanner)
				{
					fTimePassed -= Time.deltaTime;
					if (fTimePassed <= 0)
					{
						UIController.OpenCloseScannerPanel();
						bIsOpenedScanner = true;
						fTimePassed = 2;
					}
				}
				iPooledSearch = 0;
			}
			if (iTotalRollValue >= 4*iRequiredRollValue)
			{
				textRollSuccessPrompt.text = "You get to pick up 4 cards";
				textRollSuccessPrompt.gameObject.SetActive (true);
				if(!bIsOpenedScanner)
				{
					fTimePassed -= Time.deltaTime;
					if (fTimePassed <= 0)
					{
						UIController.OpenCloseScannerPanel();
						bIsOpenedScanner = true;
						fTimePassed = 2;
					}
				}
				iPooledSearch = 0;
			}
		}
		else if (bIsDoneRolling && bIsDoingSkill)
		{
			if (iTotalRollValue < iRequiredRollValue)
			{
				textRollSuccessPrompt.text = "You did not succeed";
				textRollSuccessPrompt.gameObject.SetActive (true);
				iPooledSkill = iTotalRollValue;
				fTimePassed -= Time.deltaTime;
				if (fTimePassed <= 0)
				{
					UIController.OpenCloseDiceRollerPanel();
					fTimePassed = 2;
				}
			}
			if (iTotalRollValue >= iRequiredRollValue)
			{
				textRollSuccessPrompt.text = "You succeed";
				textRollSuccessPrompt.gameObject.SetActive (true);
				iPooledSkill = 0;
				fTimePassed -= Time.deltaTime;
				if (fTimePassed <= 0)
				{
					UIController.OpenCloseDiceRollerPanel();
					//Show skill success thing.
					bIsOpenedScanner = true;
					fTimePassed = 2;
				}
			}
		}
		else if (bIsDoneRolling && bIsInspecting)
		{
			if (iTotalRollValue < iRequiredRollValue)
			{
				textRollSuccessPrompt.text = "You did not succeed";
				textRollSuccessPrompt.gameObject.SetActive (true);
				fTimePassed -= Time.deltaTime;
				if (fTimePassed <= 0)
				{
					UIController.OpenCloseDiceRollerPanel();
					fTimePassed = 2;
				}
			}
			if ((iTotalRollValue >= iRequiredRollValue && iTotalRollValue < 6))
			{
				textRollSuccessPrompt.text = "You get to see their inventory";
				textRollSuccessPrompt.gameObject.SetActive (true);
				fTimePassed -= Time.deltaTime;
				if (fTimePassed <= 0)
				{
					UIController.OpenCloseDiceRollerPanel();
					fTimePassed = 2;
				}
				//Show opponents inventory here
			}
			if (iTotalRollValue >= 6)
			{
				textRollSuccessPrompt.text = "You get to see their role";
				textRollSuccessPrompt.gameObject.SetActive (true);
				fTimePassed -= Time.deltaTime;
				if (fTimePassed <= 0)
				{
					UIController.OpenCloseDiceRollerPanel();
					fTimePassed = 2;
				}
				//Show opponents role here
			}
		}

		if (!bIsDoneRolling && !bIsButtonPressed)
		{
			textRollSuccessPrompt.gameObject.SetActive (false);
		}


		if (bIsButtonPressed && !bAddUpDiceOnce)
		{
			if (iCurrentDiceAmount == 1)
			{
				if (dice[0].bRollComplete)
				{
					AddUpDice();
				}
			}
			else if (iCurrentDiceAmount == 2)
			{
				if (dice[0].bRollComplete &&
				    dice[1].bRollComplete)
				{
					AddUpDice();
				}
			}
			else if (iCurrentDiceAmount == 3)
			{
				if (dice[0].bRollComplete &&
				    dice[1].bRollComplete && 
				    dice[2].bRollComplete)
				{
					AddUpDice();
				}
			}
			else if (iCurrentDiceAmount == 4)
			{
				if (dice[0].bRollComplete &&
				    dice[1].bRollComplete && 
				    dice[2].bRollComplete && 
				    dice[3].bRollComplete)
				{
					AddUpDice();
				}
			}
			else if (iCurrentDiceAmount == 5)
			{
				if (dice[0].bRollComplete &&
				    dice[1].bRollComplete && 
				    dice[2].bRollComplete && 
				    dice[3].bRollComplete &&
				    dice[4].bRollComplete)
				{
					AddUpDice();
				}
			}
			else if (iCurrentDiceAmount == 6)
			{
				if (dice[0].bRollComplete &&
				    dice[1].bRollComplete && 
				    dice[2].bRollComplete && 
				    dice[3].bRollComplete &&
				    dice[4].bRollComplete &&
				    dice[5].bRollComplete)
				{
					AddUpDice();
				}
			}
		}
		
		//Damaging
		if (Input.GetKeyDown(KeyCode.Y))
		{
			UpdateHealth (-1);
		}
		//Healing
		if (Input.GetKeyDown(KeyCode.H))
		{
			UpdateHealth (1);
		}
	}

	public void UpdateHealth (int value)
	{
		PlayerStats.iPlayerHealth += value;
		UpdateDice (0);
	}

	public void UpdateDice (int value)
	{
		iCurrentDiceAmount = PlayerStats.iPlayerHealth + value;
		for (int i = 0; i <dice.Length; i++)
		{
			dice[i].gameObject.SetActive(false);
			dice[i].iCurrentValue = 0;
		}
		for (int i = 0; i <iCurrentDiceAmount; i++) 
		{
			dice[i].gameObject.SetActive(true);
		}
	}
//
	public void AddUpDice ()
	{
//		ResetDice();
		for (int i = 0; i <iCurrentDiceAmount; i++) 
		{
			iTotalRollValue += dice[i].iCurrentValue;
			dice[i].bRollComplete = false;
		} 
		bIsDoneRolling = true;
		bAddUpDiceOnce = true;
	}

	public void AddAnyPoolRemaining ()
	{
		if(bIsSearching)
		{
			iTotalRollValue = iPooledSearch;
		}
		
		if(bIsDoingSkill)
		{
			iTotalRollValue = iPooledSkill;
		}
	}

	public void ResetDiceBoard ()
	{
		iTotalRollValue = 0;
		bIsOpenedScanner = false;
		bAddUpDiceOnce = false;
		bIsButtonPressed = false;
		bIsDoneRolling = false;
		bIsInspecting = false;
		bIsSearching = false;
		bIsDoingSkill = false;
		bIsAttacking = false;
		bIsDefending = false;
		bIsArresting = false;
		bIsEscaping = false;
		bIsDiceBoardClosed = true;
	}

}
