using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Judgement : MonoBehaviour
{
    public Transform judgementLine; 
    public TextMeshProUGUI resultText; 
    public float perfectTiming = 0.1f; // 100ms 이내
    public float greatTiming = 0.2f; // 200ms 이내
    public float okayTiming = 0.3f; // 300ms 이내
    public float lateTiming = 0.5f; // 500ms 이내
    private string currentText = ""; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckJudgement();
        }
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

        // 판정선에 가장 가까운 노트를 찾기
        if (closestNote != null)
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
                ShowResultText(newResultText, Color.blue);
            }
            else if (timingInMs <= greatTiming * 1000f)
            {
                newResultText = $"Great!\n{sign}{timingInMs.ToString("F1")}ms";
                ShowResultText(newResultText, Color.green);
            }
            else if (timingInMs <= okayTiming * 1000f)
            {
                newResultText = $"Okay\n{sign}{timingInMs.ToString("F1")}ms";
                ShowResultText(newResultText, Color.yellow);
            }
            else if (timingInMs <= lateTiming * 1000f)
            {
                newResultText = $"Late!\n{sign}{timingInMs.ToString("F1")}ms";
                ShowResultText(newResultText, Color.red);
            }
            else
            {
                newResultText = $"Miss!\n{sign}{timingInMs.ToString("F1")}ms";
                ShowResultText(newResultText, Color.white);
            }
            
            Destroy(closestNote);
        }
    }

    void ShowResultText(string message, Color color)
    {
        if (message != currentText)
        {
            currentText = message;
            resultText.text = message;
            resultText.color = color;
        }
    }
}
