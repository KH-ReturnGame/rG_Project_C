using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public float baseSpawnInterval = 2.0f;
    private float spawnInterval;
    private float timer;

    void Start()
    {
        spawnInterval = baseSpawnInterval; 
    }

    void Update()
    {
        // 노트 생성 주기 조정
        if (GameManager.Instance != null)
        {
            spawnInterval = baseSpawnInterval / GameManager.Instance.CurrentSpeed;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnNote();
            timer = 0f;
        }
    }

    void SpawnNote()
    {
        float xPosition = Random.Range(-2.5f, 2.5f);
        Vector3 spawnPosition = new Vector3(xPosition, 5, 0);
        Instantiate(notePrefab, spawnPosition, Quaternion.identity);
    }
}



