using UnityEngine;

public class OnButtonClickActivateObjects : AbstractOnButtonClickActivate<GameObject>
{
	protected override void Activate(GameObject t)
	{
		t.SetActive(true);
	}

	protected override void Deactivate(GameObject t)
	{
		t.SetActive(false);
	}
}
