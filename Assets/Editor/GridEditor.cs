using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor {

    Grid gridTarget;
    SerializedProperty gridCircularElement;
    private bool debugGrid;
    private bool debugInfoGrid;

    private void OnEnable()
    {
        gridTarget = (Grid)target;
        gridCircularElement = serializedObject.FindProperty("circleRef");
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical();

        GUILayout.Label("Grid Size:", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Horizontal Size:");
        gridTarget.xSize = EditorGUILayout.IntField(gridTarget.xSize);
        GUILayout.Label("Vertical Size:");
        gridTarget.ySize = EditorGUILayout.IntField(gridTarget.ySize);
        GUILayout.EndHorizontal();

        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Grid Element");
        EditorGUILayout.PropertyField(gridCircularElement, GUIContent.none);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Arc Angle");
        gridTarget.circleRef.angleSize = EditorGUILayout.Slider(gridTarget.circleRef.angleSize, 0, 360);
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Arc Radius");
        gridTarget.circleRef.circularRadius = EditorGUILayout.FloatField(gridTarget.circleRef.circularRadius);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Minimum Distance");
        gridTarget.minDistance = EditorGUILayout.FloatField(
            (gridTarget.minDistance > 0 && gridTarget.minDistance > (gridTarget.circleRef.circularRadius / 2)) 
            ? gridTarget.minDistance : (gridTarget.circleRef.circularRadius / 2)
            );
        GUILayout.EndHorizontal();
        EditorGUILayout.HelpBox("Minimum distance is a half of circle radius", MessageType.Info);
        GUILayout.EndVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("View grid?");
        debugGrid = EditorGUILayout.Toggle(debugGrid);
        GUILayout.EndHorizontal();

        if (debugGrid) {
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Label("View grid information?");
            debugInfoGrid = EditorGUILayout.Toggle(debugInfoGrid);
            GUILayout.EndHorizontal();
            GUILayout.BeginVertical();
        }

    }

    

    private void OnSceneGUI()
    {
        if (debugGrid)
        {
            for (int y = 0; y < gridTarget.ySize; y++)
            {
                for (int x = 0; x < gridTarget.xSize; x++)
                {
                    GenerateArcs(x, y);
                }

                
            }
        }

        if (debugInfoGrid)
        {
            int gridElementsCurrent = gridTarget.ySize * gridTarget.xSize;
            Handles.BeginGUI();
            GUILayout.BeginVertical();
            GUILayout.BeginArea(new Rect(20, 20, 120, 40));
            GUILayout.Label("Grid Informations:", EditorStyles.boldLabel);
            GUILayout.Label("Grid Elements:" + gridElementsCurrent);
            GUILayout.EndArea();
            Handles.EndGUI();
        }

    }

    private void GenerateArcs(float x, float y)
    {
        float xP = x + (gridTarget.minDistance * x);
        float yP = y + (gridTarget.minDistance * y);
        Vector3 position = new Vector3(xP, yP);
        Handles.DrawWireArc(position, Vector3.forward, Vector3.up, gridTarget.circleRef.angleSize, gridTarget.circleRef.circularRadius);
    }

}
