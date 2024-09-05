using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance != null)
        {
            float speed = GameManager.Instance.CurrentSpeed;
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    
        if (transform.position.y < -6)
        {
            GameManager.Instance.NoteMissed();  // 놓친 노트 처리
            Destroy(gameObject);
        }
    }
}