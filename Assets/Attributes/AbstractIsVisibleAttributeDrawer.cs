using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfAttribute))]
[CustomPropertyDrawer(typeof(HideIfAttribute))]
public class AbstractIsVisibleAttributeDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		AbstractIsVisibleAttribute attr = attribute as AbstractIsVisibleAttribute;
		if (attr.IsVisible(property.serializedObject.GetValue(attr.Target)))
		{
			EditorGUI.PropertyField(position, property, label, true);
		}
	}
}

public static class SerializedObjectExtensions
{
	/// <summary>
	/// Returns the value for the specified field from within the specified targetted object.
	/// Default flags uses Instance (4), Public (16), and NonPublic (32).
	/// </summary>
	public static object GetValue(this SerializedObject obj, string fieldName, BindingFlags flags = (BindingFlags) 52)
	{
		object targetObject = obj.targetObject;
		FieldInfo propertyField = targetObject.GetType().GetField(fieldName, flags);
		return propertyField.GetValue(targetObject);
	}
}
