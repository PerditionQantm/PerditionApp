using UnityEngine;
using UnityEngine.Networking;

using System;
using System.Collections;
using System.Collections.Generic;

public class ClientHandler : MonoBehaviour
{

	NetworkClient m_Client;

	bool m_bScanning = false;
	bool m_bNewScan = false;

	string m_ssIPAddress;
	string m_ssLocalNetwork;

	int m_iLocalAddress;


	List<string> m_lLocalNetworkAddresses = new List<string> ();

	public int m_iPort = 17032;


	public void OnError (NetworkMessage msg)
	{
		Debug.Log ("\t\tERROR: " + msg.reader.ReadString ());
		if (m_bScanning)
		{
			m_bNewScan = true;
		}
	}


	public void OnConnect (NetworkMessage msg)
	{
		Debug.Log ("\t\tConnected");
		m_bScanning = false;

		UIPanelManager.OpenPanel ("ClientConnected");
	}
	public void OnDisconnect (NetworkMessage msg)
	{
		Debug.Log ("\t\tDisconnected");
	}
	// Use this for initialization
	void Start ()
	{
		m_Client = new NetworkClient ();
		ConnectionConfig m_Config = new ConnectionConfig ();

		m_Config.ConnectTimeout = 300;
		m_Config.DisconnectTimeout = 900;
		m_Client.Configure (m_Config, 1);

		m_Client.RegisterHandler (MsgType.Error, OnError);
		m_Client.RegisterHandler (MsgType.Connect, OnConnect);
		m_Client.RegisterHandler (MsgType.Disconnect, OnDisconnect);

		m_ssIPAddress = Network.player.ipAddress;

		setLocalNetwork ();
		LocalNetworkScan ();
	}

	
	
	// Update is called once per frame
	void Update ()
	{
		if (m_Client.isConnected)
		{
			m_bScanning = false;
		} else if (m_bScanning)
			{
				if (m_bNewScan)
				{
					
					ConnectToIP (m_lLocalNetworkAddresses [0]);
					m_bNewScan = false;
					m_lLocalNetworkAddresses.Add (m_lLocalNetworkAddresses [0]);
					m_lLocalNetworkAddresses.RemoveAt (0);
				}
			}
	}

	public void setLocalNetwork ()
	{
		m_ssLocalNetwork = m_ssIPAddress.Substring (0, m_ssIPAddress.LastIndexOf (".") + 1);
		m_iLocalAddress = int.Parse (m_ssIPAddress.Substring (m_ssIPAddress.LastIndexOf (".") + 1));
	}

	public void LocalNetworkScan ()
	{
		for (int i = 1; i < 256; i++)
		{
			if (i != m_iLocalAddress)
			{
				//Debug.Log (m_ssLocalNetwork + i.ToString ());
				m_lLocalNetworkAddresses.Add (m_ssLocalNetwork + i.ToString ());
			} else
			{
				//Debug.Log ("Adding Local Host");
				m_lLocalNetworkAddresses.Add ("localhost");
			}
		}
	}

	public void ScanForServer ()
	{
		if (!m_Client.isConnected)
		{
			Debug.Log ("Starting To Connect...");
			m_bScanning = true;
			m_bNewScan = true;
		}
	}

	public void ConnectToIP (string ipAdd)
	{
		Debug.Log ("\t Attempting to connect to " + ipAdd + " on server port " + m_iPort + "...");
		m_Client.Connect (ipAdd, m_iPort);
	}
}
