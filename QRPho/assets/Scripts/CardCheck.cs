using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardCheck : MonoBehaviour {

	public Sprite sHunter;

	public Text TQRResult;
	public Image IAvatar;
	public Text TName;
	public GameObject ThreeHearts;
	public GameObject ThreeSwords;
	public Text TGoal;

	// Use this for initialization
	void Start () {
	
	}

	void Update ()
	{
		if(TQRResult.text == "c:hunter")
		{
			IAvatar.overrideSprite = sHunter;
			TName.text = "Hunter";
			ThreeHearts.SetActive (true);
			ThreeSwords.SetActive (true);
			TGoal.text = "Goal: Hunt down and kill the ghost";
		}
	}
}
