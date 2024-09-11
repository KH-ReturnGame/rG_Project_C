using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NoteMap", menuName = "ScriptableObjects/NoteMap", order = 1)]
public class NoteMap : ScriptableObject
{
    public List<NoteData> notes;
}

[System.Serializable]
public class NoteData
{
    public float time;
    public float xPosition;
}