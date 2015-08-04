using UnityEngine;
using System.Collections;

public class LobbyGUIHandler : MonoBehaviour
{

	public CustomLobbyPlayer m_LobbyPlayer;
	public bool m_bTaken = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_LobbyPlayer == null)
		{
			m_bTaken = false;
		} else
		{
			m_bTaken = true;
		}
	}
}
