using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	public AudioSource asBump;
	public bool bRolling;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision hit) {
		if (hit.relativeVelocity.magnitude > 0.01f) {
			asBump.Play();
		}
	}
}
