using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Vector2 targetPosition;  // 목표 위치
    public float moveSpeed = 5f;  // 이동 속도

    void Start()
    {
        // 목표 위치를 설정 
        targetPosition = new Vector2(0, -6f); 
    }

    void Update()
    {
        if (GameManager.Instance != null)
        {
            float speed = GameManager.Instance.CurrentSpeed;
            float adjustedSpeed = moveSpeed * Mathf.Clamp(speed, 0.5f, 2f); // speed 값 제한
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, adjustedSpeed * Time.deltaTime);
        }

        if (transform.position == (Vector3)targetPosition)
        {
            Debug.Log("!!");
            GameManager.Instance.NoteMissed();  // 놓친 노트 처리
            Destroy(gameObject);
        }
    }
}
