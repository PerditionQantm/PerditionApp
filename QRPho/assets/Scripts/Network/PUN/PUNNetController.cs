﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Timers;
using ExitGames.Client;
using Photon;

public enum ControllerState
{
	ERROR = 0,
	NOCONNECTION,
	TRYMASTER,
	MASTER,
	TRYLOBBY,
	LOBBY,
	TRYROOM,
	ROOM,
	READY,
	GAME,
}

public class PUNNetController : PunBehaviour {

	public string m_ssRoomName { get; private set; }
	public ControllerState m_CurrentState { get; private set; }
	public ExitGames.Client.Photon.Hashtable m_PropertiesHash;

	public Text m_GameTimerDisplay = null;
	float m_StartTimer = 0.0f;

	bool m_bCounting = false;

	// Use this for initialization
	void Start () {
		m_CurrentState = ControllerState.NOCONNECTION;
		m_PropertiesHash = new ExitGames.Client.Photon.Hashtable();
		m_PropertiesHash.Add("Ready", false);

		//More Custom Properties

		PhotonNetwork.player.SetCustomProperties(m_PropertiesHash);

	}
	
	// Update is called once per frame
	void Update()
	{
		if (UIPanelManager.m_CurrentPanel.name.Contains("_ClientConnected"))
		{
			if (m_GameTimerDisplay == null)
			{
				//m_GameTimerDisplay = UIPanelManager.getUIElementOnPanel("TimerToGame").GetComponent<Text>();
			}
			Text tempText = UIPanelManager.getUIElementOnPanel("PlayerList").GetComponent<Text>();

			tempText.text = "";

			foreach (PhotonPlayer player in PhotonNetwork.playerList)
			{
				string tempString = "";
				if ((bool)(player.customProperties["Ready"]))
				{
					tempString = player.name + " - Ready\n";
				}
				else
				{
					tempString = "Connected - Waiting\n";
				}
				tempText.text += tempString;
			}

			if (PhotonNetwork.playerList.Length < 4)
			{
				for (int i = 0; i < (4 - PhotonNetwork.playerList.Length); ++i)
				{
					tempText.text += "Empty";
					if (i + PhotonNetwork.playerList.Length < 4)
					{
						tempText.text += "\n";
					}
				}
			}
			if (PhotonNetwork.playerList.Length == 1)
			{
				int readyCount = 0;
				foreach (PhotonPlayer player in PhotonNetwork.playerList)
				{
					if ((bool)(player.customProperties["Ready"]) == true)
					{
						readyCount += 1;
					}
				}
				if (readyCount >= 1)
				{
					if (!m_bCounting)
					{
						Debug.Log("Not Counting");
						m_StartTimer = 0.0f;
						m_bCounting = true;
						if (!m_GameTimerDisplay.IsActive())
						{
							m_GameTimerDisplay.gameObject.SetActive(true);
						}
					}
					else
					{
						if (m_StartTimer >= 6.0f)
						{
							PhotonNetwork.LoadLevel("UIPrototype");
						}
						else
						{
							Debug.Log("Counting");
							m_StartTimer += Time.deltaTime;
							m_GameTimerDisplay.text = string.Format("Time until Start\n{0}", decimal.Round((decimal)(6.0f - m_StartTimer), 2));
						}
					}
					
				}
				else
				{
					Debug.Log("Not All Players Are Ready...");
					m_StartTimer = 0.0f;
					m_bCounting = false;
//					if (m_GameTimerDisplay.IsActive())
//					{
//						m_GameTimerDisplay.gameObject.SetActive(false);
//					}
				}
			}
			else
			{
				Debug.Log("Waiting on " + (4 - PhotonNetwork.playerList.Length) + " players...");
			}
			
		}
	}

	public override void OnConnectedToPhoton()
	{
		base.OnConnectedToPhoton();

		Debug.Log("Connected to Photon!");
		m_CurrentState = ControllerState.MASTER;
 		
		tryConnectToLobby();
	}

	public override void OnJoinedLobby()
	{
		base.OnJoinedLobby();

		Debug.Log("\tConnected to Lobby!");
		m_CurrentState = ControllerState.LOBBY;
		
		UIPanelManager.OpenPanel("GameLobby");

	}

	public override void OnJoinedRoom()
	{
		base.OnJoinedRoom();

		m_CurrentState = ControllerState.ROOM;
		Debug.Log("\t\tJoined a room!");

		UIPanelManager.OpenPanel("ClientConnected");
		UIPanelManager.getUIElementOnPanel("MenuDescription").GetComponentInChildren<Text>().text = "Room Name:\n" + PhotonNetwork.room.name;

	}

	public override void OnDisconnectedFromPhoton()
	{
		m_CurrentState = ControllerState.NOCONNECTION;
		base.OnDisconnectedFromPhoton();
	}

	public override void OnCreatedRoom()
	{
		m_CurrentState = ControllerState.ROOM;
		Debug.Log("\t\tCreated a room!");
		base.OnCreatedRoom();
	}

	public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
	{
		Debug.Log(codeAndMsg.ToString());
		base.OnPhotonJoinRoomFailed(codeAndMsg);
	}

	public void tryConnectToMaster()
	{
		UIPanelManager.OpenPanel("Connecting");
		UIPanelManager.getUIElementOnPanel("ConnectDesc").GetComponentInChildren<Text>().text = "Connecting to\nMaster Server...";
		if (PhotonNetwork.ConnectUsingSettings("0.1"))
		{
			m_CurrentState = ControllerState.TRYMASTER;
			return;
		}
	}

	public void tryConnectToLobby()
	{
		UIPanelManager.OpenPanel("Connecting");
		UIPanelManager.getUIElementOnPanel("ConnectDesc").GetComponentInChildren<Text>().text = "Connecting to\nLobby...";
		if (PhotonNetwork.JoinLobby())
		{
			m_CurrentState = ControllerState.TRYLOBBY;
			return;
		}
	}

	public void tryConnectToRoom(string roomName)
	{
		RoomOptions opt = new RoomOptions();

		opt.maxPlayers = 4;
		opt.isVisible = true;
		opt.isOpen = true;
		UIPanelManager.OpenPanel("Connecting");
		UIPanelManager.getUIElementOnPanel("ConnectDesc").GetComponentInChildren<Text>().text = "Finding or\nCreating Room...";
		if (PhotonNetwork.JoinOrCreateRoom(roomName, opt, TypedLobby.Default))
		{
			m_CurrentState = ControllerState.TRYROOM;
			return;
		}
	}
	public void tryConnectToRoom()
	{
		RoomOptions opt = new RoomOptions();

		opt.maxPlayers = 4;
		opt.isVisible = true;
		opt.isOpen = true;
		UIPanelManager.OpenPanel("Connecting");
		UIPanelManager.getUIElementOnPanel("ConnectDesc").GetComponentInChildren<Text>().text = "Finding or\nCreating Room...";
		if (PhotonNetwork.JoinOrCreateRoom(m_ssRoomName, opt, TypedLobby.Default))
		{
			m_CurrentState = ControllerState.TRYROOM;
			return;
		}
	}

	public override void OnReceivedRoomListUpdate()
	{
		base.OnReceivedRoomListUpdate();
	}

	public void setRoomName(string room)
	{
		m_ssRoomName = room;
	}

	public void setPlayerName (string name)
	{
		PhotonNetwork.playerName = name;
	}

	public void setRoomReady(bool ready)
	{
		m_PropertiesHash["Ready"] = ready;
		PhotonNetwork.player.SetCustomProperties(m_PropertiesHash);

		if ((bool)(PhotonNetwork.player.customProperties["Ready"]) == true)
		{
			Debug.Log("Ready To Play");
		}
		else
		{
			Debug.Log("Not Ready To Play");
		}

		if (PhotonNetwork.playerList.Length == 4)
		{
			int readyCount = 0;
			foreach (PhotonPlayer player in PhotonNetwork.playerList)
			{
				if ((bool)(player.customProperties["ready"]) == true)
				{
					readyCount += 1;
				}
			}
			if (readyCount >= 4)
			{
				Debug.Log("All Players Are Connected And Ready!");
				PhotonNetwork.LoadLevel("UIPrototype");
			}
			else
			{
				Debug.Log("Not All Players Are Ready...");
			}
		}
		else
		{
			Debug.Log("Waiting on " + (4 - PhotonNetwork.playerList.Length) + " players...");
		}

	}

	public void disconFromLobby()
	{
		PhotonNetwork.Disconnect();
	}

	public void disconFromRoom()
	{
		PhotonNetwork.LeaveRoom();
	}

	public void ChangeScene(string scene) {
		PhotonNetwork.LoadLevel(scene);
	}
}
