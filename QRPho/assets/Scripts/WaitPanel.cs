using UnityEngine;
using System.Collections;

public class WaitPanel : MonoBehaviour
{
		public MenuManager m_Manager;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Space)) {
						m_Manager.OpenPanel ("MovePhase");
				}
		}
}
