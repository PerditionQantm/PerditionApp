using UnityEngine;
using System.Collections;

public class LobbyGUIHandler : MonoBehaviour
{

	public PUNNetController m_NetController;

	// Use this for initialization
	void Start ()
	{
		m_NetController = this.gameObject.GetComponent<PUNNetController>();
	}
	
	// Update is called once per frame
	void Update()
	{
		//
	}
}
