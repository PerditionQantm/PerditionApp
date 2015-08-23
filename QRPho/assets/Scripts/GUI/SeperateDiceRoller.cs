using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SeperateDiceRoller : MonoBehaviour {

	public LayerMask dieValueTagLayer = -1;
	
	public Button buRollDiceButton;
	
	public int iCurrentValue = 1;
	private float fTimer = 0.5f;
	private bool bTiming = false;
	public bool bRollComplete = false;
	public float fForceAmount = 10.0f;
	public float fTorqueAmount = 10.0f;
	public ForceMode forceMode;

	void Update () 
	{
		RaycastHit hit;
		
		if (GetComponent<Rigidbody>().IsSleeping())
		{
			if(bRollComplete == false) 
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
		buRollDiceButton.gameObject.SetActive (false);
	}
}
