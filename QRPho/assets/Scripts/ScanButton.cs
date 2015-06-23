using UnityEngine;
using System.Collections;

public class ScanButton : MonoBehaviour {

	public BarcodeCam Scanner;

	void Start ()
	{
	
	}

	void Update ()
	{

	}

	public void PressButton ()
	{
		Scanner.StartScanning();
	}
}
