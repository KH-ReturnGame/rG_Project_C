using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskRotation : MonoBehaviour
{
    private Vector3 initialMousePosition;  // 첫 번째 마우스 위치
    private bool isFirstMouseInput = true; // 첫 번째 입력 체크

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        
        if (isFirstMouseInput)
        {
            initialMousePosition = mousePos;
            isFirstMouseInput = false;
        }
        else
        {
            Vector3 direction = mousePos - transform.position;
            Vector3 initialDirection = initialMousePosition - transform.position;

            // 두 방향 사이 각도 계산
            float angle = Vector3.SignedAngle(initialDirection, direction, Vector3.forward);
            
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}


