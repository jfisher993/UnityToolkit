using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractButton : MonoBehaviour, IDeselectHandler, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
{
	protected bool isMouseOver = false;

	protected virtual void Start()
	{
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	public void OnDeselect(BaseEventData eventData)
	{
		OnDeselect();
	}

	public void OnSelect(BaseEventData eventData)
	{
		OnSelect();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		EventSystem.current.SetSelectedGameObject(gameObject);
		OnSelect();
		isMouseOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isMouseOver = false;
		EventSystem.current.SetSelectedGameObject(null);
		OnDeselect();
	}

	protected virtual void OnDisable()
	{
		isMouseOver = false;
	}

	protected abstract void OnClick();

	protected abstract void OnDeselect();

	protected abstract void OnSelect();
}