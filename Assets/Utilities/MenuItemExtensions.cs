using System.Diagnostics;
using System.Security.Principal;
using UnityEditor;
using UnityEditor.SceneManagement;

public static class MenuItemExtensions
{
	[MenuItem("Tools/Dirty Save %&s")]
	public static void DirtySave()
	{
		EditorSceneManager.MarkSceneDirty(EditorManager.GetCurrentScene());
		EditorSceneManager.SaveScene(EditorManager.GetCurrentScene());
	}

	[MenuItem("Tools/Start GitExtensions %g")]
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
}
