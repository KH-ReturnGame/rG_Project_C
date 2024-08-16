using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeArea : MonoBehaviour
{
    public int score = 0;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            score++;
            Destroy(other.gameObject);
            Debug.Log("Score: " + score);
        }
    }
}

