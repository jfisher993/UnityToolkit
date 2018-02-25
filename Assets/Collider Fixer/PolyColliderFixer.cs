using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class PolyColliderFixer : ColliderFixer2D {
	[SerializeField]
	protected int path;

	[ContextMenu("Shift Points")]
	override protected void ShiftPoints() {
		PolygonCollider2D polyCol = GetComponent<PolygonCollider2D>();
		polyCol.SetPath(path, GetShiftedPoints(polyCol.GetPath(path)));
	}

	[ContextMenu("Shift All Paths")]
	protected void ShiftAllPoints() {
		PolygonCollider2D polyCol = GetComponent<PolygonCollider2D>();
		for (int i = 0; i < polyCol.pathCount; i++) {
			polyCol.SetPath(i, GetShiftedPoints(polyCol.GetPath(i)));
		}
	}

}
