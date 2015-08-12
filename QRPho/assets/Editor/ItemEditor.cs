using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Linq;
using System.Linq;

using UnityEngine.UI;
using System.Text;

public enum EDIT_TYPE {
	ITEM,
	EVENT
}

public class ItemEditor : EditorWindow {

	static private EDIT_TYPE s_iEditor = EDIT_TYPE.ITEM;

	static private GUIStyle s_guiStyleDisabled;
	static private GUIStyle s_guiStyleAlert;

	static private Vector2 s_vScrollPos;
	static private Vector2 s_vItemsScrollPos;

	static private Dictionary<string, bool> s_dAttitudeToggleLookup;

	static private XDocument s_xmlDoc;
	static private string s_sLastFile;

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

		s_lAttitudes.Add(new Attitude("Dynamic", ""));
		s_lAttitudes.Add(new Attitude("Static", ""));
		s_lAttitudes.Add(new Attitude("Aggressive", ""));
		s_lAttitudes.Add(new Attitude("Passive", ""));

		foreach (Attitude tude in s_lAttitudes) {
			s_dAttitudeLookup.Add(tude.s_Name, tude);
			s_dAttitudeToggleLookup.Add(tude.s_Name, false);
		}

		s_xmlDoc = new XDocument();

		//ReloadItemList();
		
		window.Show();
	}
	
	public void OnGUI() {
		s_vScrollPos = GUILayout.BeginScrollView(s_vScrollPos);

		s_iEditor = (EDIT_TYPE)EditorGUILayout.EnumPopup("Edit Type", s_iEditor);

		if (s_iEditor == EDIT_TYPE.ITEM) {
			//Item
			//========= GUI BEGIN
			GUI.SetNextControlName("Top");
			GUILayout.Label("Name: ");
			s_sName = GUILayout.TextField(s_sName, 32);

			GUILayout.Space(20.0f);
			GUILayout.Label("Description: ");
			s_sDescription = GUILayout.TextArea(s_sDescription, 64, GUILayout.Height(45.0f));

			GUILayout.Space(20.0f);
			GUILayout.Label("Attitudes: ");
			foreach (KeyValuePair<string, Attitude> pair in s_dAttitudeLookup) {
				GUILayout.BeginVertical("box");
				//Foldout toggle
				s_dAttitudeToggleLookup[pair.Key] = EditorGUILayout.Foldout(s_dAttitudeToggleLookup[pair.Key], pair.Key);

				if (s_dAttitudeToggleLookup[pair.Value.s_Name]) {
					//Desc
					GUILayout.Label("Description: ");
					pair.Value.s_Description = GUILayout.TextArea(pair.Value.s_Description, 64, GUILayout.Height(45.0f));

					//Stats
					pair.Value.dMyersBriggsLookup["introversion"] = EditorGUILayout.FloatField("Introversion", pair.Value.dMyersBriggsLookup["introversion"]);
					pair.Value.dMyersBriggsLookup["extraversion"] = EditorGUILayout.FloatField("Extraversion", pair.Value.dMyersBriggsLookup["extraversion"]);
					pair.Value.dMyersBriggsLookup["intuition"] = EditorGUILayout.FloatField("Intuition", pair.Value.dMyersBriggsLookup["intuition"]);
					pair.Value.dMyersBriggsLookup["feeling"] = EditorGUILayout.FloatField("Feeling", pair.Value.dMyersBriggsLookup["feeling"]);
					pair.Value.dMyersBriggsLookup["sensing"] = EditorGUILayout.FloatField("Sensing", pair.Value.dMyersBriggsLookup["sensing"]);
					pair.Value.dMyersBriggsLookup["thinking"] = EditorGUILayout.FloatField("Thinking", pair.Value.dMyersBriggsLookup["thinking"]);
					pair.Value.dMyersBriggsLookup["perception"] = EditorGUILayout.FloatField("Perception", pair.Value.dMyersBriggsLookup["perception"]);
					pair.Value.dMyersBriggsLookup["judging"] = EditorGUILayout.FloatField("Judging", pair.Value.dMyersBriggsLookup["judging"]);
				}
				GUILayout.EndVertical();
			}
			//========= GUI END
			
			//File Select
			//========= GUI BEGIN
			GUILayout.Space(20.0f);
			GUILayout.BeginVertical("box");
			GUILayout.BeginHorizontal("box");
			if (GUILayout.Button("Save Item")) {
				s_sLastFile = EditorUtility.SaveFilePanel("Save item", "/Resources/ItemFiles/", s_sName.ToLower(), "xml");
				if (s_sLastFile.Length != 0) {
					GUI.FocusControl("Top");
					SaveItem(s_sLastFile);
				}
			}

			GUILayout.Space(50.0f);
			
			if (GUILayout.Button("Load Item")) {
				s_sLastFile = EditorUtility.OpenFilePanel("Load item", "/Resources/ItemFiles/", "xml");
				if (s_sLastFile.Length != 0) {
					GUI.FocusControl("Top");
					LoadItem(s_sLastFile);
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
			//========= GUI END
		}
		else {
			//Event
			//========= GUI BEGIN

			//========= GUI END
		}

		GUILayout.EndScrollView();
	}

	public static void SaveItem(string path) {
		XmlWriterSettings xsettings = new XmlWriterSettings();
		xsettings.Encoding = Encoding.ASCII;
		xsettings.OmitXmlDeclaration = true;
		
		XmlWriter writer = XmlWriter.Create(s_sLastFile, xsettings);

		//Document open
		writer.WriteStartDocument();
		writer.WriteStartElement("item");
		writer.WriteWhitespace("\n");
		
		//Name
		writer.WriteWhitespace("\t");
		writer.WriteStartElement("name");
		writer.WriteValue(s_sName);
		writer.WriteEndElement();
		writer.WriteWhitespace("\n");
		
		//Description
		writer.WriteWhitespace("\t");
		writer.WriteStartElement("description");
		writer.WriteValue(s_sDescription);
		writer.WriteEndElement();
		writer.WriteWhitespace("\n");
		
		writer.WriteWhitespace("\n");

		foreach (KeyValuePair<string, Attitude> tude in s_dAttitudeLookup) {
			//Attitude
			writer.WriteWhitespace("\t");
			writer.WriteStartElement("attitude");
			writer.WriteWhitespace("\n");

			//Name
			writer.WriteWhitespace("\t\t");
			writer.WriteStartElement("name");
			writer.WriteValue(tude.Value.s_Name);
			writer.WriteEndElement();
			writer.WriteWhitespace("\n");

			//Description
			writer.WriteWhitespace("\t\t");
			writer.WriteStartElement("description");
			writer.WriteValue(tude.Value.s_Description);
			writer.WriteEndElement();
			writer.WriteWhitespace("\n");

			writer.WriteWhitespace("\n");

			foreach (KeyValuePair<string, float> pair in tude.Value.dMyersBriggsLookup) {
				if (pair.Value > 0) {
					writer.WriteWhitespace("\t\t");
					writer.WriteStartElement(pair.Key);
					writer.WriteValue(pair.Value);
					writer.WriteEndElement();
					writer.WriteWhitespace("\n");
				}
			}

			writer.WriteWhitespace("\t");
			writer.WriteEndElement();
			writer.WriteWhitespace("\n");
		}

		//Document end
		writer.WriteEndElement();
		writer.WriteEndDocument();
		
		writer.Close();
	}

	public void LoadItem(string path) {
		s_xmlDoc = XDocument.Load(path);
		
		foreach (XElement xroot in s_xmlDoc.Elements()) {
			foreach (XElement xlayer1 in xroot.Elements()) {
				if (xlayer1.Name == "name") {
					s_sName = xlayer1.Value;
				}
				else if (xlayer1.Name == "description") {
					s_sDescription = xlayer1.Value;
				}
				
				if (xlayer1.Name == "attitude") {
					string tudename = "";

					foreach (XElement xlayer2 in xlayer1.Elements()) {
						if (xlayer2.Name == "name") {
							s_dAttitudeLookup[xlayer2.Value].s_Name = xlayer2.Value;
							tudename = xlayer2.Value;
						}
						else if (xlayer2.Name == "description") {
							s_dAttitudeLookup[tudename].s_Description = xlayer2.Value;
						}

						if (s_dAttitudeLookup[tudename].dMyersBriggsLookup.ContainsKey(xlayer2.Name.ToString())) {
							s_dAttitudeLookup[tudename].dMyersBriggsLookup[xlayer2.Name.ToString()] = float.Parse(xlayer2.Value);
						}
					}
				}
			}
		}
	}
}
