using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
        
        if (transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
}
