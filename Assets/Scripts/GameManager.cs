using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float initialSpeed = 2.0f;
    public float acceleration = 0.1f;
    private float timeElapsed = 0.0f;

    public float CurrentSpeed { get; private set; }

    public TextMeshProUGUI comboText;
    public TextMeshProUGUI missNoteText;

    private float missedNotes = 0; // 놓친 노트 수
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
        if (Time.timeScale == 0) return;

        timeElapsed += Time.deltaTime;
        CurrentSpeed = initialSpeed + acceleration * timeElapsed;
    }
    
    public void NoteMissed()
    {
        missedNotes++;
        Debug.Log("Missed Notes: " + missedNotes);
        if (missedNotes == 1)
        {
            missNoteText.text = ("♥ ♥ ♥ ♥ ♡");
        }
        else if (missedNotes == 2)
        {
            missNoteText.text = ("♥ ♥ ♥ ♡ ♡");
        }
        else if (missedNotes == 3)
        {
            missNoteText.text = ("♥ ♥ ♡ ♡ ♡");
        }
        else if (missedNotes == 4)
        {
            missNoteText.text = ("♥ ♡ ♡ ♡ ♡");
        }
        else if (missedNotes >= maxMissedNotes)
        {
            missNoteText.text = ("♡ ♡ ♡ ♡ ♡");
            GameOver();
        }
    }
    
    void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("EndScene");
    }
}


