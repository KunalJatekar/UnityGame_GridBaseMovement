using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] float maxTime;
    [SerializeField] float minSwipeDistance;

    float startTime;
    float endTime;
    float swipeDistance;
    float swipeTime;
    Vector3 startPos;
    Vector3 endPos;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if(touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if(swipeTime < maxTime && swipeDistance > minSwipeDistance)
                {
                    swipe();
                }
            }
        }
    }

    private void swipe()
    {
        Vector2 distance = endPos - startPos;

        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            if (distance.x > 0)
            {
                playerMovement.playerMove("Right");
            }
            if (distance.x < 0)
            {
                playerMovement.playerMove("Left");
            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            if (distance.y > 0)
            {
                playerMovement.playerMove("Up");
            }
            if (distance.y < 0)
            {
                playerMovement.playerMove("Down");
            }
        }
    }
}
