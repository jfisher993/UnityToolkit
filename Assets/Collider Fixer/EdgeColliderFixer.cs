using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class EdgeColliderFixer : ColliderFixer2D {

	[ContextMenu("Shift Points")]
	override protected void ShiftPoints() {
		EdgeCollider2D col = GetComponent<EdgeCollider2D>();
		col.points = GetShiftedPoints(col.points);
	}

}
