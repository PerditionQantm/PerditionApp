//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//
//public class MovementSelection : MonoBehaviour
//{
//		public Player m_Player;
//		public string[] m_PlaceList;
//		public int m_SelectionInt;
//
//		// Use this for initialization
//		void Start ()
//		{
//				
//		}
//	
//		// Update is called once per frame
//		void Update ()
//		{
//	
//		}
//
//		void OnEnable ()
//		{
//				m_SelectionInt = 0;
//				m_Player.eNextMovement = HouseLocation.NONE;
//		}
//
//		void OnGUI ()
//		{
//				m_PlaceList = Player.getLocationNames (Player.getPossibleMovements (m_Player.eLocation));
//				GUILayout.BeginVertical ();
//				m_SelectionInt = GUILayout.SelectionGrid (m_SelectionInt, m_PlaceList, 1, GUILayout.MinWidth (180));
//				GUILayout.EndVertical ();
//
//				m_Player.eNextMovement = Player.getPossibleMovements (m_Player.eLocation) [m_SelectionInt];
//		}
//}
