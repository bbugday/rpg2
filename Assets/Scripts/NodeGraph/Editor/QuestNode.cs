using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using System;


public class QuestNode : Node
{

	public QuestNode()
	{
		
	}

	public QuestNode(QuestSO questData)
	{
		this.questData = questData.Clone<QuestSO>();

		this.title = questData.questTitle;
		this.GUID = Guid.NewGuid().ToString();

		this.position = questData.position;
	}

	public QuestSO questData;

	public Port inputPort;
	public Port outputPort;

	public string GUID;

	public Vector2 position;
}
