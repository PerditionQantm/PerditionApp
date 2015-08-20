using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour {
	
	public Text textCardName;
	public Text textEffect;
	public Text textUses;
	public Button buUseButton;
	public RectTransform rectPosition;
	public int iUses = 1;

	private CardHandler CardHandler;

	void Start ()
	{
		CardHandler = GameObject.FindWithTag ("CardHandler").GetComponent<CardHandler>();
	}

	void Update ()
	{
		iUses = Mathf.Clamp (iUses, 0, 100);

		textUses.text = iUses.ToString();

		if (iUses == 0)
		{
			buUseButton.gameObject.SetActive (false);
			CardHandler.RemoveCard(this, rectPosition);
		}
	}

}
