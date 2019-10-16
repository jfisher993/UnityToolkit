using UnityEngine;

public static class Wait
{
	public static readonly WaitForEndOfFrame ForEndOfFrame = new WaitForEndOfFrame();
	public static readonly WaitForFixedUpdate ForFixedUpdate = new WaitForFixedUpdate();
}
