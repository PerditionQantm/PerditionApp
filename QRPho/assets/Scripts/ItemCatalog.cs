using UnityEngine;

using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Linq;
using System.Linq;

using UnityEngine.UI;
using System.Text;

using System.IO;

public class ItemCatalog : MonoBehaviour {

	private XDocument s_xmlDoc;

	private List<string> l_sItems;
	public Dictionary<string, string> d_ssItems;
	public int iPage;

	private string s_sName = "Name";
	private string s_sDescription = "Desc.";

	public Text txtName;
	public Text txtDesc;
	public Text txtPages;
	public Text txtDebug;

	public bool bLoaded = false;

	// Use this for initialization
	void Start () {
		s_xmlDoc = new XDocument();
		l_sItems = new List<string>();
		d_ssItems = new Dictionary<string, string>();

//		if (Application.isMobilePlatform) {
//			LoadItemList("Assets/Resources/");
//			ClickToLoad(0);
//		}
//		else {
			//LoadItemList("jar:file://" + Application.dataPath + "!/assets/resources/");
		LoadItemListCompatability("Items");
			//LoadItemList(Application.streamingAssetsPath);
			//StartCoroutine("CopyFileASyncOnAndroid");
		//}

		//ClickToLoad(0);
	}

	public void LoadItemListCompatability(string path) {
		Object[] files = Resources.LoadAll(path, typeof(TextAsset));
		foreach (Object obj in files) {
			LoadItem(((TextAsset)obj).text);

			d_ssItems.Add(s_sName, s_sDescription);
		}
		bLoaded = true;
		//tl_sItems.AddRange(files);
	}

	public void LoadItemList(string path) {
		DirectoryInfo info = new DirectoryInfo(path);
		FileInfo[] fileInfo = info.GetFiles();
		try {
			foreach (FileInfo file in fileInfo) {
				if (file.Name.Substring(0, 5) == "item-" && !file.Name.Contains(".meta")) {
					l_sItems.Add("" + file.Name);
				}
			}
		}
		catch (IOException e) {
			txtDebug.text = e.Message;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!bLoaded) {
			//StartCoroutine("CopyFileASyncOnAndroid");
		}
		else {
			txtName.text = d_ssItems.ElementAt(iPage).Key;
			txtDesc.text = d_ssItems.ElementAt(iPage).Value;
			txtPages.text = "Page " + (iPage + 1).ToString() + " of " + d_ssItems.Count.ToString();
		}
	}

	public void ClickToLoad(int pagemove) {
		iPage += pagemove;
		iPage = Mathf.Clamp(iPage, 0, d_ssItems.Count - 1);

		//LoadItem(Application.persistentDataPath + "/" + l_sItems[iPage]);
	}

	public void LoadItem(string path) {
		s_xmlDoc = XDocument.Parse(path);
		
		foreach (XElement xroot in s_xmlDoc.Elements()) {
			foreach (XElement xlayer1 in xroot.Elements()) {
				if (xlayer1.Name == "name") {
					s_sName = xlayer1.Value;
					Debug.Log(s_sName);
				}
				else if (xlayer1.Name == "description") {
					s_sDescription = xlayer1.Value;
					Debug.Log(s_sDescription);
				}
			}
		}
	}

	IEnumerator CopyFileASyncOnAndroid() {
		string fromPath = Application.streamingAssetsPath + "/";
		//In Android = "jar:file://" + Application.dataPath + "!/assets/" 
		string toPath = Application.persistentDataPath + "/";
	
		foreach (string fileName in l_sItems) {
			Debug.Log("Copying from " + fromPath + fileName + " to " + toPath);
			WWW www1;
			if (Application.isMobilePlatform) {
				www1 = new WWW("file://" + fromPath + fileName);
			}
			else {
				www1 = new WWW("file:///" + fromPath + fileName);
			}
			yield return www1;

			//File.WriteAllBytes(toPath + fileName, www1.bytes);
			StreamWriter stream = File.CreateText(toPath + fileName);
			try {
				Debug.Log(www1.isDone);
				stream.WriteLine(www1.text.ToCharArray());
			}
			catch (IOException e) {
				Debug.Log(e.Message);
				txtDebug.text = e.Message;
			}
			stream.Close();

			Debug.Log("Copying of " + fileName + " complete");
		}

		bLoaded = true;
		ClickToLoad(0);
	} 

	public void ChangeScene(string scene) {
		PhotonNetwork.LoadLevel(scene);
	}
}
