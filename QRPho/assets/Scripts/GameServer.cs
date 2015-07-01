using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GameServer : MonoBehaviour {

	public Text txtServers;
	private HostData[] netServerList;
	public NetworkConnectionError netError;

	// Use this for initialization
	void Start () {

	}

	public void StartServer() {
		netError = NetworkConnectionError.NoError;

		Network.InitializeServer(4, 25002, !Network.HavePublicAddress());
		MasterServer.RegisterHost("TrepidationGame", "HauntedMansion1", "2spoopy4me");

		if (netError != NetworkConnectionError.NoError) {
			Debug.Log(netError.ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (MasterServer.PollHostList().Length != 0) {
			HostData[] hostData = MasterServer.PollHostList();
			int i = 0;
			while (i < hostData.Length) {
				txtServers.text = txtServers.text + "Game name: " + hostData[i].gameName + "\n";
				i++;
			}
			MasterServer.ClearHostList();
		}
	}
}
