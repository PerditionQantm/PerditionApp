using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.Networking;

public class LobbyManager : NetworkLobbyManager
{
		//public NetworkLobbyManager m_NetMng;
		public string m_ssLobbyName = "";
		public string m_ssLocalAddress = "";
		

		void Start ()
		{
				
				m_ssLocalAddress = Network.player.ipAddress;
				this.networkAddress = m_ssLocalAddress;
		}

		public void StartLobby ()
		{
				if (m_ssLobbyName == "") {
						return;
				}
				base.StartHost ();
		}

		public void setLobbyName ()
		{
				InputField temp = UIPanelManager.getUIElementOnPanel ("HostName").GetComponent<InputField> ();
				if (temp != null) {
						m_ssLobbyName = temp.text;
				} else {
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
				base.OnClientConnect (conn);
		}

}
