using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCam : MonoBehaviour {

	public RawImage riWebCam;

	void Start ()
	{
		WebCamTexture webcamTexture = new WebCamTexture();
		riWebCam.texture = webcamTexture;
		riWebCam.material.mainTexture = webcamTexture;
		webcamTexture.Play ();
	}

}
