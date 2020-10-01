#if UNITY_EDITOR

using System;
using UnityEditor;

[InitializeOnLoad]
public static class EditorEvents
{
	static EditorEvents()
	{
		EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
	}

	private static void OnPlayModeStateChanged(PlayModeStateChange state)
	{
	}
}

#endif
