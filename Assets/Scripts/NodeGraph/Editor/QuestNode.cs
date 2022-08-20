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

		this.position = questData.position;
		
		this.questParts = new List<QuestPart>();
		this.nextQuests = new List<QuestSO>();

		foreach(QuestPart part in questData.questParts)
		{
			this.questParts.Add(part);
		}

		foreach(QuestSO next in questData.nextQuests)
		{
			this.nextQuests.Add(next);
		}
	}

	public QuestSO questData;

	public List<QuestPart> questParts;

	public List<QuestSO> prevQuests;
	public List<QuestSO> nextQuests;

	public Port inputPort;
	public Port outputPort;

	public string GUID;

	public Rect position;
}
