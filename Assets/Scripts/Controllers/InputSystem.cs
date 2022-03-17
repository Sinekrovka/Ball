using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private float minDistanceFlip;
    
    private Vector3 firstTouchPos;
    private Vector3 secongTouchPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            secongTouchPos = Input.mousePosition;
            float distance = firstTouchPos.x - secongTouchPos.x;
            if (minDistanceFlip > Mathf.Abs(distance))
            {
                PlayerMovementController.Instance.JumpBallUp();
            }
            else
            {
                PlayerMovementController.Instance.JumpBallX(distance);
            }
        }
    }
}
