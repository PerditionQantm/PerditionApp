using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;

using System.IO;

using UnityEngine.UI;

public class ItemEditor : EditorWindow {

	static private GUIStyle s_guiStyleDisabled;
	static private GUIStyle s_guiStyleAlert;

	static private Vector2 s_vScrollPos;
	static private Vector2 s_vItemsScrollPos;

	static private Dictionary<string, bool> s_dAttitudeToggleLookup;

	//Item bits
	static private string s_sName = "Goggles";
	static private string s_sDescription = "Nothing.";

	static private Dictionary<string, Attitude> s_dAttitudeLookup;
	static private List<Attitude> s_lAttitudes;

	//static private Dictionary<string, strin

	//Menu items
	[MenuItem("Window/Item Editor %&i")]
	private static void NewMenuOption() {
		Init(); 
	}
	
	//Window
	public static void Init() {
		ItemEditor window = (ItemEditor)EditorWindow.GetWindow(typeof(ItemEditor));

		s_lAttitudes = new List<Attitude>();
		s_dAttitudeLookup = new Dictionary<string, Attitude>();
		s_dAttitudeToggleLookup = new Dictionary<string, bool>();

		s_lAttitudes.Add(new Attitude("Dynamic"));
		s_lAttitudes.Add(new Attitude("Static"));
		s_lAttitudes.Add(new Attitude("Aggressive"));
		s_lAttitudes.Add(new Attitude("Passive"));

		foreach (Attitude tude in s_lAttitudes) {
			s_dAttitudeLookup.Add(tude.s_Name, tude);
			s_dAttitudeToggleLookup.Add(tude.s_Name, false);
		}

		//ReloadItemList();
		
		window.Show();
	}
	
	public void OnGUI() {
		s_vScrollPos = GUILayout.BeginScrollView(s_vScrollPos);

		//Item
		//========= GUI BEGIN
		GUILayout.Label("Name: ");
		s_sName = GUILayout.TextField(s_sName, 32);

		GUILayout.Label("Description: ");
		s_sDescription = GUILayout.TextArea(s_sDescription, 64, GUILayout.Height(45.0f));

		GUILayout.Label("Attitudes: ");
		foreach (KeyValuePair<string, Attitude> pair in s_dAttitudeLookup) {
			//Foldout toggle
			s_dAttitudeToggleLookup[pair.Key] = EditorGUILayout.Foldout(s_dAttitudeToggleLookup[pair.Key], pair.Key);

			if (s_dAttitudeToggleLookup[pair.Value.s_Name]) {
				//Desc
				GUILayout.Label("Description: ");
				pair.Value.s_Description = GUILayout.TextArea(pair.Value.s_Description, 64, GUILayout.Height(45.0f));

				//Stats
				pair.Value.fIntroversion = EditorGUILayout.FloatField("Introversion", pair.Value.fIntroversion);
				pair.Value.fExtraversion = EditorGUILayout.FloatField("Extraversion", pair.Value.fExtraversion);
				pair.Value.fIntuition = EditorGUILayout.FloatField("Intuition", pair.Value.fIntuition);
				pair.Value.fFeeling = EditorGUILayout.FloatField("Feeling", pair.Value.fFeeling);
				pair.Value.fSensing = EditorGUILayout.FloatField("Sensing", pair.Value.fSensing);
				pair.Value.fThinking = EditorGUILayout.FloatField("Thinking", pair.Value.fThinking);
				pair.Value.fPerception = EditorGUILayout.FloatField("Perception", pair.Value.fPerception);
				pair.Value.fJudging = EditorGUILayout.FloatField("Judging", pair.Value.fJudging);
			}
		}

//		s_bShowDynamic = EditorGUILayout.Foldout(s_bShowDynamic, "Dynamic");
//		if (s_bShowDynamic) {
//			GUILayout.Label("Description: ");
//			s_lAttitude = GUILayout.TextField(s_sDynamicDescription, 64);
//
//			GUILayout.Label("Myers-Briggs", EditorStyles.boldLabel);
//
//			GUILayout.Label("Intuition: ");
//			GUILayout.Label("Feeling: ");
//			GUILayout.Label("Sensing: ");
//			GUILayout.Label("Thinking: ");
//			GUILayout.Label("Perception: ");
//			GUILayout.Label("Introversion: ");
//			GUILayout.Label("Judging: ");
//			GUILayout.Label("Extraversion: ");
//		}

		//========= GUI END
		
		//File Select
		//========= GUI BEGIN
		GUILayout.BeginVertical("box");
		GUILayout.BeginHorizontal("box");
		if (GUILayout.Button("Save Item")) {
			//
		}

		GUILayout.Space(50.0f);
		
		if (GUILayout.Button("Load Item")) {
			//
		}
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		//========= GUI END

		GUILayout.EndScrollView();
	}
}
