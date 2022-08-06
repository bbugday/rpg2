using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class QuestNodeGraphEditor : EditorWindow
{

    private QuestGraphView graphView;

    [MenuItem("Quest Node Graph Editor", menuItem = "Window/Quest Editor/Quest Node Graph Editor")]
    private static void OpenWindow()
    {
        GetWindow<QuestNodeGraphEditor>("Quest Node Graph Editor");
    }
    
    private void OnEnable()
    {
        ContructGraphView();
        GenerateToolbar();
    }

    private void ContructGraphView()
    {
        graphView = new QuestGraphView{name = "Quest Graph"};

        graphView.StretchToParentSize();
        rootVisualElement.Add(graphView);
    }

    private void GenerateToolbar()
    {
        var toolbar = new Toolbar();
        var nodeCreateButton = new Button(() => {graphView.createNode("Quest Node");});
        nodeCreateButton.text = "Create Node";
        toolbar.Add(nodeCreateButton);
        rootVisualElement.Add(toolbar);
    }

    private void OnDisable()
    {
        rootVisualElement.Remove(graphView);
    }

    private void OnGUI()
    {

    }
}
