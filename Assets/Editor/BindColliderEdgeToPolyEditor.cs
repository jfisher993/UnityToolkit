using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BindColliderEdgeToPoly))]
public class BindColliderEdgeToPolyEditor : Editor
{
    private float scaleFactor = 1;
    private int polyPath = 0;

    public override void OnInspectorGUI()
    {
        scaleFactor = EditorGUILayout.FloatField("Scale Factor ", scaleFactor);
        polyPath = EditorGUILayout.IntField("Poly Path ", polyPath);
        if (GUILayout.Button("Bind"))
        {
            BindColliderEdgeToPoly binder = (BindColliderEdgeToPoly)target;
            BindEdgeToPoly(binder.GetComponent<EdgeCollider2D>(), binder.GetComponent<PolygonCollider2D>(), scaleFactor, polyPath);
        }
    }

    private static void BindEdgeToPoly(EdgeCollider2D edge, PolygonCollider2D poly, float scaleFactor, int polyPath)
    {
        Vector2[] polyPoints = poly.GetPath(polyPath);
        Vector2[] edgePoints = new Vector2[polyPoints.Length + 1];
        for (int i = 0; i < polyPoints.Length; i++)
        {
            edgePoints[i] = polyPoints[i] * scaleFactor;
        }
        edgePoints[polyPoints.Length] = polyPoints[0] * scaleFactor;
        edge.points = edgePoints;
    }
}
