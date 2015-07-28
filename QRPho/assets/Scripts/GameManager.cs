using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	LanguageHandler lang;
	
	void Start() {
		//lang.l_langs.Add(LanguageHandler.Load("Assets/Resources/lang-en.xml"));
		lang = new LanguageHandler();
		lang.LoadAllLanguages("Assets/Resources/Languages/");

		//Debug.Log(lang.GetDefaultLanguage().GameTitle);
	}

	void Update() {
	
	}
}
