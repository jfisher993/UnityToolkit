using UnityEngine;

public abstract class ShiftCollider2D : MonoBehaviour
{
	[SerializeField]
	protected Vector2 shiftAmount = Vector2.zero;
	[SerializeField]
	protected bool inverse;
	[SerializeField]
	protected bool flip;

	abstract protected void ShiftPoints();

	protected Vector2[] GetShiftedPoints(Vector2[] points)
	{
		for (int i = 0; i < points.Length; i++)
		{
			points[i] += shiftAmount;
		}
		return points;
	}

	private void OnValidate()
	{
		if (inverse)
		{
			shiftAmount *= -1;
			inverse = false;
		}
		if (flip)
		{
			shiftAmount = new Vector2(shiftAmount.y, shiftAmount.x);
			flip = false;
		}
	}
}
