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

		this.questParts = questData.questParts.ConvertAll<QuestPart>(questPart => questPart.Clone<QuestPart>());

		this.prevQuests = questData.prevQuests.ConvertAll<QuestSO>(prevQuest => prevQuest.Clone<QuestSO>());
		this.nextQuests = questData.nextQuests.ConvertAll<QuestSO>(nextQuest => nextQuest.Clone<QuestSO>());
	}

	public QuestSO questData;

	public List<QuestPart> questParts;

	public List<QuestSO> prevQuests;
	public List<QuestSO> nextQuests;

	public Port inputPort;
	public Port outputPort;

	public string GUID;

	public Vector2 position;
}
