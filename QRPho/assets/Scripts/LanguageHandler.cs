using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

//[XmlRoot("language")]
public class LanguageHandler {

	//[XmlArray("strings")]
	//[XmlArrayItem("")]
	public List<GameLanguage> l_langs = new List<GameLanguage>();

//	public static GameLanguage Load(string path) {
//		var serializer = new XmlSerializer(typeof(GameLanguage));
//		using (var stream = new FileStream(path, FileMode.Open)) {
//			return serializer.Deserialize(stream) as GameLanguage;
//		}
//	}

	public void LoadAllLanguages(string path) {
		DirectoryInfo info = new DirectoryInfo(path);
		var fileInfo = info.GetFiles();
		foreach (FileInfo file in fileInfo) {
			if (file.Name.Contains("lang-")) {
				//StringReader stringReader = new StringReader(path + file.Name);
				//stringReader.Read();

				l_langs.Add(new GameLanguage());
				l_langs[l_langs.Count - 1].Load(path + file.Name);
			}
		}
	}

	public GameLanguage GetDefaultLanguage() {
		if (l_langs.Count > 0) {
			return l_langs[0];
		}
		else {
			return null;
		}
	}
}
