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

		//do we really need to clone these or storing questdata is enough?
		this.questParts = questData.questParts;
		this.prevQuests = questData.prevQuests;
		this.nextQuests = questData.nextQuests;
	}

	public QuestSO questData;

	public List<QuestPart> questParts;

	public List<QuestSO> prevQuests;
	public List<QuestSO> nextQuests;

	public Port inputPort;
	public Port outputPort;

	public string GUID;
}
