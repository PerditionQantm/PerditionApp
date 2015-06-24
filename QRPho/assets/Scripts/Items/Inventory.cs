//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
////using System.Xml.Linq;
////using System.Linq;
//
//using UnityEngine.UI;
//
//public class Inventory : MonoBehaviour {
//
//	public List<GameItem> l_items;
//
//	//private XDocument xmlDoc;
//
//	public BarcodeCam scanInput;
//
//	public Text txtList;
//
//	public Text txtPassive;
//	public Text txtAggressive;
//	public Text txtStatic;
//	public Text txtDynamic;
//
//	public bool bWaitForAttitude = false;
//	public GameItem itemTemp;
//
//	// Use this for initialization
//	void Start() {
//		l_items = new List<GameItem>();
//		//xmlDoc = new XDocument();
//
//		txtList.text = "";
//	}
//	
//	// Update is called once per frame
//	void Update() {
//		if (scanInput.sLastResult != "" && !bWaitForAttitude) {
//			//Make sure it's a real item, helps prevent cheating and identify card type
//			if (scanInput.sLastResult.Contains("item.")) {
//				itemTemp = null;
//
//				if (scanInput.sLastResult.Contains(".bell")) {
//					itemTemp = MakeItem(GAME_ITEMS.BELL, GAME_ATTITUDE.DYNAMIC);
//				}
//
//				if (itemTemp != null) {
//					txtStatic.text = itemTemp.sStaticString;
//					txtDynamic.text = itemTemp.sDynamicString;
//					txtPassive.text = itemTemp.sPassiveString;
//					txtAggressive.text = itemTemp.sAggressiveString;
//					
//					bWaitForAttitude = true;
//				}
//			}
//		}
//
//		if (Input.GetKeyDown(KeyCode.F)) {
//			l_items.Add(MakeItem(GAME_ITEMS.BELL, GAME_ATTITUDE.DYNAMIC));
//			l_items.Add(MakeItem(GAME_ITEMS.BELL, GAME_ATTITUDE.AGGRESSIVE));
//		}
//	}
//
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
//
//	public GameItem MakeItem(GAME_ITEMS item, GAME_ATTITUDE feel) {
//		//xmlDoc = XDocument.Load(Application.dataPath + "\\Scripts\\Items\\" + item.ToString().ToLower() + ".xml");
//
//		GameItem newitem = new GameItem();
//		//newitem.itemType = item;
//
//
//
////		foreach (XElement xroot in xmlDoc.Elements()) {
////			//Debug.Log(xroot.Name);
////			foreach (XElement xlayer1 in xroot.Elements()) {
////				if (xlayer1.Name == "name") {
////					Debug.Log("\t" + "Item name: " + xlayer1.Value);
////					newitem.sName = xlayer1.Value;
////				}
////				else if (xlayer1.Name == "description") {
////					Debug.Log("\t" + "Description: " + xlayer1.Value);
////					newitem.sDescription = xlayer1.Value;
////				}
////				foreach (XElement xlayer2 in xlayer1.Elements()) {
////					if (xlayer2.Name == "description") {
////						//Debug.Log("\t\t" + "Attitude: " + xlayer2.Value);
////						if (xlayer1.Name == "dynamic") {
////							newitem.sDynamicString = xlayer2.Value;
////						}
////						else if (xlayer1.Name == "static") {
////							newitem.sStaticString = xlayer2.Value;
////						}
////						else if (xlayer1.Name == "passive") {
////							newitem.sPassiveString = xlayer2.Value;
////						}
////						else if (xlayer1.Name == "aggressive") {
////							newitem.sAggressiveString = xlayer2.Value;
////						}
////					}
////
////					if (xlayer1.Name == feel.ToString().ToLower()) {
////						if (xlayer2.Name == "intuition") {
////							Debug.Log("\t\t" + "Intuition: " + xlayer2.Value);
////							newitem.fIntuition = float.Parse(xlayer2.Value, System.Globalization.CultureInfo.InvariantCulture); 
////						}
////						else if (xlayer2.Name == "feeling") {
////							Debug.Log("\t\t" + "Feeling: " + xlayer2.Value);
////							newitem.fFeeling = float.Parse(xlayer2.Value, System.Globalization.CultureInfo.InvariantCulture); 
////						}
////						else if (xlayer2.Name == "sensing") {
////							Debug.Log("\t\t" + "Sensing: " + xlayer2.Value);
////							newitem.fSensing = float.Parse(xlayer2.Value, System.Globalization.CultureInfo.InvariantCulture); 
////						}
////						else if (xlayer2.Name == "thinking") {
////							Debug.Log("\t\t" + "Thinking: " + xlayer2.Value);
////							newitem.fThinking = float.Parse(xlayer2.Value, System.Globalization.CultureInfo.InvariantCulture); 
////						}
////						else if (xlayer2.Name == "perception") {
////							Debug.Log("\t\t" + "Perception: " + xlayer2.Value);
////							newitem.fPerception = float.Parse(xlayer2.Value, System.Globalization.CultureInfo.InvariantCulture); 
////						}
////						else if (xlayer2.Name == "introversion") {
////							Debug.Log("\t\t" + "Introversion: " + xlayer2.Value);
////							newitem.fIntroversion = float.Parse(xlayer2.Value, System.Globalization.CultureInfo.InvariantCulture); 
////						}
////						else if (xlayer2.Name == "judging") {
////							Debug.Log("\t\t" + "Judging: " + xlayer2.Value);
////							newitem.fJudging = float.Parse(xlayer2.Value, System.Globalization.CultureInfo.InvariantCulture); 
////						}
////						else if (xlayer2.Name == "extraversion") {
////							Debug.Log("\t\t" + "Extraversion: " + xlayer2.Value);
////							newitem.fExtraversion = float.Parse(xlayer2.Value, System.Globalization.CultureInfo.InvariantCulture); 
////						}
////					}
////				}
////			}
////		}
//
//		return newitem;
//	}
//}
