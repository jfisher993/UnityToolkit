using System;
using System.Collections.Generic;

public class StateController<T> where T : struct, IConvertible
{
	private Dictionary<StateEvent, Dictionary<T, Action>> _eventHandlers = new Dictionary<StateEvent, Dictionary<T, Action>>();

	private T _state;

	public StateController()
	{
		foreach (StateEvent stateEvent in Enum.GetValues(typeof(StateEvent)))
		{
			_eventHandlers.Add(stateEvent, new Dictionary<T, Action>());
			foreach (T state in Enum.GetValues(typeof(T)))
			{
				_eventHandlers[stateEvent].Add(state, null);
			}
		}
	}

	public void Invoke(StateEvent stateEvent)
	{
		_eventHandlers[stateEvent][_state]?.Invoke();
	}

	public void Subscribe(StateEvent stateEvent, T state, Action action)
	{
		_eventHandlers[stateEvent][state] += action;
	}

	public void Unsubscribe(StateEvent stateEvent, T state, Action action)
	{
		_eventHandlers[stateEvent][state] -= action;
	}

	public T State
	{
		set
		{
			Invoke(StateEvent.Exit);
			_state = value;
			Invoke(StateEvent.Enter);
		}
	}
}
