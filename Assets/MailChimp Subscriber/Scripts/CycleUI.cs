using UnityEngine;
using UnityEngine.EventSystems;

public class CycleUI : MonoBehaviour {

	[SerializeField]
	private GameObject[] cycleUI;
	[SerializeField]
	private KeyCode cycleKey = KeyCode.Tab;
	[SerializeField]
	private KeyCode reverse = KeyCode.LeftShift;

	private int index = 0;

	private EventSystem eventSystem;

	private void Start() {
		eventSystem = EventSystem.current;
	}

	private void Update() {
		if (Input.GetKeyDown(cycleKey)) {
			eventSystem.SetSelectedGameObject(NextCycle(Input.GetKey(reverse) ? -1 : 1));
		}
	}

	private GameObject NextCycle(int direction) {
		for (int i = 0; i < cycleUI.Length; i++) {
			if (eventSystem.currentSelectedGameObject == cycleUI[i]) {
				Index = i + direction;
				return cycleUI[Index];
			}
		}
		Index = 0;
		return cycleUI[Index];
	}

	private int Index {
		get {
			return index;
		}
		set {
			index = value;
			if (index >= cycleUI.Length) {
				index = 0;
			} else if (index < 0) {
				index = cycleUI.Length - 1;
			}
		}
	}

}
