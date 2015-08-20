using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardHandler : MonoBehaviour {

	public Card CardPrefab;
	public RectTransform rectInvPanel;
	public RectTransform rectCard1;
	public RectTransform rectCard2;
	public RectTransform rectCard3;
	public RectTransform rectCard4;
	private RectTransform rectCurrentCard;

	private bool bCardPlaced = false;
	private bool bCard1Taken = false;
	private bool bCard2Taken = false;
	private bool bCard3Taken = false;
	private bool bCard4Taken = false;
	private Vector3 vNormal = new Vector3 (1, 1, 1);

	private PlayerStats PlayerStats;
	private DiceCalculator DiceCalculator;

	void Start ()
	{
		PlayerStats = GameObject.FindWithTag ("PlayerStats").GetComponent<PlayerStats>();
		DiceCalculator = GameObject.FindWithTag ("DiceCalculator").GetComponent<DiceCalculator>();
	}

	void Update () 
	{

	}

	public void AddCard (string name, string effect, int uses)
	{
		if(!bCardPlaced)
		{
			if(!bCard1Taken)
			{
				rectCurrentCard = rectCard1;
				bCard1Taken = true;
				bCardPlaced = true;
			}
			else if(!bCard2Taken)
			{
				rectCurrentCard = rectCard2;
				bCard2Taken = true;
				bCardPlaced = true;
			}
			else if(!bCard3Taken)
			{
				rectCurrentCard = rectCard3;
				bCard3Taken = true;
				bCardPlaced = true;
			}
			else if(!bCard4Taken)
			{
				rectCurrentCard = rectCard4;
				bCard4Taken = true;
				bCardPlaced = true;
			}
		}

		Card cardInstance = Instantiate (CardPrefab, rectCurrentCard.position, rectCurrentCard.rotation) as Card;
		cardInstance.rectPosition = rectCurrentCard;
		cardInstance.textCardName.text = name;
		cardInstance.textEffect.text = effect;
		if (effect == "Evidence")
		{
			if(!PlayerStats.bEvidenceFound)
			{
				PlayerStats.bEvidenceFound = true;
				cardInstance.buUseButton.gameObject.SetActive (false);
			}
		}
		else if (effect == "Deception Point")
		{
			cardInstance.buUseButton.onClick.AddListener(() => {
				if(PlayerStats.iPlayerDeceptionPoints < 3)
				{
					cardInstance.iUses -= 1;
					DeceptionPoint(cardInstance.buUseButton);
				}
			});
		}
		else if (effect == "Extra Dice")
		{
			PlayerStats.iExtraDice += 1;
			cardInstance.buUseButton.gameObject.SetActive (false);
		}
		else if (effect == "Extra Damage")
		{
			PlayerStats.iExtraAttackDice += 1;
			cardInstance.buUseButton.gameObject.SetActive (false);
		}
		else if (effect == "Extra Arrest")
		{
			PlayerStats.iExtraArrestDice += 1;
			cardInstance.buUseButton.gameObject.SetActive (false);
		}
		else if (effect == "Extra Dice")
		{
			PlayerStats.iExtraDice += 1;
			cardInstance.buUseButton.gameObject.SetActive (false);
		}
		else if (effect == "Damage Reduction")
		{
			cardInstance.iUses = uses;
			cardInstance.textUses.gameObject.SetActive (true);
			cardInstance.textUses.text = cardInstance.iUses.ToString();
			cardInstance.buUseButton.onClick.AddListener(() => {
				if(DiceCalculator.bOpenedDiceRoller && DiceCalculator.bIsDefending)
				{
					DamageReduction(cardInstance.buUseButton, cardInstance.iUses);
					cardInstance.iUses -= 1;
				}
			});
		}
		else if (effect == "Extra Escape")
		{
			PlayerStats.iExtraEscapeDice += 1;
			cardInstance.buUseButton.gameObject.SetActive (false);
		}
		else if (effect == "Instant Heal")
		{
			cardInstance.iUses = uses;
			cardInstance.textUses.gameObject.SetActive (true);
			cardInstance.textUses.text = cardInstance.iUses.ToString();
			cardInstance.buUseButton.onClick.AddListener(() => {
				if(PlayerStats.iPlayerHealth < 4)
				{
					InstantHeal(cardInstance.buUseButton, cardInstance.iUses);
					cardInstance.iUses -= 1;
				}
			});
		}
		else if (effect == "Instant Damage Successes")
		{
			cardInstance.iUses = uses;
			cardInstance.textUses.gameObject.SetActive (true);
			cardInstance.textUses.text = cardInstance.iUses.ToString();
			cardInstance.buUseButton.onClick.AddListener(() => {
				if(DiceCalculator.bOpenedDiceRoller && DiceCalculator.bIsAttacking)
				{
					InstantSuccess(cardInstance.buUseButton, cardInstance.iUses);
					cardInstance.iUses -= 1;
				}
			});
		}
		else if (effect == "Instant Skill Successes")
		{
			cardInstance.iUses = uses;
			cardInstance.textUses.gameObject.SetActive (true);
			cardInstance.textUses.text = cardInstance.iUses.ToString();
			cardInstance.buUseButton.onClick.AddListener(() => {
				if(DiceCalculator.bOpenedDiceRoller && DiceCalculator.bIsDoingSkill)
				{
					InstantSuccess(cardInstance.buUseButton, cardInstance.iUses);
					cardInstance.iUses -= 1;
				}
			});
		}
		else if (effect == "Instant Arrest Successes")
		{
			cardInstance.iUses = uses;
			cardInstance.textUses.gameObject.SetActive (true);
			cardInstance.textUses.text = cardInstance.iUses.ToString();
			cardInstance.buUseButton.onClick.AddListener(() => {
				if(DiceCalculator.bOpenedDiceRoller && DiceCalculator.bIsArresting)
				{
					InstantSuccess(cardInstance.buUseButton, cardInstance.iUses);
					cardInstance.iUses -= 1;
				}
			});
		}
		else if (effect == "Movement")
		{

		}
		else if (effect == "Extra Action")
		{
			cardInstance.buUseButton.onClick.AddListener(() => {
				if(PlayerStats.iPlayerActionPoints < 3)
				{
					cardInstance.iUses -= 1;
					ActionPoint(cardInstance.buUseButton);
				}
			});
		}
		cardInstance.transform.SetParent (rectInvPanel.transform);
		cardInstance.gameObject.transform.localScale = vNormal;
		bCardPlaced = false;
	}

	public void RemoveCard (Card card, RectTransform position)
	{
		Destroy (card.gameObject);

		if(position == rectCard1)
		{
			bCard1Taken = false;
		}
		else if(position == rectCard2)
		{
			bCard2Taken = false;
		}
		else if(position == rectCard3)
		{
			bCard3Taken = false;
		}
		else if(position == rectCard4)
		{
			bCard4Taken = false;
		}
	}

	void InstantHeal (Button button, int uses)
	{
		if (uses > 0)
		{
			PlayerStats.iPlayerHealth += 1;
		}
	}

	void InstantSuccess (Button button, int uses)
	{
		if (uses > 0)
		{
			DiceCalculator.iTotalRollValue += 1;
		}
	}

	void DamageReduction (Button button, int uses)
	{
		if (uses > 0)
		{
			DiceCalculator.iRequiredRollValue -= 1;
		}
	}

	void ActionPoint (Button button)
	{
		PlayerStats.iPlayerActionPoints += 1;
		button.gameObject.SetActive (false);
	}

	void DeceptionPoint (Button button)
	{
		PlayerStats.iPlayerDeceptionPoints += 1;
		button.gameObject.SetActive (false);
	}
}
