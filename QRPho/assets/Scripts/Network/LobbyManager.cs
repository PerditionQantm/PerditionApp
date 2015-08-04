using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine.Networking;

public class LobbyManager : NetworkLobbyManager
{
	//public NetworkLobbyManager m_NetMng;
	public string m_ssLobbyName = "";
	public string m_ssLocalAddress = "";

	public List<Vector2> m_lGUIPositions;
	public int m_iConnectedPlayers = 0;

	public GameObject m_LobbyGUIPrefab;
		

	void Start ()
	{
		m_lGUIPositions = new List<Vector2> ();
		m_lGUIPositions.AddRange (new Vector2[] {
			new Vector2 (-100, 40),
			new Vector2 (100, 40),
			new Vector2 (-100, -80),
			new Vector2 (100, -80)
		});
		m_ssLocalAddress = Network.player.ipAddress;
		this.networkAddress = m_ssLocalAddress;
	}

	public void StartLobby ()
	{
		if (m_ssLobbyName == "")
		{
			return;
		}
		base.StartHost ();
	}

	public void setLobbyName ()
	{
		InputField temp = UIPanelManager.getUIElementOnPanel ("HostName").GetComponent<InputField> ();
		if (temp != null)
		{
			m_ssLobbyName = temp.text;
		} else
		{
			Debug.Log ("No Element named HostName on this Panel");
		}
		return;			
	}

	void Update ()
	{
//
	}

	public override void OnClientConnect (NetworkConnection conn)
	{
		Debug.Log ("Player Connected");
		m_iConnectedPlayers ++;
		base.OnClientConnect (conn);
		
	}

	public override void OnClientDisconnect (NetworkConnection conn)
	{
		Debug.Log ("Player Disconnected");
		m_iConnectedPlayers --;
		base.OnClientDisconnect (conn);
	}

	public void InstantiatePlayerPanel (NetworkConnection conn)
	{

	}

}
