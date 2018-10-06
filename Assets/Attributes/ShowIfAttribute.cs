public class ShowIfAttribute : AbstractIsVisibleAttribute
{
	public ShowIfAttribute(string target, object value) : base(target, value)
	{
	}

	public override bool IsVisible(object targetValue)
	{
		return targetValue.Equals(Value);
	}
}
