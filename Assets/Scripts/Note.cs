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
            Debug.Log(" 현재 노트 속도: " + speed);
            
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}








