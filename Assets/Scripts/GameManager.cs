using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float initialSpeed = 2.0f;
    public float acceleration = 0.1f;
    //private float timeElapsed = 0.0f;

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
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CurrentSpeed = initialSpeed;
    }

    void Update()
    {
        /*if (Time.timeScale == 0) return;

        timeElapsed += Time.deltaTime;
        CurrentSpeed = initialSpeed + acceleration * timeElapsed;*/
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
    
    void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;
    }
}


