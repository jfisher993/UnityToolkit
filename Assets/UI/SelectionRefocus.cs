using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionRefocus : EventSystemController
{
	private Dictionary<GameObject, RectTransform> previousSelectedRectTransform = new Dictionary<GameObject, RectTransform>();

	private GameObject previousSelected;
	private GameObject currentSelected;

	[SerializeField]
	private RectTransform selectedEdgeEffect;

	[SerializeField]
	private Image edgeImage;

	private IEnumerator Start()
	{
		edgeImage.enabled = false;
		yield return Wait.ForEndOfFrame;
		RectTransform currentSelected = currentEventSystem.currentSelectedGameObject?.GetComponent<RectTransform>();
		selectedEdgeEffect.position = currentSelected == null ? Vector3.zero : currentSelected.position;
		edgeImage.enabled = true;
	}

	private void Update()
	{
		currentSelected = currentEventSystem.currentSelectedGameObject;
		if (currentSelected == null)
		{
			currentEventSystem.SetSelectedGameObject(previousSelected);
		}
		else if (previousSelected != currentSelected)
		{
			previousSelected = currentSelected;
			selectedEdgeEffect.gameObject.SetActive(true);
			if (!previousSelectedRectTransform.ContainsKey(currentSelected))
			{
				previousSelectedRectTransform.Add(currentSelected, currentSelected.GetComponent<RectTransform>());
			}
			selectedEdgeEffect.position = previousSelectedRectTransform[currentSelected].position;
		}
		else if (selectedEdgeEffect.position != previousSelectedRectTransform[currentSelected].position)
		{
			selectedEdgeEffect.position = previousSelectedRectTransform[currentSelected].position;
		}
		selectedEdgeEffect.gameObject.SetActive(currentSelected == null ? false : currentSelected.activeInHierarchy);
	}
}
