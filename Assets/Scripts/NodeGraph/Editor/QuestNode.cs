using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class QuestNode : Node
{
        public string DenemeText;
        public List<QuestPart> questParts;
        public string GUID;
        public bool EntryPoint = false;
}
