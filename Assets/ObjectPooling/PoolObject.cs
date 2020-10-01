using UnityEngine;
using System.Collections;

public class PoolObject : MonoBehaviour, IPoolable {

	//Virtual Reset function so it can be overriden in classes with specific needs
	public virtual void ResetObject () {
	}

	public virtual void Destroy () {
		gameObject.SetActive (false);
	}
}