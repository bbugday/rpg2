using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

public class QuestGraphView : GraphView
{
    private readonly Vector2 defaultNodeSize = new Vector2(150, 200);

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

        AddElement(GenerateEntryPointNode());
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

    private QuestNode GenerateEntryPointNode()
    {
        var node = new QuestNode()
        {
            title = "Start",
            GUID = Guid.NewGuid().ToString(),
            DenemeText = "entrypoint",
            EntryPoint = true
        };

        var generatedPort = GeneratePort(node, Direction.Output);

        generatedPort.portName = "Next";

        node.outputContainer.Add(generatedPort);
        
        node.RefreshExpandedState();
        node.RefreshPorts();

        node.SetPosition(new Rect(100, 200, 100, 100));

        return node;
    }

    public void createNode(string nodeName)
    {
        AddElement(createQuestNode(nodeName));
    }

    public QuestNode createQuestNode(string nodeName)
    {
        var questNode = new QuestNode
        {
            title = nodeName,
            DenemeText = "denemetext",
            GUID = Guid.NewGuid().ToString()
        };

        var inputPort = GeneratePort(questNode, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Input";
        questNode.inputContainer.Add(inputPort);
        questNode.RefreshExpandedState();
        questNode.RefreshPorts();
        questNode.SetPosition(new Rect(Vector2.zero, defaultNodeSize));

        return questNode;
    }
}
