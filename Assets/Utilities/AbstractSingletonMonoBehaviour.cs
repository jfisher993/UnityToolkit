using UnityEngine;

public abstract class AbstractSingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T Instance { get; set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = InitializeInstance();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	protected abstract T InitializeInstance();
}