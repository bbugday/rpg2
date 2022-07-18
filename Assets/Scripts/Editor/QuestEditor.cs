// using UnityEngine;
// using System.Collections.Generic;
// using UnityEditor;

// [CustomEditor(typeof(QuestSO))]
// [CanEditMultipleObjects]
// public class QuestEditor : Editor
// {
    
//     //show quest parts
//     // oyunu başlatınca quest partlar sıfırlanıyor?

//     QuestSO q;

//     public int index = 0;

//     string[] questTypes = new string[] {"Dialogue", "Kill", "Collect"};

//     public void OnEnable()
//     {

        
//         q = (QuestSO)target;

//         q.questParts = new List<QuestPart>();
        
//     }

//     public override void OnInspectorGUI()
//     {

//         GUILayout.Label("" + q.questParts.Count);
        
//         base.OnInspectorGUI();

//         index = EditorGUILayout.Popup(index, questTypes);

//         //diyalog ve npc name'i al
        
//         string a;
//         string[] arr;

//         if(index == 0)
//         {
//             GUILayout.Label("Dialogue Text");
//             a = EditorGUILayout.TextField("");
//         }

//         Dialogue dia = new Dialogue(new List<string>{"aaa", "bbb"});

//         if(GUILayout.Button("Create Quest Part"))
//         {
//             if(index == 0)
//             {
//                 DialogueQuest asset = ScriptableObject.CreateInstance<DialogueQuest>();

//                 AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/QuestParts/NewScriptableObject.asset");
//                 AssetDatabase.SaveAssets();

//                 EditorUtility.FocusProjectWindow();

//                 Selection.activeObject = asset;


//                 // DialogueQuest dialogueQuest = new DialogueQuest("npc1", dia);
//                 // q.questParts.Add(dialogueQuest);
//                 // Debug.Log("aa");
//             }
//         }
//     }
// }
