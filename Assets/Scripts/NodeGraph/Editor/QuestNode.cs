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
		this.questData = questData;

		this.title = questData.questTitle;
		this.GUID = Guid.NewGuid().ToString();
	}

	public QuestSO questData;

	public Port inputPort;
	public Port outputPort;

	public string GUID;
}
