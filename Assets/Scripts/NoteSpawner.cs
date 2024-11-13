using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public NoteMap noteMap;
    private int currentNoteIndex = 0;
    public float radius = 9f;  // 반원의 반지름
    public float minAngle = 0f;  // 최소 각도 (0도)
    public float maxAngle = Mathf.PI;  // 최대 각도 (π, 180도)

    void FixedUpdate()
    {
        if (Time.timeScale == 0 || currentNoteIndex >= noteMap.notes.Count) return;

        if (Time.time >= noteMap.notes[currentNoteIndex].time)
        {
            // 반원 위의 랜덤한 위치 계산하여 노트 스폰
            SpawnNoteOnArc();
            currentNoteIndex++;
        }
    }

    void SpawnNoteOnArc()
    {
        // 랜덤한 각도 선택 (minAngle에서 maxAngle 사이)
        float randomAngle = Random.Range(minAngle, maxAngle);

        // 반원에서 X, Y 좌표 계산
        float xPosition = radius * Mathf.Cos(randomAngle);  // 반원 위의 X좌표
        float yPosition = radius * Mathf.Sin(randomAngle);  // 반원 위의 Y좌표

        // 노트를 계산된 위치에 생성
        Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0);
        Instantiate(notePrefab, spawnPosition, Quaternion.identity);
    }
}
