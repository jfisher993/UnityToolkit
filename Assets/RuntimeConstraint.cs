using System;

/// <summary>
/// Constrain a generic at runtime by throwing an error. Useful for types which cannot use standard constraints (i.e Attributes).
/// </summary>
public class RuntimeConstraint<T, Constraint>
{
	public RuntimeConstraint()
	{
		Type type = typeof(T);
		Type constraint = typeof(Constraint);
		if (type.GetCustomAttributes(constraint, true).Length <= 0)
		{
			throw new ArgumentException(type + " is missing constraint " + constraint);
		}
	}
}
