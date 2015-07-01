using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
	
		public List<Transform> m_lUIChildren { get; private set; }
		public Transform m_tActive { get; private set; }
		public Transform m_tPrevious = null;
	
		// Use this for initialization
		void Start ()
		{
				m_lUIChildren = new List<Transform> ();
				m_lUIChildren.AddRange (GetComponentsInChildren<Transform> (true));
		
				m_lUIChildren.RemoveAll (x => x.gameObject.layer != LayerMask.NameToLayer ("UI"));
				m_lUIChildren.RemoveAll (x => !x.name.Contains ("Panel"));
		
				//Debug.Log (m_lUIChildren.Count);
				//m_lUIChildren.Remove (this.transform);
		
				m_tActive = m_lUIChildren.Find (x => x.gameObject.name.Contains ("Turn Choice"));
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
		public void OpenPanel (string PanelName)
		{
				Transform temp = m_tActive;
				m_tPrevious = m_tActive;
				m_tActive = m_lUIChildren.Find (x => x.gameObject.name.Contains (PanelName));
				if (m_tActive != null) {
						m_tActive.gameObject.SetActive (true);
						temp.gameObject.SetActive (false);
				} else {
						Debug.LogError ("Can't find a panel name that contains \"" + PanelName + "\"!");
				}
		}
		public void OpenPanelWithOptions (Object Options)
		{
				/*Transform temp = m_tActive;
				m_tPrevious = m_tActive;
				m_tActive = m_lUIChildren.Find (x => x.gameObject.name.Contains (PanelName));
				if (m_tActive != null) {
						m_tActive.gameObject.SetActive (true);
						temp.gameObject.SetActive (false);
				} else {
						Debug.LogError ("Can't find a panel name that contains \"" + PanelName + "\"!");
				}*/
		}

		public void OpenPreviousPanel ()
		{
				if (m_tPrevious != null) {
						Transform temp = m_tActive;
						m_tActive = m_tPrevious;
						m_tPrevious = temp;

						m_tActive.gameObject.SetActive (true);
						m_tPrevious.gameObject.SetActive (false);
				}
		}
	
		public void ClosePanels ()
		{
				m_lUIChildren.ForEach (y => y.gameObject.SetActive (false));
		}
}
