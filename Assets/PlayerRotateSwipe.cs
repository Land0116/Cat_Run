using UnityEngine;
using System;

public class PlayerRotateSwipe : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private bool swipeDetected;

    public event Action<string> OnSwipe; // 스와이프 이벤트

    private void Update()
    {
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Input.GetMouseButtonDown(0)) // 터치 시작 (PC에서는 마우스)
        {
            startTouchPosition = Input.mousePosition;
            swipeDetected = true;
        }

        if (Input.GetMouseButtonUp(0) && swipeDetected) // 터치 끝
        {
            endTouchPosition = Input.mousePosition;
            Vector2 swipeDelta = endTouchPosition - startTouchPosition;

            if (swipeDelta.magnitude > 50) // 최소 스와이프 거리 (픽셀)
            {
                DetermineSwipeDirection(swipeDelta);
            }

            swipeDetected = false;
        }
    }

    private void DetermineSwipeDirection(Vector2 swipeDelta)
    {
        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y)) // 가로 스와이프
        {
            if (swipeDelta.x > 0)
                OnSwipe?.Invoke("Right"); // 오른쪽
            else
                OnSwipe?.Invoke("Left"); // 왼쪽
        }
        else // 세로 스와이프
        {
            if (swipeDelta.y > 0)
                OnSwipe?.Invoke("Up"); // 위쪽
            else
                OnSwipe?.Invoke("Down"); // 아래쪽
        }
    }
}


