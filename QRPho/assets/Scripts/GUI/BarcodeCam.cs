/*
* Copyright 2012 ZXing.Net authors
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using UnityEngine;
using UnityEngine.UI;

//using ZXing;
//using ZXing.QrCode;
//using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;

using System.Collections.Generic;
using System.Collections;

public class BarcodeCam : MonoBehaviour {
	//public Texture2D encoded;

	private WebCamTexture camTexture;

	//public Text txtResult;

	public AudioSource asSound;

	private Color32[] a_c32CamImage;
	private int iWidth;
	private int iHeight;

	private Rect screenRect;

	public bool bFinishedScanning = false;

	public bool bAutoFocusSet;

	public bool bSuccess = false;
	public bool bComplete = true;

	public string sLastResult;

	//private bool shouldEncodeNow;

	//public IBarcodeReader barcodeReader;
	//public QRCodeReader qrcodeReader;

	void OnGUI() {
		if (!bComplete) {
			GUI.DrawTexture (screenRect, camTexture, ScaleMode.ScaleToFit);
		}
	}

//	void OnEnable() {
//		if (camTexture != null) {
//			camTexture.Play();
//			iWidth = camTexture.width;
//			iHeight = camTexture.height;
//		}
//	}

	void OnDisable() {
		if (camTexture != null) {
			camTexture.Pause();
		}
	}

	void OnDestroy() {
		StopCoroutine("DecodeQR");
		camTexture.Stop();
	}

//	void OnApplicationQuit() {
//		bFinishedScanning = true;
//	}

	void Start() {
		//encoded = new Texture2D(256, 256);
		sLastResult = "";
		bComplete = true;

		screenRect = new Rect((1f/3f)*Screen.width, (1f/3f)*Screen.height, (1f/4f)*Screen.width, (1f/4f)*Screen.height);

		camTexture = new WebCamTexture();
		camTexture.requestedHeight = (int)screenRect.height;//480;
		camTexture.requestedWidth = (int)screenRect.width;//640;
		//OnEnable();

	}

	void Update() {
		if (Time.time > 1f && !bAutoFocusSet) {
			bAutoFocusSet = enableAutoFocus();
		}

		if (!bComplete && a_c32CamImage == null) {
			a_c32CamImage = camTexture.GetPixels32();
		}

		if (bSuccess && !bComplete) {
			bComplete = true;
			StopScanning();

			//txtResult.text = LastResult;
			asSound.Play();
		}
	}

	IEnumerator DecodeQR() {
		while (!bSuccess) {
			Result result = null;
			//Decode the current frame
			if (a_c32CamImage != null) {
				//Debug.Log("Trying...");
				result = GetResult();
			} 
			else {
				//Debug.Log("Not Trying!");
			}

			if (result != null && !bSuccess) {
				Debug.Log("Found " + result.Text + "!");
				sLastResult = result.Text;
				bSuccess = true;
				bFinishedScanning = true;

				yield return null;
			} 
			else {
				yield return new WaitForSeconds(0.2f);
			}
		}
	}

	Result GetResult() {
		return new QRCodeReader().decode(new BinaryBitmap(new HybridBinarizer(new Color32LuminanceSource(camTexture.GetPixels32(), iWidth, iHeight))));
	}

//		private static Color32[] Encode (string textForEncoding, int width, int height) {
//				BarcodeWriter writer = new BarcodeWriter
//		{
//			Format = BarcodeFormat.QR_CODE,
//			Options = new QrCodeEncodingOptions
//			{
//				Height = height,
//				Width = width
//			}
//		};
//				return writer.Write (textForEncoding);
//		}

	public static bool enableAutoFocus () {
			#if UNITY_ANDROID && !UNITY_EDITOR
				AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
				
				AndroidJavaClass metaioSDKAndroid = new AndroidJavaClass("com.metaio.sdk.jni.IMetaioSDKAndroid"); 
				object[] args = {
					currentActivity
				};
				AndroidJavaObject camera = metaioSDKAndroid.CallStatic<AndroidJavaObject>("getCamera", args);
				
				if (camera != null) {
					AndroidJavaObject cameraParameters = camera.Call<AndroidJavaObject>("getParameters");
					object[] focusMode = {
						cameraParameters.GetStatic<string>("FOCUS_MODE_CONTINUOUS_PICTURE")
					};
					cameraParameters.Call("setFocusMode", focusMode);
					object[] newParameters = {
						cameraParameters
					};
					camera.Call("setParameters", newParameters);
					return true;
				}
				else {
					Debug.LogError("metaioSDK.enableAutoFocus: Camera not available");
					return false;
				}
			#else
				return false;
			#endif
	}

	public void StartScanning() {
		if (camTexture != null) {
			camTexture.Play();
			iWidth = camTexture.width;
			iHeight = camTexture.height;
		}

		bSuccess = false;
		bComplete = false;

		StartCoroutine("DecodeQR");
	}

	public void StopScanning() {
		bComplete = true;

		camTexture.Stop();
		StopCoroutine("DecodeQR");
	}
}
