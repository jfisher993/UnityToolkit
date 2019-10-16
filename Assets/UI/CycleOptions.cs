using System;
using UnityEngine;

public class CycleOptions<T>
{
	private const float AutoMoveDelay = 0.4f;

	private T[] _options;
	private int _index;
	private Action<T> _onCycle;

	private int _previousDirection;
	private int _direction;
	private float _autoMoveTimer;

	public CycleOptions(T[] options, int index, Action<T> onCycle = null)
	{
		_options = options;
		_index = index;
		_onCycle = onCycle;
	}

	public void Tick(float amount)
	{
		_previousDirection = _direction;
		_direction = Mathf.RoundToInt(ParaLilyInput.Actions.UiMove.Value.x);
		if (_autoMoveTimer <= 0 || _previousDirection != _direction)
		{
			if (_direction != 0)
			{
				Index += _direction;
				_autoMoveTimer = AutoMoveDelay;
			}
		}
		else
		{
			_autoMoveTimer -= amount;
		}
	}

	public int Index
	{
		get
		{
			return _index;
		}
		set
		{
			_index = value >= _options.Length ? 0 : value < 0 ? _options.Length - 1 : value;
			_onCycle?.Invoke(_options[_index]);
		}
	}
}
