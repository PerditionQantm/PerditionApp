using UnityEngine;
using System.Collections;

public class UICanvasWrapper : MonoBehaviour
{

	// Use this for initialization
	public string m_ssStartingPanel;

	void Start ()
	{
		UIPanelManager.Initialise ();
		UIPanelManager.OpenPanel (m_ssStartingPanel);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OpenPanel (string PanelName)
	{
		UIPanelManager.OpenPanel (PanelName);
	}

	public void PreviousPanel ()
	{
		UIPanelManager.PreviousPanel ();
	}
}
