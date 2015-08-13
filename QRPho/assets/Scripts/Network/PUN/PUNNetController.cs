using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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
	GAME,
}

public class PUNNetController : PunBehaviour {

	public ControllerState m_CurrentState { get; private set; }
	public 

	// Use this for initialization
	void Start () {
		m_CurrentState = ControllerState.NOCONNECTION;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnConnectedToPhoton()
	{
		Debug.Log("Connected to Photon!");
		m_CurrentState = ControllerState.MASTER;
 		base.OnConnectedToPhoton();
		tryConnectToLobby();
	}

	public override void OnJoinedLobby()
	{
		Debug.Log("\tConnected to Lobby!");
		m_CurrentState = ControllerState.LOBBY;
		base.OnJoinedLobby();
		UIPanelManager.OpenPanel("HostSetup");

	}

	public override void OnJoinedRoom()
	{
		m_CurrentState = ControllerState.ROOM;
		base.OnJoinedRoom();
	}

	public override void OnDisconnectedFromPhoton()
	{
		m_CurrentState = ControllerState.NOCONNECTION;
		base.OnDisconnectedFromPhoton();
	}

	public override void OnCreatedRoom()
	{
		m_CurrentState = ControllerState.ROOM;
		base.OnCreatedRoom();
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
		if (PhotonNetwork.JoinOrCreateRoom(roomName, opt, TypedLobby.Default))
		{
			m_CurrentState = ControllerState.TRYROOM;
			return;
		}
	}

	public override void OnReceivedRoomListUpdate()
	{
		base.OnReceivedRoomListUpdate();
	}
}
