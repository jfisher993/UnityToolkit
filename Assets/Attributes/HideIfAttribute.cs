public class HideIfAttribute : AbstractIsVisibleAttribute
{
	public HideIfAttribute(string target, object value) : base(target, value)
	{
	}

	public override bool IsVisible(object targetValue)
	{
		return !targetValue.Equals(Value);
	}
}
