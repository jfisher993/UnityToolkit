using UnityEngine;
using System.IO;
using System;

public class ScreenshotCapturer : MonoBehaviour
{
	private const string SCREENSHOT_FOLDER = "/Screenshots/";

	[SerializeField]
	[Range(1, 8)]
	private int screenshotScale = 1;
	[SerializeField]
	private KeyCode screenshotHotkey = KeyCode.F12; // Default = F12 key
	[SerializeField]
	private bool isBurstCapture = false;
	[SerializeField]
	private int burstFrameFactor = 5;

	private int burstFrameCount = 0;
	private string burstDirectory;
	private string screenshotDirectory;

	private void Start()
	{
		// Ex: C:\Users\YourName\AppData\LocalLow\YourCompany\YourGame\Screenshots
		screenshotDirectory = Application.persistentDataPath + SCREENSHOT_FOLDER;
		if (!Directory.Exists(screenshotDirectory))
		{
			Directory.CreateDirectory(screenshotDirectory);
		}
		burstFrameCount = burstFrameFactor;
	}

	private void Update()
	{
		if (isBurstCapture)
		{
			BurstCapture();
		}
		else if (Input.GetKeyDown(screenshotHotkey))
		{
			CaptureScreenshot(screenshotDirectory);
		}
	}

	private void BurstCapture()
	{
		if (Input.GetKey(screenshotHotkey) && burstFrameCount >= burstFrameFactor)
		{
			if (Input.GetKeyDown(screenshotHotkey))
			{
				burstDirectory = screenshotDirectory + "burst_" + FormattedDateTime + "/";
				Directory.CreateDirectory(burstDirectory);
			}
			CaptureScreenshot(burstDirectory);
			burstFrameCount = 0;
		}
		else if (Input.GetKeyUp(screenshotHotkey))
		{
			burstFrameCount = burstFrameFactor;
		}
		else
		{
			burstFrameCount++;
		}
	}

	private void CaptureScreenshot(string directory)
	{
		ScreenCapture.CaptureScreenshot(directory + "screenshot_" + FormattedDateTime + ".png", screenshotScale);
	}

	private string FormattedDateTime
	{
		get
		{
			return DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss.ffff");
		}
	}
}
