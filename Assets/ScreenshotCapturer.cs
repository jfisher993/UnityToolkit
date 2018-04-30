using UnityEngine;
using System.IO;
using System;

public class ScreenshotCapturer : MonoBehaviour {

	private const string SCREENSHOT_FOLDER = "/Screenshots/";

	[SerializeField]
	[Range(1, 8)]
	private int screenshotScale = 1;
	[SerializeField]
	private KeyCode screenshotHotkey = KeyCode.SysReq; // Default = PRINTSCRN button

	private string screenshotDirectory;

	private void Start() {
		// Ex: C:\Users\YourName\AppData\LocalLow\YourCompany\YourGame\Screenshots
		screenshotDirectory = Application.persistentDataPath + SCREENSHOT_FOLDER;
		if (!Directory.Exists(screenshotDirectory)) {
			Directory.CreateDirectory(screenshotDirectory);
		}
	}

	private void Update() {
		if (Input.GetKeyDown(screenshotHotkey)) {
			ScreenCapture.CaptureScreenshot(screenshotDirectory + "screenshot_" + DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss.ffff") + ".png", screenshotScale);
		}
	}

}
