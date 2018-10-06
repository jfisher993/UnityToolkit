using System;
using System.Collections.Generic;

/// <summary>
/// Create a boolean flag for each value in a flagged enum, and store them in a dictionary.
/// </summary>
public class FlagDictionary<T> : RuntimeConstraint<T, FlagsAttribute> where T : struct, IConvertible
{
	private Dictionary<T, bool> _flags = new Dictionary<T, bool>();

	public FlagDictionary(T flagged)
	{
		foreach (T flag in Enum.GetValues(typeof(T)))
		{
			int flagInt = (int) (object) flag;
			_flags.Add(flag, ((int) (object) flagged & flagInt) == flagInt);
		}
	}

	public bool this[T key]
	{
		get
		{
			return _flags[key];
		}
	}
}
