using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDB", menuName = "ScriptableObjects/QuestDB", order = 1)]
public class QuestDB : ScriptableObject
{
    private Dictionary<string, Quest> questTitleToQuest;

    private Dictionary<string, ArenaQuest> arenaQuests;//direkt quest ekle?

    private void Awake()
    {
        questTitleToQuest = new Dictionary<string, Quest>();
    }

    public void AddQuest(string title, Quest quest)
    {
        questTitleToQuest.Add(title, quest);
    }

    public Quest GetQuestByTitle(string title)
    {
        return questTitleToQuest[title];
    }

    public void doneQuestPart(string arenaName)
    {
        //arenaQuests[arenaName].quest.doneQuestPart(); //questpart questi bilsin?
    }

}
