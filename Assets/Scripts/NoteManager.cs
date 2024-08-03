using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public GameObject notePrefab; 
    public Transform spawnPoint;
    public float spawnInterval = 0.5f; // 노트 생성 간격
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);
            timer = 0f;
        }
    }
}

