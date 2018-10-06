using UnityEngine;

public abstract class AbstractIsVisibleAttribute : PropertyAttribute
{
	public string Target { get; set; }

	protected object Value { get; set; }

	public AbstractIsVisibleAttribute(string target, object value)
	{
		Target = target;
		Value = value;
	}

	public abstract bool IsVisible(object targetValue);
}
