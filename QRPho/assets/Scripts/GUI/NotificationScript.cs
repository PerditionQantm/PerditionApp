using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotificationScript : MonoBehaviour {

	public GameObject goNotificationPanel;
	public GameObject goInfoPanel;
	public GameObject goCard2OptionPanel;
	public GameObject goCard3OptionPanel;
	private Button buContinueButton;
	private Text textInfo;
	public Text textQRResult;

	private Image imOption1;
	private Image imOption2;
	private Image imOption3;
	public Sprite sUnchecked;
	public Sprite sChecked;
	private Text textOption1;
	private Text textOption2;
	private Text textOption3;
	public bool bOption1Selected = false;
	public bool bOption2Selected = false;
	public bool bOption3Selected = false;
	private string sEffect;

	private UIController UIController;
	private PlayerStats PlayerStats;
	private CardHandler CardHandler;

	void Start ()
	{
		UIController = GameObject.FindWithTag ("UIController").GetComponent<UIController>();
		PlayerStats = GameObject.FindWithTag ("PlayerStats").GetComponent<PlayerStats>();
		CardHandler = GameObject.FindWithTag ("CardHandler").GetComponent<CardHandler>();
	}

	void Update ()
	{
		if (goCard2OptionPanel.activeInHierarchy)
		{
			imOption1 = GameObject.FindWithTag ("Choice1Box").GetComponent<Image>();
			imOption2 = GameObject.FindWithTag ("Choice2Box").GetComponent<Image>();

			if(bOption1Selected)
			{
				imOption1.overrideSprite = sChecked;
			}
			else
			{
				imOption1.overrideSprite = sUnchecked;
			}
			
			if(bOption2Selected)
			{
				imOption2.overrideSprite = sChecked;
			}
			else
			{
				imOption2.overrideSprite = sUnchecked;
			}
		}

		if (goCard3OptionPanel.activeInHierarchy)
		{
			imOption1 = GameObject.FindWithTag ("Choice1Box").GetComponent<Image>();
			imOption2 = GameObject.FindWithTag ("Choice2Box").GetComponent<Image>();
			imOption3 = GameObject.FindWithTag ("Choice3Box").GetComponent<Image>();

			if(bOption1Selected)
			{
				imOption1.overrideSprite = sChecked;
			}
			else
			{
				imOption1.overrideSprite = sUnchecked;
			}
			
			if(bOption2Selected)
			{
				imOption2.overrideSprite = sChecked;
			}
			else
			{
				imOption2.overrideSprite = sUnchecked;
			}

			if(bOption3Selected)
			{
				imOption3.overrideSprite = sChecked;
			}
			else
			{
				imOption3.overrideSprite = sUnchecked;
			}
		}

		if(PlayerStats.bIsStartOfYourTurn)
		{
			YourTurn();
			PlayerStats.bIsStartOfYourTurn = false;
		}

		if(textQRResult.text == "i:butchersknife")
		{
			goNotificationPanel.SetActive (true);
			goCard3OptionPanel.SetActive (true);
			goInfoPanel.SetActive (false);
			goCard2OptionPanel.SetActive (false);
			textInfo = GameObject.FindWithTag ("Info").GetComponent<Text>();
			textOption1 = GameObject.FindWithTag ("Choice1").GetComponent<Text>();
			textOption2 = GameObject.FindWithTag ("Choice2").GetComponent<Text>();
			textOption3 = GameObject.FindWithTag ("Choice3").GetComponent<Text>();
			buContinueButton = GameObject.FindWithTag ("ContinueButton").GetComponent<Button>();
			textInfo.text = "The butcher’s knife is thrown at you, grazing \n" +
				            "past and landing in the wall  \n" +
				            "behind you.";
			textOption1.text = "Run after the person who threw it at \n" +
				               "you, leaving the knife behind";
			textOption2.text = "Take knife and put it in back pocket, \n" +
				               "letting the person get away";
			textOption3.text = "Take knife in hand, letting the person \n" +
				               "get away";
			buContinueButton.onClick.RemoveAllListeners();
			if(bOption1Selected || bOption2Selected || bOption3Selected)
			{
				buContinueButton.onClick.AddListener(() => {
					textQRResult.text = "";
					UIController.OpenInvAfterScanner();
					if(bOption1Selected)
					{
						if(!PlayerStats.bEvidenceFound)
						{
							sEffect = "Evidence";
						}
						else
						{
							sEffect = "Deception Point";
						}
						CardHandler.AddCard ("Butcher's Knife", sEffect, 1);
					}
					if(bOption2Selected)
					{
						sEffect = "Extra Escape";
						CardHandler.AddCard ("Butcher's Knife", sEffect, 1);
					}
					if(bOption3Selected)
					{
						sEffect = "Extra Damage";
						CardHandler.AddCard ("Butcher's Knife", sEffect, 1);
					}
					ContinueButton();
				});
			}
		}

		if(textQRResult.text == "i:matchbook")
		{
			goNotificationPanel.SetActive (true);
			goCard2OptionPanel.SetActive (true);
			goInfoPanel.SetActive (false);
			goCard3OptionPanel.SetActive (false);
			textInfo = GameObject.FindWithTag ("Info").GetComponent<Text>();
			textOption1 = GameObject.FindWithTag ("Choice1").GetComponent<Text>();
			textOption2 = GameObject.FindWithTag ("Choice2").GetComponent<Text>();
			buContinueButton = GameObject.FindWithTag ("ContinueButton").GetComponent<Button>();
			textInfo.text = "You notice a small matchbook \n " +
				            "on the ground, it is red and \n" +
				            "black with light grazing on it \n" +
				            "from some use and you look inside. \n" +
				            "Only a couple of matches left. \n" +
				            "Two have been used. You remember \n" +
				            "witnesses say they noticed a \n" +
				            "burning cigar near the body of \n" +
	                        "the sheriff's wife";
			textOption1.text = "Take the matchbook, keeping it  \n" +
				               "for backing the witness testimony";
			textOption2.text = "Discard the burnt matches and  \n" +
				               "take the good ones";
			buContinueButton.onClick.RemoveAllListeners();
			if(bOption1Selected || bOption2Selected)
			{
				buContinueButton.onClick.AddListener(() => {
					textQRResult.text = "";
					UIController.OpenInvAfterScanner();
					if(bOption1Selected)
					{
						if(!PlayerStats.bEvidenceFound)
						{
							sEffect = "Evidence";
						}
						else
						{
							sEffect = "Deception Point";
						}
						CardHandler.AddCard ("Matchbook", sEffect, 1);
					}
					if(bOption2Selected)
					{
						sEffect = "Instant Skill Successes";
						CardHandler.AddCard ("Matchbook", sEffect, 6);
					}
					ContinueButton();
				});
			}
		}

//		if(textQRResult.text == "i:revolver")
//		{
//			goNotificationPanel.SetActive (true);
//			go2CardPanel.SetActive (true);
//			go3CardPanel.SetActive (false);
//			goInfoPanel.SetActive (false);
//			textCardInfo.text = "A silver revolver is dirty from \n" +
//				                "lying on the ground. A gunshot was \n" +
//				                "heard the night of the murder. Guns \n " +
//				                "are scarce in this town, and only a \n " +
//				                "handful of people have them, most \n " +
//				                "notably the sheriff’s department";
//			textOption1.text = "Take gun to use as evidence";
//			textOption2.text = "Load gun with your own bullets";
//			bu2CardContinueButton.onClick.RemoveAllListeners();
//			if(bOption1Selected || bOption2Selected || bOption3Selected)
//			{
//				bu2CardContinueButton.onClick.AddListener(() => {
//					textQRResult.text = "";
//					UIController.OpenCloseInvPanel();
//					ContinueButton();
//				});
//			}
//		}

		if(Input.GetKeyDown(KeyCode.M))
		{
			goNotificationPanel.SetActive (true);
			goInfoPanel.SetActive (true);
			goCard2OptionPanel.SetActive (false);
			goCard3OptionPanel.SetActive (false);
			textInfo = GameObject.FindWithTag ("Info").GetComponent<Text>();
			buContinueButton = GameObject.FindWithTag ("ContinueButton").GetComponent<Button>();
			textInfo.text = "You are being attacked! Defend yourslef";
			buContinueButton.onClick.RemoveAllListeners();
			buContinueButton.onClick.AddListener(() => {
				ContinueButton();
			});
		}
	}

	public void YourTurn ()
	{
		goNotificationPanel.SetActive (true);
		goInfoPanel.SetActive (true);
		goCard2OptionPanel.SetActive (false);
		goCard3OptionPanel.SetActive (false);
		textInfo = GameObject.FindWithTag ("Info").GetComponent<Text>();
		buContinueButton = GameObject.FindWithTag ("ContinueButton").GetComponent<Button>();
		textInfo.text = "It is your turn. Choose your action";
		buContinueButton.onClick.RemoveAllListeners();
		buContinueButton.onClick.AddListener(() => {
			PlayerStats.bIsYourTurn = true;
			ContinueButton();
			UIController.OpenCloseActionPanel();
		});
	}

	public void Option1Button ()
	{
		bOption1Selected = true;
		bOption2Selected = false;
		bOption3Selected = false;
	}

	public void Option2Button ()
	{
		bOption2Selected = true;
		bOption1Selected = false;
		bOption3Selected = false;
	}

	public void Option3Button ()
	{
		bOption3Selected = true;
		bOption2Selected = false;
		bOption1Selected = false;
	}

	public void ContinueButton ()
	{
		goNotificationPanel.SetActive (false);
		bOption1Selected = false;
		bOption2Selected = false;
		bOption3Selected = false;
	}
}
