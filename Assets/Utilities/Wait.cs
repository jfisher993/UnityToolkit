using UnityEngine;

public static class Wait
{
	public static readonly WaitForEndOfFrame ForEndOfFrame = new WaitForEndOfFrame();
	public static readonly WaitForFixedUpdate ForFixedUpdate = new WaitForFixedUpdate();

	public static readonly WaitForSeconds ForSecond = new WaitForSeconds(1);
	public static readonly WaitForSeconds ForHalfSecond = new WaitForSeconds(0.50f);
	public static readonly WaitForSeconds ForQuarterSecond = new WaitForSeconds(0.25f);
	public static readonly WaitForSeconds ForTenthSecond = new WaitForSeconds(0.10f);

	// Warning: Stopping a readonly Realtime yield can lead to unexpected results.
	public static readonly WaitForSecondsRealtime ForRealtimeSecond = new WaitForSecondsRealtime(1);
	public static readonly WaitForSecondsRealtime ForRealtimeHalfSecond = new WaitForSecondsRealtime(0.50f);
	public static readonly WaitForSecondsRealtime ForRealtimeQuarterSecond = new WaitForSecondsRealtime(0.25f);
	public static readonly WaitForSecondsRealtime ForRealtimeTenthSecond = new WaitForSecondsRealtime(0.10f);
}
