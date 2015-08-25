using UnityEngine;
using UnityEditor;
public class PlayerPrefs : MonoBehaviour {

	[MenuItem("Edit/Reset Playerprefs")] 
	public static void DeletePlayerPrefs() { 
		PlayerPrefs.DeletePlayerPrefs(); 
	}
}
