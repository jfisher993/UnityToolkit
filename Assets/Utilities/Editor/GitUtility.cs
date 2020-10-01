using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using UnityEditor;

[InitializeOnLoad]
public static class GitUtility
{
#if UNITY_EDITOR_WIN

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern int GetWindowText(IntPtr window, StringBuilder output, int outputSize);

	[DllImport("user32.dll", EntryPoint = "SetWindowText")]
	public static extern bool SetWindowText(IntPtr window, string text);

	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow();

	static GitUtility()
	{
		RefreshBranchName();
	}

	/// <summary>
	/// Refreshes the branch name on the title bar.
	/// </summary>
	[MenuItem("Git/Refresh Branch Name")]
	public static void RefreshBranchName()
	{
		StringBuilder titleTextBuilder = new StringBuilder(255);
		GetWindowText(GetActiveWindow(), titleTextBuilder, titleTextBuilder.Capacity);
		var titleText = titleTextBuilder.ToString();
		// Remove previous branch name if it exists.
		if (titleText.Contains(" ("))
		{
			titleText = titleText.Remove(titleText.IndexOf(" ("));
		}
		SetWindowText(GetActiveWindow(), $"{titleText.ToString()} ({BranchName()})");
	}

#endif

	/// <summary>
	/// Open this Git repo in GitExtensions.
	/// </summary>
	[MenuItem("Git/Start GitExtensions %g")]
	public static void StartGitExtensions()
	{
		ProcessStartInfo process = new ProcessStartInfo("gitextensions.exe", "openrepo");
#if UNITY_EDITOR_WIN
		if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
		{
			process.Verb = "runas";
		}
#endif
		Process.Start(process);
	}

	private static string BranchName()
	{
		using (Process process = new Process())
		{
			process.StartInfo = new ProcessStartInfo("git.exe")
			{
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				// Git Command Cheat Sheet: https://gist.github.com/5310/d46b4d7fd69741a118717d28f2d9d789
				Arguments = "rev-parse --abbrev-ref HEAD"
			};
			process.Start();
			return process.StandardOutput.ReadLine();
		}
	}
}
