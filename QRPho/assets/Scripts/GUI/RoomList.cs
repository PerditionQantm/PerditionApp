using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Photon;

using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class RoomList : PunBehaviour {

	public GameObject m_ItemPrefab;
	List<RoomInfo> m_RoomInfo = new List<RoomInfo>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateList ()
	{
		EraseList();
		foreach (RoomInfo info in m_RoomInfo)
		{
			GameObject newPanel = GameObject.Instantiate(m_ItemPrefab) as GameObject;

		}
	}

	void EraseList()
	{
		for (int i = gameObject.transform.childCount; i < 0; i--)
		{
			GameObject.Destroy(gameObject.transform.GetChild(i - 1).gameObject);
		}
	}
}
