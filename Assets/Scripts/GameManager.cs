using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float initialSpeed = 5.0f;
    
    public float CurrentSpeed { get; private set; }

    private int missedNotes = 0; // 놓친 노트 수
    public int maxMissedNotes = 5;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        CurrentSpeed = initialSpeed;
    }


    void Update()
    {
        if (Time.timeScale == 0) return; 
    }

    
    public void NoteMissed()
    {
        missedNotes++;
        Debug.Log("Missed Notes: " + missedNotes);

        if (missedNotes >= maxMissedNotes)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }
}