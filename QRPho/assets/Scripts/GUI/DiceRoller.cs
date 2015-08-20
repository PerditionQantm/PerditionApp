using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiceRoller : MonoBehaviour {

	public LayerMask dieValueTagLayer = -1;

	public Button buRollDiceButton;

	public int iCurrentValue = 1;
	private float fTimer = 0.5f;
	private bool bTiming = false;
	public bool bRollComplete = false;
	public float fForceAmount = 10.0f;
	public float fTorqueAmount = 10.0f;
	public ForceMode forceMode;
	private DiceCalculator DiceCalculator;

	void Start ()
	{
		DiceCalculator = GameObject.FindWithTag ("DiceCalculator").GetComponent<DiceCalculator>();
	}

	void Update () 
	{
		RaycastHit hit;

		if(bTiming)
		{
			fTimer -= Time.deltaTime;
			if (fTimer <= 0)
			{
				bTiming = false;
				DiceCalculator.bIsButtonPressed = true;
				fTimer = 0.5f;
			}
		}

		if (GetComponent<Rigidbody>().IsSleeping())
		{
			if(bRollComplete == false && DiceCalculator.bIsButtonPressed) 
			{
				if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueTagLayer))
				{
					iCurrentValue = hit.collider.GetComponent<DiceValue>().iDiceSideValue;
				}
			
			bRollComplete = true;
			}
		}
		else if (!GetComponent<Rigidbody>().IsSleeping())
		{
			if (Time.time > 2f)
				{
					bRollComplete = false;
				}
		}
	}

	public void RollDice ()
	{
		GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*fForceAmount, forceMode);
		GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*fTorqueAmount, forceMode);
		bRollComplete = false;
		DiceCalculator.bOpenedDiceRoller = false;
		bTiming = true;
		buRollDiceButton.gameObject.SetActive (false);
	}

}
