using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public bool tap, swipeUp, swipeDown, swipeLeft, swipeRight;
    //int tapCount = 0;
    private bool isDragging=false;
    public Vector2 startTouch, swipeDelta;
   

    void Update()
    {
        tap = swipeDown = swipeLeft = swipeUp = swipeRight = false;
        #region StandaloneInputs

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;

        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
        #endregion

        #region MobileInputs
        if(Input.touches.Length>0)
        {
            if(Input.touches[0].phase==TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase==TouchPhase.Ended || Input.touches[0].phase==TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if(isDragging)
        {
            if(Input.touches.Length>0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
        if(swipeDelta.magnitude>125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x)>Mathf.Abs(y))
            {
                //left or right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //up or down
                if (y > 0)
                    swipeUp = true;
                else
                    swipeDown = true;
            }
            Reset();
        }
    }
    void Reset()
    {
        isDragging = false;

        startTouch = swipeDelta = Vector2.zero;
    }
}
