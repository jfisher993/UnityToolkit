using UnityEngine;

public abstract class AbstractOnButtonClickActivate<T> : AbstractButton
{
	[SerializeField]
	protected T[] activate;

	[SerializeField]
	protected T[] deactivate;

	protected override void OnClick()
	{
		foreach (T t in activate)
		{
			Activate(t);
		}

		foreach (T t in deactivate)
		{
			Deactivate(t);
		}
	}

	protected abstract void Activate(T t);

	protected abstract void Deactivate(T t);

	protected override void OnDeselect()
	{
	}

	protected override void OnSelect()
	{
	}
}
