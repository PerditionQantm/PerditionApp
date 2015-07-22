using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DiceController : MonoBehaviour {

	public GameObject protoDie;
	public AudioSource asDiceRoll;
	public Button butRoll;

	public Gyroscope gyroRoller;

	List<GameObject> l_dice;
	public int iDiceAmount = 6;

	public float fRollCooldown = 0.0f;
	public bool bRollInProgress = false;
	public int iDiceFinishedRolling = 0;

	public PhysicMaterial physmatBounceLow;
	public PhysicMaterial physmatBounceMid;
	public PhysicMaterial physmatBounceHigh;

	private List<PhysicMaterial> l_physmatBounceTypes;
	
	void Start() {
		l_dice = new List<GameObject>();

		if (SystemInfo.supportsGyroscope) {
			gyroRoller = Input.gyro;
			gyroRoller.enabled = true;
		}

		l_physmatBounceTypes = new List<PhysicMaterial>();
		l_physmatBounceTypes.Add(physmatBounceLow);
		l_physmatBounceTypes.Add(physmatBounceMid);
		l_physmatBounceTypes.Add(physmatBounceHigh);

		if (protoDie != null) {
			for (int i = 0; i < iDiceAmount; i++) {
				l_dice.Add((GameObject)GameObject.Instantiate(protoDie, new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(1.0f, 1.1f), Random.Range(-4.0f, 4.0f)), Quaternion.identity));
				l_dice[l_dice.Count - 1].GetComponent<BoxCollider>().material = l_physmatBounceTypes[Random.Range(0, 3)];
			}
		}
	}

	void Update() {
		if (fRollCooldown > 0) {
			fRollCooldown -= Time.deltaTime;
		}
		else {
			bRollInProgress = false;
			StopRolling();
		}

		if (gyroRoller != null && gyroRoller.enabled) {
			if (gyroRoller.userAcceleration.magnitude > 2) {
				RollDice();
			}
		}

		if (bRollInProgress) {
			foreach (GameObject die in l_dice) {
				bool bumpstuck = false;
				//Are we not in motion?
				if (die.GetComponent<Rigidbody>().angularVelocity.magnitude == 0.0f) {
					if (die.GetComponent<Rigidbody>().velocity.magnitude == 0.0f) {
						//Are we on a weird angle (wedged)? If so, bump
						Debug.Log("round x: " + Mathf.Round(die.transform.eulerAngles.x) + " round y: " + Mathf.Round(die.transform.eulerAngles.y) + " round z: " + Mathf.Round(die.transform.eulerAngles.z));

						if (Mathf.Round(die.transform.eulerAngles.x) % 90 != 0) {
							bumpstuck = true;
							die.GetComponent<Rigidbody>().AddForce(Random.Range(-50, 50), Random.Range(50, 150), Random.Range(-50, 50));
						}
//						else if (Mathf.Round(die.transform.eulerAngles.y) % 90 != 0) {
//							bumpstuck = true;
//							die.GetComponent<Rigidbody>().AddForce(Random.Range(-50, 50), Random.Range(50, 150), Random.Range(-50, 50));
//						}
						else if (Mathf.Round(die.transform.eulerAngles.z) % 90 != 0) {
							bumpstuck = true;
							die.GetComponent<Rigidbody>().AddForce(Random.Range(-50, 50), Random.Range(50, 150), Random.Range(-50, 50));
						}


						//Finally stop rolling and freeze
						if (!bumpstuck && die.GetComponent<Die>().bRolling) {
							iDiceFinishedRolling++;
							die.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
							die.GetComponent<Die>().bRolling = false;
						}
					}
				}
				//die.GetComponent<Die>()
			}
		}

		if (bRollInProgress && iDiceFinishedRolling == iDiceAmount) {
			StopRolling();
		}
	}

	public void RollDice() {
		if (fRollCooldown <= 0 && !bRollInProgress) {
			foreach (GameObject die in l_dice) {
				die.GetComponent<Rigidbody>().AddForce(Random.Range(-25, 25), Random.Range(14, 16), Random.Range(-25, 25), ForceMode.Impulse);
				//die.GetComponent<Rigidbody>().AddTorque(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1), ForceMode.Impulse);
				die.GetComponent<Die>().bRolling = true;
				die.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			}
			asDiceRoll.Play();
			bRollInProgress = true;
			iDiceFinishedRolling = 0;
			fRollCooldown = 7.0f;
			butRoll.interactable = false;
		}
	}

	public void StopRolling() {
		foreach (GameObject die in l_dice) {
			die.GetComponent<Die>().bRolling = false;
			die.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		}
		bRollInProgress = false;
		fRollCooldown = 0;
		butRoll.interactable = true;
	}
}
