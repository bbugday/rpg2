using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestNodeGraphEditor : EditorWindow
{
    private GUIStyle questNodeStyle;

    private const float nodeWidth = 160f;
    private const float nodeHeight = 75f;
    private const int nodePadding = 25;
    private const int nodeBorder = 12;

    [MenuItem("Quest Node Graph Editor", menuItem = "Window/Quest Editor/Quest Node Graph Editor")]
    private static void OpenWindow()
    {
        GetWindow<QuestNodeGraphEditor>("Quest Node Graph Editor");
    }
    
    private void OnEnable()
    {
        questNodeStyle = new GUIStyle();
        questNodeStyle.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
        questNodeStyle.normal.textColor = Color.white;
        questNodeStyle.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
        questNodeStyle.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(new Vector2(100f, 100f), new Vector2(nodeWidth, nodeHeight)), questNodeStyle);
        EditorGUILayout.LabelField("Node1");
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(new Vector2(300f, 300f), new Vector2(nodeWidth, nodeHeight)), questNodeStyle);
        EditorGUILayout.LabelField("Node2");
        GUILayout.EndArea();
    }
}
