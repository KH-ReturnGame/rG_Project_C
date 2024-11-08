using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float initialSpeed = 5.0f;

    public float CurrentSpeed { get; private set; }

    private int missedNotes = 0; // 놓친 노트 수
    public int maxMissedNotes = 5;

    public Transform judgementLine;
    public float perfectTiming = 0.1f; // 100ms 이내
    public float greatTiming = 0.2f; // 200ms 이내
    public float okayTiming = 0.3f; // 300ms 이내
    public float lateTiming = 0.5f; // 500ms 이내
    public float maxDistanceX = 100f; // 판정 가능 거리
    public float maxTimingInMs = 1000f; // 최대 판정 시간
    public int combo = 0;
    public float score;

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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))
        {
            CheckJudgement();
        }

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
        SceneManager.LoadScene("EndScene");
        Time.timeScale = 0;
    }

    void CheckJudgement()
    {
        // 가장 가까운 노트 찾기
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
        GameObject closestNote = null;
        float minDistance = float.MaxValue;

        foreach (GameObject note in notes)
        {
            float distance = Mathf.Abs(note.transform.position.x - judgementLine.position.x);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestNote = note;
            }
        }

        // x 좌표가 유효한지 확인
        if (closestNote != null && Mathf.Abs(closestNote.transform.position.x - judgementLine.position.x) <= maxDistanceX)
        {
            // 노트와 판정선의 거리 계산
            float timing = closestNote.transform.position.x - judgementLine.position.x;
            float timingInMs = Mathf.Abs(timing) * 1000f / 5f;

            string sign = timing > 0 ? "+" : "-";

            string newResultText = "";

            // 판정 결과 계산
            if (timingInMs <= perfectTiming * 1000f)
            {
                newResultText = $"Perfect!\n{sign}{timingInMs.ToString("F1")}ms";
                Destroy(closestNote); // Perfect timing, destroy note

                // 콤보 계산
                // combo += 1;

                // 점수 계산
                score += 200;
                Debug.Log("Score: " + score);


            }
            else if (timingInMs <= greatTiming * 1000f)
            {
                newResultText = $"Great!\n{sign}{timingInMs.ToString("F1")}ms";
                Destroy(closestNote); // Great timing, destroy note

                // 콤보 계산
                // combo += 1;

                // 점수 계산
                score += 200;
                Debug.Log("Score: " + score);
            }
            else if (timingInMs <= okayTiming * 1000f)
            {
                newResultText = $"Okay\n{sign}{timingInMs.ToString("F1")}ms";
                Destroy(closestNote); // Okay timing, destroy note

                // 콤보 계산
                // combo += 1;

                // 점수 계산
                score += 200;
                Debug.Log("Score: " + score);

            }
            else if (timingInMs <= lateTiming * 1000f)
            {
                newResultText = $"Late!\n{sign}{timingInMs.ToString("F1")}ms";
                Destroy(closestNote); // Late timing, destroy note

                combo = 0;

            }
            else if (timingInMs <= maxTimingInMs)
            {
                newResultText = $"Miss!\n{sign}{timingInMs.ToString("F1")}ms";
                Destroy(closestNote); // Timing exceeds late but still within 1000ms, destroy note

                combo = 0;
            }
            else
            {
                // 인식 범위 밖

                combo = 0;

            }

            Debug.Log(score);

        }
    }
}
        //    // ComboText 색 변화
        //    if (combo < 7)
        //    {
        //        comboText.text = "";
        //    }
        //    else if (combo < 15)
        //    {
        //        comboText.color = Color.gray;
        //    }
        //    else if (combo < 30)
        //    {
        //        comboText.color = Color.yellow;
        //    }
        //    else
        //    {
        //        comboText.color = Color.magenta;
        //    }
        //}

        //void ShowResultText(string message, Color color)
        //{
        //    if (message != currentText)
        //    {
        //        currentText = message;
        //        resultText.text = message;
        //        resultText.color = color;
        //    }
        //}

        //void Score(float addscore)
        //{

        //    if (combo < 7)
        //    {
        //        score += addscore;
        //    }
        //    else if (combo < 15)
        //    {
        //        score += (addscore * 1.1F);
        //    }
        //    else if (combo < 30)
        //    {
        //        score += (addscore * 1.2F);
        //    }
        //    else if (combo < 50)
        //    {
        //        score += (addscore * 1.3F);
        //    }
        //    else
        //    {
        //        score += (addscore * 1.5F);
        //    }
        //}
        //}
