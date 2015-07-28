using System.Xml;
using System.Xml.Linq;
using System.Linq;

using System.Collections.Generic;

//[XmlRoot("language")]
public class GameLanguage {

	public Dictionary<string, string> d_strings;
	private XDocument s_xmlDoc;

	public void Load(string path) {
		//if (s_xmlDoc == null) {
			s_xmlDoc = new XDocument();
		//}

		s_xmlDoc = XDocument.Load(path);

		//if (d_strings != null) {
			//d_strings.Clear();
		//}
		//else {
			d_strings = new Dictionary<string, string>();
		//}


		foreach (XElement xroot in s_xmlDoc.Elements()) {
			foreach (XElement xlayer1 in xroot.Elements()) {
				d_strings.Add(xlayer1.Name.ToString(), xlayer1.Value);
			}
		}
	}

	public string GetString(string key) {
		string temp = "";

		if (d_strings.TryGetValue(key, out temp)) {
			return temp;
		}
		else {
			return "Error";
		}
	}
//	[XmlElement("LanguageName")]
//	public string LanguageName;
//	[XmlElement("GameTitle")]
//	public string GameTitle;
//	[XmlElement("MenuPlay")]
//	public string MenuPlay;
//	[XmlElement("MenuHost")]
//	public string MenuHost;
//	[XmlElement("MenuQuit")]
//	public string MenuQuit;
//	[XmlElement("MenuCancel")]
//	public string MenuCancel;
//	[XmlElement("MenuBack")]
//	public string MenuBack;
//	[XmlElement("MenuSearch")]
//	public string MenuSearch;
//	[XmlElement("MenuDeceive")]
//	public string MenuDeceive;
//	[XmlElement("MenuMove")]
//	public string MenuMove;
//	[XmlElement("MenuAttack")]
//	public string MenuAttack;
//	[XmlElement("MenuProbe")]
//	public string MenuProbe;
//	[XmlElement("MenuInterrogate")]
//	public string MenuInterrogate;
//
//
//	[XmlElement("Narration_WildWest_Intro")]
//	public string Narration_WildWest_Intro;
//	[XmlElement("Narration_WildWest_GoodguyFailure")]
//	public string Narration_WildWest_GoodguyFailure;
}
