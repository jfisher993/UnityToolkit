using UnityEngine;

// Used to take a 3D MeshRenderer and put it in a 2D sortingLayer and sortingOrder
[RequireComponent(typeof(Renderer))]
public class RenderOrderForcer : MonoBehaviour {

	[SerializeField]
	private string sortingLayerName;
	[SerializeField]
	private int sortingOrder;

	private void Awake() {
		Renderer rend = GetComponent<Renderer>();
		rend.sortingLayerName = sortingLayerName;
		rend.sortingOrder = sortingOrder;
	}

}
