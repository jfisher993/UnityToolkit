using UnityEngine;

public abstract class AbstractSingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this as T;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			InstanceDestroyed();
		}
	}

	protected virtual void InstanceDestroyed()
	{
	}
}