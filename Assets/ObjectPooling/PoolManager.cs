using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

	private const int defaultPoolSize = 5;

	// Dictionary Queue to hold the Unique InstanceID of an object and the Queue of the object type
	private Dictionary<int, Queue<ObjectInstance>> poolDictionary = new Dictionary<int, Queue<ObjectInstance>> ();
	private Dictionary<int, Transform> poolHolders = new Dictionary<int, Transform> ();

	// Singleton Pattern to access this script with ease
	public static PoolManager instance;

	private void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Create a pool of gameobjects and add them to a dictionary
	public void CreatePool (GameObject prefab, int poolSize) {
		int poolKey = prefab.GetInstanceID (); // GetInstanceID is a unique ID for every game object
		Transform poolHolder;
		if (!poolDictionary.ContainsKey (poolKey)) {

			// Creates an empty game object to help keep track of your pool objects and parents it to the PoolManager
			poolHolder = new GameObject (prefab.name + " pool").transform;
			poolHolder.parent = transform;
			poolHolders.Add (poolKey, poolHolder);

			poolDictionary.Add (poolKey, new Queue<ObjectInstance> ());
		} else {
			poolHolder = poolHolders [poolKey];
		}

		// Create the amount of specified prefabs
		for (int i = 0; i < poolSize; i++) {
			ObjectInstance newObject = new ObjectInstance (Instantiate (prefab) as GameObject); // Defaults to Vector3.zero for position and Quaternion.Identity for rotation
			poolDictionary [poolKey].Enqueue (newObject);
			newObject.SetParent (poolHolder);
		}
	}

	// Reuse a gameobject and places it in the desired position
	public GameObject ReuseObject (GameObject prefab, Vector3 position, Quaternion rotation) {
		int poolKey = prefab.GetInstanceID ();

		if (poolDictionary.ContainsKey (poolKey)) {

			// Dequeue then requeue the object then call the Objects Reuse function
			ObjectInstance objectToReuse = poolDictionary [poolKey].Dequeue ();
			poolDictionary [poolKey].Enqueue (objectToReuse);

			objectToReuse.Reuse (position, rotation);
			return objectToReuse.gameObject;
		} else {
			CreatePool (prefab, defaultPoolSize);
			return ReuseObject (prefab, position, rotation);
		}
	}

	// Custom GameObject class to keep track of the objects transform and other values
	public class ObjectInstance {
		public GameObject gameObject;
		private Transform transform;

		private bool hasPoolObjectComponent;
        private IPoolable poolObjectScript;

		public ObjectInstance (GameObject objectInstance) {
			gameObject = objectInstance;
			transform = gameObject.transform;
			gameObject.SetActive (false);

			// Keep track if any of the objects scripts inherit the PoolObject script
            if (gameObject.GetComponent<IPoolable> () != null) {
				hasPoolObjectComponent = true;
                poolObjectScript = gameObject.GetComponent<IPoolable> ();
			}
		}

		// Method called when an ObjectInstance is being reused
		public void Reuse (Vector3 position, Quaternion rotation) {

			// Reset the object as specified within it's own class and the PoolObject class
			if (hasPoolObjectComponent) {
				poolObjectScript.ResetObject ();
			}

			// Move to desired position then set it active
			gameObject.transform.position = position;
			gameObject.transform.rotation = rotation;
			gameObject.SetActive (true);
		}

		// Set the parent of the Object to help group objects properly
		public void SetParent (Transform parent) {
			transform.parent = parent;
		}
	}
}