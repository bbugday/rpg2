using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class QuestNodeGraphEditor : EditorWindow
{

    private QuestGraphView graphView;

    private string filename = "ScriptableObjects/Quests";

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

        var fileNameTextField = new TextField("File Name:");
        fileNameTextField.SetValueWithoutNotify(filename);
        fileNameTextField.MarkDirtyRepaint();
        fileNameTextField.RegisterValueChangedCallback(evt => filename = evt.newValue);
        toolbar.Add(fileNameTextField);

        toolbar.Add(new Button(() => SaveData()){text = "Save Data"});
        toolbar.Add(new Button(() => LoadData()){text = "Load Data"});

        var nodeCreateButton = new Button(() => {graphView.addNode("Quest Node");});
        nodeCreateButton.text = "Create Node";
        toolbar.Add(nodeCreateButton);

        rootVisualElement.Add(toolbar);
    }

    private void LoadData()
    {
        var quests = Resources.LoadAll<QuestSO>(filename);

        foreach(QuestSO questData in quests)
        {
            graphView.addQuestNodeFromData(questData);
        }

        graphView.makeConnections();
    }

    private void SaveData()
    {
        graphView.SaveData();
    }

    private void OnDisable()
    {
        rootVisualElement.Remove(graphView);
    }
}
