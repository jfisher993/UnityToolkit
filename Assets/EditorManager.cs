using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class EditorManager
{
	public static Scene GetCurrentScene()
	{
		return SceneManager.GetActiveScene();
	}

	public static string GetCurrentSceneName()
	{
		return SceneManager.GetActiveScene().name;
	}
}