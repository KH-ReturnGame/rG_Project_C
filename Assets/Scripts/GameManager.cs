using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float initialSpeed = 2.0f;   // 초기 속도
    public float acceleration = 1.0f;   // 시간당 속도 증가량

    private float timeElapsed = 0.0f;   // 경과 시간

    public float CurrentSpeed { get; private set; }  // 현재 속도

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
        timeElapsed += Time.deltaTime;
        CurrentSpeed = initialSpeed + acceleration * timeElapsed;
    }
}

