using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class QuestNode : Node
{
        public List<QuestPart> questParts;
        public string GUID;
        public bool EntryPoint = false;
}
