using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AbstractSingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T Instance { get; private set; }

	protected abstract void OnSceneLoaded(Scene scene, LoadSceneMode mode);

	protected virtual void Awake()
	{
		if (Instance == null)
		{
			Instance = this as T;
			SceneManager.sceneLoaded += OnSceneLoaded;
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
			SceneManager.sceneLoaded -= OnSceneLoaded;
			InstanceDestroyed();
		}
	}

	protected virtual void InstanceDestroyed()
	{
	}
}