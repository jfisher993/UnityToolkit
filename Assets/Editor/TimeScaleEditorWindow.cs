using UnityEngine;
using UnityEditor;

namespace EditorExtension {

	public class TimeScaleEditorWindow : EditorWindow {

		private const string TIME_SCALE_EDITOR_DIR = "Tools/Time Scale Editor %T";
		private const int DIRECTORY_GROUP = 2;

		private float minTimeScale = 0;
		private float maxTimeScale = 3;

		[MenuItem(TIME_SCALE_EDITOR_DIR, false, DIRECTORY_GROUP)]
		private static void Init() {
			GetWindow(typeof(TimeScaleEditorWindow), false, "Time Scale").Show();
		}

		private void OnGUI() {
			GUILayout.Label("Time Scale Settings", EditorStyles.boldLabel);
			Time.timeScale = EditorGUILayout.Slider("Time Scale", Time.timeScale, minTimeScale, maxTimeScale);
			MinTimeScale = EditorGUILayout.FloatField("Min Time Scale", minTimeScale);
			MaxTimeScale = EditorGUILayout.FloatField("Max Time Scale", maxTimeScale);
		}

		private float MinTimeScale {
			set {
				minTimeScale = value;
				if (minTimeScale < 0) {
					minTimeScale = 0;
				}
			}
		}

		private float MaxTimeScale {
			set {
				maxTimeScale = value;
				if (maxTimeScale > 100) {
					maxTimeScale = 100;
				}
			}
		}
	}

}
