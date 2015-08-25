using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public List<GameItem> l_items;

	public BarcodeCam scanInput;

	public Text txtList;

	public Text txtPassive;
	public Text txtAggressive;
	public Text txtStatic;
	public Text txtDynamic;

	public bool bWaitForAttitude = false;
	public GameItem itemTemp;

	// Use this for initialization
	void Start() {
		l_items = new List<GameItem>();
		//xmlDoc = new XDocument();

		txtList.text = "";
	}
	
	// Update is called once per frame
	void Update() {
		if (scanInput.sLastResult != "" && !bWaitForAttitude) {
			//Make sure it's a real item, helps prevent cheating and identify card type
			if (scanInput.sLastResult.Contains("item.") || scanInput.sLastResult.Contains("i:")) {
				itemTemp = null;

				if (scanInput.sLastResult.Contains("bell")) {
					//itemTemp = MakeItem(GAME_ITEMS.BELL, GAME_ATTITUDE.DYNAMIC);
				}
			}
		}
	}

//	public void AttitudeSelection(int tude) {
//		if (bWaitForAttitude) {
//			itemTemp = MakeItem(itemTemp.itemType, (GAME_ATTITUDE)tude);
//
//			bWaitForAttitude = false;
//
//			l_items.Add(itemTemp);
//			scanInput.sLastResult = "";
//			txtList.text += itemTemp.sName + "\n";
//		}
//	}
}
