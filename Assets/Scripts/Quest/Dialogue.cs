using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] List<string> lines;

    public Dialogue(List<string> lines)
    {
        this.lines = lines;
    }

    public List<string> Lines 
    {
        get { return lines; }
    }
}
