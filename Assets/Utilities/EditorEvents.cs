#if UNITY_EDITOR

using System;
using UnityEditor;

[InitializeOnLoad]
public static class EditorEvents
{
	public static event Action EnteredEditMode;

	public static event Action ExitingEditMode;

	public static event Action EnteredPlayMode;

	public static event Action ExitingPlayMode;

	static EditorEvents()
	{
		EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
	}

	private static void OnPlayModeStateChanged(PlayModeStateChange state)
	{
		switch (state)
		{
			case PlayModeStateChange.EnteredEditMode:
				EnteredEditMode?.Invoke();
				break;

			case PlayModeStateChange.ExitingEditMode:
				ExitingEditMode?.Invoke();
				break;

			case PlayModeStateChange.EnteredPlayMode:
				EnteredPlayMode?.Invoke();
				break;

			case PlayModeStateChange.ExitingPlayMode:
				ExitingPlayMode?.Invoke();
				break;

			default:
				break;
		}
	}
}

#endif
