using UnityEngine;

public class MaterialPropertyFloatModifier : MonoBehaviour
{
	[SerializeField]
	private Material mat;
	[SerializeField]
	private string property;
	[SerializeField]
	private float deltaPerSecond = 1;
	[SerializeField]
	private float resetValue = 0;

	private void Update()
	{
		mat.SetFloat(property, mat.GetFloat(property) + deltaPerSecond * Time.deltaTime);
	}

	private void OnDisable()
	{
		mat.SetFloat(property, resetValue);
	}
}
