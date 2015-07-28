using UnityEngine;
using UnityEngine.Networking;

using System.Collections;
using System.Collections.Generic;

public class ClientHandler : MonoBehaviour
{

		NetworkClient m_Client;
		NetworkLobbyPlayer m_lClient;

		public string m_ssIPAddress;
		public string m_ssLocalNetwork;

		public List<string> m_lLocalNetworkAddresses = new List<string> ();

		public int m_iLocalAddress;
		public int m_iLastAddressScanned;

		public float m_fConnectionTimer = 1.0f;
		public float m_fCurrentTimer;

		//public ServerScanStatus m_ScanStatus;

		// Use this for initialization
		void Start ()
		{
				m_Client = new NetworkClient ();
				m_ssIPAddress = Network.player.ipAddress;
				setLocalNetwork ();
				m_fCurrentTimer = m_fConnectionTimer;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (m_lLocalNetworkAddresses.Count > 0) {
						if (m_Client.isConnected) {
								m_lLocalNetworkAddresses.Clear ();
								m_fCurrentTimer = m_fConnectionTimer;
						} else {
								if (m_fCurrentTimer <= 0.0f) {
										m_fCurrentTimer = m_fConnectionTimer;
										Network.Connect (m_lLocalNetworkAddresses [0], 7777);
										m_lLocalNetworkAddresses.RemoveAt (0);
								} else {
										m_fCurrentTimer -= Time.deltaTime;
								}
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
				for (int i = 1; i < 256; i++) {
						if (i != m_iLocalAddress) {
								Debug.Log (m_ssLocalNetwork + i.ToString ());
								m_lLocalNetworkAddresses.Add (m_ssLocalNetwork + i.ToString ());
						} else {
								Debug.Log ("Adding Local Host");
								m_lLocalNetworkAddresses.Add ("localhost");
						}
				}
		}

}
