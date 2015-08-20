using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActionController : MonoBehaviour {
	
	private PlayerStats PlayerStats;
	private DiceCalculator DiceCalculator;
	private UIController UIController;

	void Start ()
	{
		DiceCalculator = GameObject.FindWithTag ("DiceCalculator").GetComponent<DiceCalculator>();
		UIController = GameObject.FindWithTag ("UIController").GetComponent<UIController>();
		PlayerStats = GameObject.FindWithTag ("PlayerStats").GetComponent<PlayerStats>();
	}
	
	void Update () 
	{

	}

	public void InspectAction ()
	{
		if (PlayerStats.iPlayerActionPoints >= 2)
		{
			PlayerStats.iPlayerActionPoints -= 2;
			UIController.OpenCloseDiceRollerPanel();
			DiceCalculator.iRequiredRollValue = 4;
			DiceCalculator.UpdateDice((PlayerStats.iExtraDice + PlayerStats.iExtraInspectDice));
			DiceCalculator.bIsInspecting = true;
		}
	}

	public void HealAction ()
	{
		if (PlayerStats.iPlayerActionPoints >= 2 && PlayerStats.iPlayerHealth < 4)
		{
			PlayerStats.iPlayerActionPoints -= 2;
			DiceCalculator.UpdateHealth (1);
		}
	}

	public void SearchAction ()
	{
		if (PlayerStats.iPlayerActionPoints >= 2)
		{
			PlayerStats.iPlayerActionPoints -= 2;
			UIController.OpenCloseDiceRollerPanel();
			DiceCalculator.iRequiredRollValue = 3;
			DiceCalculator.UpdateDice(PlayerStats.iExtraDice);
			DiceCalculator.bIsSearching = true;
		}
	}

	public void SkillAction ()
	{
		if (PlayerStats.iPlayerActionPoints >= 2)
		{
			PlayerStats.iPlayerActionPoints -= 2;
			UIController.OpenCloseDiceRollerPanel();
			DiceCalculator.iRequiredRollValue = 6;
			DiceCalculator.UpdateDice(PlayerStats.iExtraDice);
			DiceCalculator.bIsDoingSkill = true;
		}
	}
	
	public void DeceptionAction ()
	{
		if (PlayerStats.iPlayerActionPoints >= 2)
		{
			PlayerStats.iPlayerActionPoints -= 2;
			PlayerStats.iPlayerDeceptionPoints += 1;
		}
	}
}
