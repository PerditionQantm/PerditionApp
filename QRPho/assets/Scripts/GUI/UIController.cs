using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public RectTransform rectPositionStart;
	public RectTransform rectPositionEnd;
	public RectTransform rectActionPanel;
	public RectTransform rectInfoPanel;
	public RectTransform rectInvPanel;
	public RectTransform rectDiceRollerPanel;
	public RectTransform rectScannerPanel;

	public Transform tranDiceRollerPositionStart;
	public Transform tranDiceRollerPositionEnd;
	public GameObject goDiceRollerCamera;
	public GameObject goScanCamera;

	private float fActionTimer = 0f;
	public bool bIsActionOpen = false;
	public bool bIsActionMoving = false;
	private float fInfoTimer = 0f;
	public bool bIsInfoOpen = false;
	public bool bIsInfoMoving = false;
	private float fInvTimer = 0f;
	public bool bIsInvOpen = false;
	public bool bIsInvMoving = false;
	private float fDiceRollerTimer = 0f;
	public bool bIsDiceRollerOpen = false;
	public bool bIsDiceRollerMoving = false;
	private float fScannerTimer = 0f;
	public bool bIsScannerOpen = false;
	public bool bIsScannerMoving = false;

	private DiceCalculator DiceCalculator;

	void Start ()
	{
		DiceCalculator = GameObject.FindWithTag ("DiceCalculator").GetComponent<DiceCalculator>();
		goScanCamera.SetActive (false);
	}

	void Update () 
	{
		fActionTimer = Mathf.Clamp (fActionTimer, 0, 1);
		fInfoTimer = Mathf.Clamp (fInfoTimer, 0, 1);
		fInvTimer = Mathf.Clamp (fInvTimer, 0, 1);
		fDiceRollerTimer = Mathf.Clamp (fDiceRollerTimer, 0, 1);
		fScannerTimer = Mathf.Clamp (fScannerTimer, 0, 1);

		if(bIsActionOpen)
		{
			fActionTimer += 2 * Time.deltaTime;
			rectActionPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
			                                                   rectPositionEnd.transform.position,
			                                                   fActionTimer);
			if (fActionTimer >= 1f)
			{
				bIsActionMoving = false;
			}
		}
		else
		{
			fActionTimer -= 2 * Time.deltaTime;
			if (Time.time > 2f)
			{
				rectActionPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
				                                                   rectPositionEnd.transform.position,
				                                                   fActionTimer);
				if (fActionTimer <= 0f)
				{
					bIsActionMoving = false;
				}
			}
		}

		if(bIsInfoOpen)
		{
			fInfoTimer += 2 * Time.deltaTime;
			rectInfoPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
			                                                 rectPositionEnd.transform.position,
			                                                 fInfoTimer);
			if (fInfoTimer >= 1f)
			{
				bIsInfoMoving = false;
			}
		}
		else
		{
			fInfoTimer -= 2 * Time.deltaTime;
			if (Time.time > 2f)
			{
				rectInfoPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
				                                                 rectPositionEnd.transform.position,
				                                                 fInfoTimer);
				if (fInfoTimer <= 0f)
				{
					bIsInfoMoving = false;
				}
			}
		}

		if(bIsInvOpen)
		{
			fInvTimer += 2 * Time.deltaTime;
			rectInvPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
			                                                rectPositionEnd.transform.position,
			                                                fInvTimer);
			if (fInvTimer >= 1f)
			{
				bIsInvMoving = false;
			}
		}
		else
		{
			fInvTimer -= 2 * Time.deltaTime;
			if (Time.time > 2f)
			{
				rectInvPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
				                                                rectPositionEnd.transform.position,
				                                                fInvTimer);
				if (fInvTimer <= 0f)
				{
					bIsInvMoving = false;
				}
			}
		}

		if(bIsDiceRollerOpen)
		{
			fDiceRollerTimer += 2 * Time.deltaTime;
			rectDiceRollerPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
			                                                       rectPositionEnd.transform.position,
			                                                       fDiceRollerTimer);

			goDiceRollerCamera.transform.position = Vector3.Lerp (tranDiceRollerPositionStart.transform.position,
			                                                      tranDiceRollerPositionEnd.transform.position,
			                                                      fDiceRollerTimer);
			if (fDiceRollerTimer >= 1f)
			{
				bIsDiceRollerMoving = false;
			}
		}
		else
		{
			fDiceRollerTimer -= 2 * Time.deltaTime;
			if (Time.time > 2f)
			{
				rectDiceRollerPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
				                                                       rectPositionEnd.transform.position,
				                                                       fDiceRollerTimer);

				goDiceRollerCamera.transform.position = Vector3.Lerp (tranDiceRollerPositionStart.transform.position,
				                                                      tranDiceRollerPositionEnd.transform.position,
				                                                      fDiceRollerTimer);
				if (fDiceRollerTimer <= 0f)
				{
					bIsDiceRollerMoving = false;
				}
			}
		}

		if(bIsScannerOpen)
		{
			fScannerTimer += 2 * Time.deltaTime;
			rectScannerPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
			                                                    rectPositionEnd.transform.position,
			                                                    fScannerTimer);

			if (fScannerTimer >= 1f)
			{
				bIsScannerMoving = false;
			}
		}
		else
		{
			fScannerTimer -= 2 * Time.deltaTime;
			if (Time.time > 2f)
			{
				rectScannerPanel.transform.position = Vector3.Lerp (rectPositionStart.transform.position,
				                                                    rectPositionEnd.transform.position,
				                                                    fScannerTimer);

				if (fScannerTimer <= 0f)
				{
					bIsScannerMoving = false;
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.Z))
		{
			OpenCloseActionPanel();
		}

		if (Input.GetKeyDown(KeyCode.X))
		{
			OpenCloseInfoPanel();
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			OpenCloseInvPanel();
		}

		if (Input.GetKeyDown(KeyCode.V))
		{
			OpenCloseDiceRollerPanel();
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			OpenCloseScannerPanel();
		}

	}

	public void OpenCloseActionPanel ()
	{
		if (!bIsActionMoving && !bIsInfoMoving && !bIsInvMoving && !bIsDiceRollerMoving && !bIsScannerOpen && !bIsDiceRollerOpen && !bIsScannerMoving && !DiceCalculator.bOpenedDiceRoller)
		{
			bIsActionOpen = !bIsActionOpen;
			bIsActionMoving = true;
		}
		if (bIsInfoOpen && !bIsInfoMoving)
		{
			bIsActionOpen = true;
			bIsInfoOpen = false;
			bIsActionMoving = true;
			bIsInfoMoving = true;
		}
		if (bIsInvOpen && !bIsInvMoving && !DiceCalculator.bOpenedDiceRoller)
		{
			bIsActionOpen = true;
			bIsInvOpen = false;
			bIsActionMoving = true;
			bIsInvMoving = true;
		}
//		if (bIsDiceRollerOpen && !bIsDiceRollerMoving)
//		{
//			bIsActionOpen = true;
//			bIsDiceRollerOpen = false;
//			bIsActionMoving = true;
//			bIsDiceRollerMoving = true;
//			DiceCalculator.ResetDiceBoard();
//		}
//		if (bIsScannerOpen && !bIsScannerMoving)
//		{
//			bIsActionOpen = true;
//			bIsScannerOpen = false;
//			bIsActionMoving = true;
//			bIsScannerMoving = true;
//			if(goScanCamera.activeInHierarchy)
//			{
//				goScanCamera.SetActive (false);
//			}
//			else
//			{
//				goScanCamera.SetActive (true);
//			}
//		}
	}

	public void OpenCloseInfoPanel ()
	{
		if (!bIsInfoMoving && !bIsActionMoving && !bIsInvMoving && !bIsDiceRollerMoving && !bIsScannerOpen && !bIsDiceRollerOpen && !bIsScannerMoving && !DiceCalculator.bOpenedDiceRoller)
		{
			bIsInfoOpen = !bIsInfoOpen;
			bIsInfoMoving = true;
		}
		if (bIsActionOpen && !bIsActionMoving)
		{
			bIsInfoOpen = true;
			bIsActionOpen = false;
			bIsInfoMoving = true;
			bIsActionMoving = true;
		}
		if (bIsInvOpen && !bIsInvMoving && !DiceCalculator.bOpenedDiceRoller)
		{
			bIsInfoOpen = true;
			bIsInvOpen = false;
			bIsInfoMoving = true;
			bIsInvMoving = true;
		}
//		if (bIsDiceRollerOpen && !bIsDiceRollerMoving)
//		{
//			bIsInfoOpen = true;
//			bIsDiceRollerOpen = false;
//			bIsInfoMoving = true;
//			bIsDiceRollerMoving = true;
//			DiceCalculator.ResetDiceBoard();
//		}
//		if (bIsScannerOpen && !bIsScannerMoving)
//		{
//			bIsInfoOpen = true;
//			bIsScannerOpen = false;
//			bIsInfoMoving = true;
//			bIsScannerMoving = true;
//			if(goScanCamera.activeInHierarchy)
//			{
//				goScanCamera.SetActive (false);
//			}
//			else
//			{
//				goScanCamera.SetActive (true);
//			}
//		}
	}

	public void OpenCloseInvPanel ()
	{
		if (!bIsInvMoving && !bIsActionMoving && !bIsInfoMoving && !bIsDiceRollerMoving && !bIsScannerOpen && !bIsScannerMoving && !bIsDiceRollerOpen && !DiceCalculator.bOpenedDiceRoller)
		{
			bIsInvOpen = !bIsInvOpen;
			bIsInvMoving = true;
		}
		if (bIsActionOpen && !bIsActionMoving)
		{
			bIsInvOpen = true;
			bIsActionOpen = false;
			bIsInvMoving = true;
			bIsActionMoving = true;
		}
		if (bIsInfoOpen && !bIsInfoMoving)
		{
			bIsInvOpen = true;
			bIsInfoOpen = false;
			bIsInvMoving = true;
			bIsInfoMoving = true;
		}
		if (DiceCalculator.bOpenedDiceRoller)
		{
			bIsInvOpen = !bIsInvOpen;
			bIsDiceRollerOpen = !bIsDiceRollerOpen;
			bIsInvMoving = true;
			bIsDiceRollerMoving = true;
		}
//		if (bIsDiceRollerOpen && !bIsDiceRollerMoving && !DiceCalculator.bOpenedDiceRoller)
//		{
//			bIsInvOpen = true;
//			bIsDiceRollerOpen = false;
//			bIsInvMoving = true;
//			bIsDiceRollerMoving = true;
//		}
//		if (bIsInvOpen && !bIsInvMoving && DiceCalculator.bOpenedDiceRoller)
//		{
//			bIsDiceRollerOpen = true;
//			bIsInvOpen = false;
//			bIsDiceRollerMoving = true;
//			bIsInvMoving = true;
//		}
//		if (bIsScannerOpen && !bIsScannerMoving)
//		{
//			bIsInvOpen = true;
//			bIsScannerOpen = false;
//			bIsInvMoving = true;
//			bIsScannerMoving = true;
//			if(goScanCamera.activeInHierarchy)
//			{
//				goScanCamera.SetActive (false);
//			}
//			else
//			{
//				goScanCamera.SetActive (true);
//			}
//		}
	}

	public void OpenCloseDiceRollerPanel ()
	{
//		if (!bIsDiceRollerMoving && !bIsActionMoving && !bIsInfoMoving && !bIsInvMoving && !bIsScannerOpen && !bIsScannerMoving)
//		{
//			bIsDiceRollerOpen = !bIsDiceRollerOpen;
//			bIsDiceRollerMoving = true;
//			DiceCalculator.ResetDiceBoard();
//		}
		if (bIsDiceRollerOpen && !bIsDiceRollerMoving)
		{
			bIsDiceRollerOpen = false;
			bIsDiceRollerMoving = true;
			DiceCalculator.ResetDiceBoard();
		}
		if (bIsActionOpen && !bIsActionMoving)
		{
			bIsDiceRollerOpen = true;
			bIsActionOpen = false;
			bIsDiceRollerMoving = true;
			bIsActionMoving = true;
			DiceCalculator.bOpenedDiceRoller = true;
			DiceCalculator.AddAnyPoolRemaining();
		}
//		if (bIsInfoOpen && !bIsInfoMoving)
//		{
//			bIsDiceRollerOpen = true;
//			bIsInfoOpen = false;
//			bIsDiceRollerMoving = true;
//			bIsInfoMoving = true;
//		}
//
//		if (bIsInvOpen && !bIsInvMoving)
//		{
//			bIsDiceRollerOpen = true;
//			bIsInvOpen = false;
//			bIsDiceRollerMoving = true;
//			bIsInvMoving = true;
//		}
//		if (bIsScannerOpen && !bIsScannerMoving)
//		{
//			bIsDiceRollerOpen = true;
//			bIsScannerOpen = false;
//			bIsDiceRollerMoving = true;
//			bIsScannerMoving = true;
//			if(goScanCamera.activeInHierarchy)
//			{
//				goScanCamera.SetActive (false);
//			}
//			else
//			{
//				goScanCamera.SetActive (true);
//			}
//		}
	}

	public void OpenInvAfterScanner ()
	{
		if (bIsScannerOpen && !bIsScannerMoving)
		{
			bIsInvOpen = true;
			bIsScannerOpen = false;
			bIsInvMoving = true;
			bIsScannerMoving = true;
			DiceCalculator.bIsOpenedScanner = false;
		}
	}

	public void OpenCloseScannerPanel ()
	{
//		if (!bIsScannerMoving && !bIsDiceRollerMoving && !bIsActionMoving && !bIsInfoMoving && !bIsInvMoving)
//		{
//			bIsScannerOpen = !bIsScannerOpen;
//			if(goScanCamera.activeInHierarchy)
//			{
//				goScanCamera.SetActive (false);
//			}
//			else
//			{
//				goScanCamera.SetActive (true);
//			}
//			bIsScannerMoving = true;
//		}
//		if (bIsActionOpen && !bIsActionMoving)
//		{
//			bIsScannerOpen = true;
//			bIsActionOpen = false;
//			bIsScannerMoving = true;
//			bIsActionMoving = true;
//		}
//		if (bIsInfoOpen && !bIsInfoMoving)
//		{
//			bIsScannerOpen = true;
//			bIsInfoOpen = false;
//			bIsScannerMoving = true;
//			bIsInfoMoving = true;
//		}
//		if (bIsInvOpen && !bIsInvMoving)
//		{
//			bIsScannerOpen = true;
//			bIsInvOpen = false;
//			bIsScannerMoving = true;
//			bIsInvMoving = true;
//		}
		if (bIsScannerOpen && !bIsScannerMoving)
		{
			bIsScannerOpen = false;
			bIsScannerMoving = true;
			DiceCalculator.bIsOpenedScanner = false;
		}
		if (bIsDiceRollerOpen && !bIsDiceRollerMoving)
		{
			goScanCamera.SetActive (true);
			bIsScannerOpen = true;
			bIsDiceRollerOpen = false;
			bIsScannerMoving = true;
			bIsDiceRollerMoving = true;
			DiceCalculator.ResetDiceBoard();
		}

	}

}
