using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;
using UnityEditor.UIElements;

public class QuestGraphView : GraphView
{
    private readonly Vector2 defaultNodeSize = new Vector2(150, 200);

    private Dictionary<QuestSO, QuestNode> questToNode;

    private List<QuestNode> currentNodes;

    public QuestGraphView()
    {
        styleSheets.Add(Resources.Load<StyleSheet>("QuestGraph"));

        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());
        
        var grid = new GridBackground();
        Insert(0, grid);
        grid.StretchToParentSize();

        currentNodes = new List<QuestNode>();
        questToNode = new Dictionary<QuestSO, QuestNode>();
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        var compatiblePorts = new List<Port>();
        ports.ForEach((port) => 
        {
            if(startPort != port && startPort.node != port.node)
                compatiblePorts.Add(port);
        });

        return compatiblePorts;
    }


    private Port GeneratePort(QuestNode node, Direction portDirection, Port.Capacity capacity = Port.Capacity.Multi)
    {
        return node.InstantiatePort(Orientation.Horizontal, portDirection, capacity, typeof(float));
    }

    // private QuestNode GenerateEntryPointNode()
    // {
    //     var node = new QuestNode()
    //     {
    //         title = "Start",
    //         GUID = Guid.NewGuid().ToString(),
    //         DenemeText = "entrypoint",
    //         EntryPoint = true
    //     };

    //     var generatedPort = GeneratePort(node, Direction.Output);

    //     generatedPort.portName = "Next";

    //     node.outputContainer.Add(generatedPort);
        
    //     node.RefreshExpandedState();
    //     node.RefreshPorts();

    //     node.SetPosition(new Rect(100, 200, 100, 100));

    //     return node;
    // }

    public void addNode(string nodeName)
    {
        AddElement(createQuestNode(nodeName));
    }

    public void addQuestNodeFromData(QuestSO questData)
    {
        QuestNode questNode = new QuestNode(questData);

        questToNode.Add(questData, questNode);

        var outputPort = GeneratePort(questNode, Direction.Output, Port.Capacity.Multi);
        outputPort.portName = "Next";

        var inputPort = GeneratePort(questNode, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Prev";

        questNode.inputContainer.Add(outputPort);
        questNode.inputContainer.Add(inputPort);

        questNode.inputPort = inputPort;
        questNode.outputPort = outputPort;

        //List<QuestPart> questParts = new List<QuestPart>(); 
        
        //questNode.questParts = questParts;

        var button = new UnityEngine.UIElements.Button(() => {
            QuestPart questPart = null;
            questNode.questParts.Add(questPart); 

            var questPartField = new ObjectField
            {
                objectType = typeof(QuestPart),
                allowSceneObjects = false,
                value = questPart,
            };

            //gets bugged when quest part used twice
            questPartField.RegisterValueChangedCallback(v =>
            {
                questNode.questParts[questNode.questParts.IndexOf(questPart)] = questPartField.value as QuestPart;
            });

            questNode.Add(questPartField);
        });

        button.text = "Add New Quest Part";
        questNode.titleContainer.Add(button);


        foreach(QuestPart questPart in questNode.questParts)
        {   
            var questPartField = new ObjectField
            {
                objectType = typeof(QuestPart),
                allowSceneObjects = false,
                value = questPart,
            };

            //gets bugged when quest part used twice
            questPartField.RegisterValueChangedCallback(evt =>
            {
                questNode.questParts[questNode.questParts.IndexOf(questPart)] = evt.newValue as QuestPart;
            });

            questNode.Add(questPartField);  
        }


        questNode.RefreshExpandedState();
        questNode.RefreshPorts();
        questNode.SetPosition(new Rect(questNode.position, defaultNodeSize));

        currentNodes.Add(questNode);
        
        AddElement(questNode);
    }

    //to reach node from edge: node.outputPort.node
    public void makeConnections()
    {
        foreach(QuestNode node in currentNodes)
        {
            foreach(QuestSO next in node.nextQuests)
            {
                var edge = node.outputPort.ConnectTo(questToNode[next].inputPort);

                AddElement(edge);

                //Debug.Log(node.outputPort.connections); //returns edge, not node!
            }
        }
    }
    

    //repeating!
    public QuestNode createQuestNode(string nodeName)
    {
        var questNode = new QuestNode
        {
            questData = null, // create questso 
            title = nodeName,
            GUID = Guid.NewGuid().ToString(),
            //questParts = new List<QuestPart>()
        };

        var outputPort = GeneratePort(questNode, Direction.Output, Port.Capacity.Multi);
        outputPort.portName = "Next";

        var inputPort = GeneratePort(questNode, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Prev";

        questNode.inputContainer.Add(outputPort);
        questNode.inputContainer.Add(inputPort);

        /* SO FIELD 

        var questPartField = new ObjectField
        {
            objectType = typeof(QuestPart),
            allowSceneObjects = false,
            value = questPart,
        };

        questPartField.RegisterValueChangedCallback(v =>
        {
            questPart = questPartField.value as QuestPart;
        });

        questNode.Add(questPartField);

        */

        /* TEXT FIELD
        var textField = new TextField("Npc");
        textField.RegisterValueChangedCallback(evt =>
        {
            questNode.DenemeText = evt.newValue;
        });
        textField.SetValueWithoutNotify(questNode.DenemeText);
        questNode.Add(textField);
        
        */

        List<QuestPart> questParts = new List<QuestPart>(); 
        
        //questNode.questParts = questParts;


        //*************** TO DO ***********************
        //butonu oluşturulan yeni questSO'ya bağla
        var button = new UnityEngine.UIElements.Button(() => {
            QuestPart questPart = null;
            questParts.Add(questPart); 

            var questPartField = new ObjectField
            {
                objectType = typeof(QuestPart),
                allowSceneObjects = false,
                value = questPart,
            };

            questPartField.RegisterValueChangedCallback(v =>
            {
                questParts[questParts.IndexOf(questPart)] = questPartField.value as QuestPart;
            });

            questNode.Add(questPartField);
        });
        
        button.text = "Add New Quest Part";
        questNode.titleContainer.Add(button);

        questNode.RefreshExpandedState();
        questNode.RefreshPorts();
        questNode.SetPosition(new Rect(Vector2.zero, defaultNodeSize));

        return questNode;
    }
}
