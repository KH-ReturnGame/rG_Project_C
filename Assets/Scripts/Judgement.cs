using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Judgement : MonoBehaviour
{
    public Transform judgementLine;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI comboText;
    public float perfectTiming = 0.1f; // 100ms 이내
    public float greatTiming = 0.2f; // 200ms 이내
    public float okayTiming = 0.3f; // 300ms 이내
    public float lateTiming = 0.5f; // 500ms 이내
    private string currentText = "";
    public float maxDistanceX = 100f; // 판정 가능 거리
    public float maxTimingInMs = 1000f; // 최대 판정 시간
    public float combo = 0;


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

        // x 좌표가 유효한지 확인
        if (closestNote != null && Mathf.Abs(closestNote.transform.position.x - judgementLine.position.x) <= maxDistanceX)
        {
            // 노트와 판정선의 거리 계산
            float timing = closestNote.transform.position.x - judgementLine.position.x;
            float timingInMs = Mathf.Abs(timing) * 1000f / 5f;

            string sign = timing > 0 ? "+" : "-";

            string newResultText = "";

            // 콤보 관련 변수
            string newComboText = " ";

            // 판정 결과 계산
            if (timingInMs <= perfectTiming * 1000f)
            {
                newResultText = $"Perfect!\n{sign}{timingInMs.ToString("F1")}ms";
                ShowResultText(newResultText, Color.blue);
                Destroy(closestNote); // Perfect timing, destroy note

                combo += 1;
                Debug.Log(combo);
                newComboText =  $"Combo: {combo}";
                ShowComboText(newComboText);
            }
            else if (timingInMs <= greatTiming * 1000f)
            {
                newResultText = $"Great!\n{sign}{timingInMs.ToString("F1")}ms";
                ShowResultText(newResultText, Color.green);
                Destroy(closestNote); // Great timing, destroy note

                combo += 1;
                Debug.Log(combo);
                newComboText = $"Combo: {combo}";
                ShowComboText(newComboText);
            }
            else if (timingInMs <= okayTiming * 1000f)
            {
                newResultText = $"Okay\n{sign}{timingInMs.ToString("F1")}ms";
                ShowResultText(newResultText, Color.yellow);
                Destroy(closestNote); // Okay timing, destroy note

                combo += 1;
                Debug.Log(combo);
                newComboText = $"Combo: {combo}";
                ShowComboText(newComboText);
            }
            else if (timingInMs <= lateTiming * 1000f)
            {
                newResultText = $"Late!\n{sign}{timingInMs.ToString("F1")}ms";
                ShowResultText(newResultText, Color.red);
                Destroy(closestNote); // Late timing, destroy note

                combo = 0;
                Debug.Log(combo);
                newComboText = $"Combo: {combo}";
                ShowComboText(newComboText);
            }
            else if (timingInMs <= maxTimingInMs)
            {
                newResultText = $"Miss!\n{sign}{timingInMs.ToString("F1")}ms";
                ShowResultText(newResultText, Color.white);
                Destroy(closestNote); // Timing exceeds late but still within 1000ms, destroy note

                combo = 0;
                ShowComboText(newComboText);
            }
            else
            {
                // 인식 범위 밖
                ShowResultText("Too Early!", Color.gray); 
               
                combo = 0;
                Debug.Log(combo);
                newComboText = $"Combo: {combo}";
                ShowComboText(newComboText);
            }
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

    void ShowComboText(string message)
    {
         comboText.text = message;
    }
}
