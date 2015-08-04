using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

static public class UIPanelManager
{

	static public List<Transform> m_lPanelList { get; private set; }

	static public Transform m_CurrentPanel { get; private set; }
	static public Stack<Transform> m_stPreviousPanel { get; private set; }

	static Transform m_Canvas;


	// Use this for initialization
	static public void Initialise ()
	{
		m_Canvas = GameObject.Find ("Canvas").transform;
		m_stPreviousPanel = new Stack<Transform> ();
		m_lPanelList = new List<Transform> ();
		{
			foreach (Transform chd in m_Canvas.gameObject.GetComponentsInChildren<Transform>(true))
			{
				if ((chd.gameObject != m_Canvas.gameObject) && chd.name.Contains ("panel_"))
				{
					m_lPanelList.Add (chd);
					chd.gameObject.SetActive (false);
				}
			}
		}
		//Debug.Log ("Number of Panels: " + m_PanelList.Count);
		m_CurrentPanel = null;
		//				if (m_ssOpeningPanel != "") {
		//						if (m_lPanelList.Exists (x => x.name.Contains ("_" + m_ssOpeningPanel))) {
		//								m_CurrentPanel = m_lPanelList.Find (x => x.name.Contains ("_" + m_ssOpeningPanel));
		//								m_CurrentPanel.gameObject.SetActive (true);
		//								SetBackButton ();
		//						} else {
		//								Debug.Log (m_ssOpeningPanel + " does not exist as a UI Panel");
		//						}
		//				}
	}

	// Update is called once per frame

	static public void OpenPanel (string newPanel)
	{
		if (m_lPanelList.Exists (x => x.name.Contains ("_" + newPanel)))
		{
			if (m_CurrentPanel != null)
			{
				m_CurrentPanel.gameObject.SetActive (false);
				m_stPreviousPanel.Push (m_CurrentPanel);
			}
			m_CurrentPanel = m_lPanelList.Find (x => x.name.Contains ("_" + newPanel));
			m_CurrentPanel.gameObject.SetActive (true);
			SetBackButton ();
		} else
		{
			Debug.Log (newPanel + " does not exist as a UI Panel");
		}
	}

	static public void PreviousPanel ()
	{
		m_CurrentPanel.gameObject.SetActive (false);
		m_CurrentPanel = m_stPreviousPanel.Pop ();
		m_CurrentPanel.gameObject.SetActive (true);
		SetBackButton ();

	}

	static public void SetBackButton ()
	{
		foreach (Transform butt in m_CurrentPanel.GetComponentsInChildren<Transform>(true))
		{
			if (butt.name == "button_Back")
			{
				butt.gameObject.SetActive (m_stPreviousPanel.Count == 0 ? false : true);
			}
		}
	}

	static public Transform getUIElementOnPanel (string name, bool includeInactive = false)
	{
		if (m_CurrentPanel != null)
		{
			List<Transform> lTemp = new List<Transform> (m_CurrentPanel.GetComponentsInChildren<Transform> (includeInactive));
			if (lTemp.Exists (x => x.name.Contains ("_" + name)))
			{
				return lTemp.Find (x => x.name.Contains ("_" + name));
			} else
			{
				Debug.Log (name + " does not Exist as a UI Element in this Panel");
				return null;
			}
		} else
		{
			Debug.Log ("No Active Panel");
			return null;
		}
	}

	static public Transform[] getUIElementsOfPrefix (string prefix, bool includeInactive = false)
	{
		if (m_CurrentPanel != null)
		{
			List<Transform> lTemp = new List<Transform> (m_CurrentPanel.GetComponentsInChildren<Transform> (includeInactive));
			if (lTemp.Exists (x => x.name.Contains (prefix + "_")))
			{
				return lTemp.FindAll (x => x.name.Contains (prefix + "_")).ToArray ();
			} else
			{
				Debug.Log (prefix + " does not Exist as a UI Element in this Panel");
				return null;
			}

		} else
		{
			Debug.Log ("No Active Panel");
			return null;
		}
	}

	static public Transform InstantiateGUIElement (string name, string parentPanel = "")
	{
		GameObject tempObj = Resources.Load<GameObject> ("Prefabs/" + name);
		//tempObj.GetComponent<CanvasRenderer> () != null
		if (tempObj != null)
		{
			GameObject createdObj = GameObject.Instantiate<GameObject> (tempObj);
			if (parentPanel == "")
			{
				createdObj.transform.SetParent (m_CurrentPanel, false);
			} else
			{
				createdObj.transform.SetParent (getUIElementOnPanel (parentPanel), false);
			}
			return createdObj.transform;
		} else
		{
			Debug.Log ("ERROR: Does Not Exist");
			return null;
		}
	}

	static public bool setButtonUsable (string buttonName, bool interactable)
	{
		if (m_CurrentPanel.GetComponentsInChildren<Button> ().Length != 0)
		{
			List<Transform> tempList = new List<Transform> (m_CurrentPanel.GetComponentsInChildren<Transform> ());
			tempList.RemoveAll (x => x.gameObject.GetComponent<Button> () == null && !x.gameObject.name.Contains (buttonName));
			if (tempList.Count > 0)
			{
				foreach (Transform t in tempList)
				{
					t.gameObject.GetComponent<Button> ().interactable = interactable;
				}
				return true;
			}
		}
		Debug.Log ("Error: No Button called " + buttonName + " in this panel");
		return false;
	}
}