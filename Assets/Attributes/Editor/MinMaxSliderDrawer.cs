using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer (typeof (MinMaxSliderAttribute))]
internal class MinMaxSliderDrawer : PropertyDrawer {

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
		return 30;

		//return base.GetPropertyHeight (property, label);
	}

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

		position.height = 30;
		EditorGUI.BeginProperty (position, label, property);

		if (property.propertyType == SerializedPropertyType.Vector2) {
			Vector2 range = property.vector2Value;
			float min = range.x;
			float max = range.y;
			MinMaxSliderAttribute attr = attribute as MinMaxSliderAttribute;
			EditorGUI.BeginChangeCheck ();
			EditorGUI.MinMaxSlider (position, label, ref min, ref max, attr.min, attr.max);

			//EditorGUILayout.HelpBox ("Min: " + min + " Max: " + max, MessageType.None);

			GUIStyle style = new GUIStyle ();
			style.alignment = TextAnchor.MiddleCenter;
			position.y += 7.5f;
			EditorGUI.LabelField (position, "Min: " + min.ToString ("F2") + "     Max: " + max.ToString ("F2"), style);

			if (EditorGUI.EndChangeCheck ()) {
				range.x = min;
				range.y = max;
				property.vector2Value = range;
			}
		} else {
			EditorGUI.LabelField (position, label, "Use only with Vector2");
		}

		EditorGUI.EndProperty ();
	}
}