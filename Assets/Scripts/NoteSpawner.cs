using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public NoteMap noteMap;
    private int currentNoteIndex = 0;

    void FixedUpdate()
    {
        if (Time.timeScale == 0 || currentNoteIndex >= noteMap.notes.Count) return;
        
        if (Time.time >= noteMap.notes[currentNoteIndex].time)
        {
            // 지정된 X좌표에 노트를 스폰
            SpawnNote(noteMap.notes[currentNoteIndex].xPosition);
            currentNoteIndex++;
        }
    }

    void SpawnNote(float xPosition)
    {
        // 노트를 지정된 X좌표에 생성
        Vector3 spawnPosition = new Vector3(xPosition, 5, 0);
        Instantiate(notePrefab, spawnPosition, Quaternion.identity);
    }
}