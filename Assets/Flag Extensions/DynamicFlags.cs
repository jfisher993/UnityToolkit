using System;
using System.Collections.Generic;
using System.Dynamic;

/// <summary>
/// Dynamically generate a boolean flag for each value in a flagged enum.
/// </summary>
public class DynamicFlags<T> : RuntimeConstraint<T, FlagsAttribute> where T : struct, IConvertible
{
	public dynamic Flags { get; set; } = new ExpandoObject();

	public DynamicFlags(T flagged)
	{
		var flagProperties = (IDictionary<string, object>) Flags;
		int flaggedInt = (int) (object) flagged;
		foreach (T flag in Enum.GetValues(typeof(T)))
		{
			int flagInt = (int) (object) flag;
			flagProperties.Add(flag.ToString(), (flaggedInt & flagInt) == flagInt);
		}
	}
}
