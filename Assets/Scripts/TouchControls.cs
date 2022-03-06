using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    bool touchState = false;
    bool previousFrameTouchState = false;
    bool touchReleased = false;
    bool touchStarted = false;
    bool canFlap = true;

    void FixedUpdate()
    {
        CheckTouchStates();
    }

    void CheckTouchStates()
    {
        if(Input.touchCount <= 0)
        {
            CanFlap = true;
        }

        touchState = Input.touchCount > 0 ? true : false;
        touchStarted = !previousFrameTouchState && touchState ? true : false;
        touchReleased = previousFrameTouchState && !touchState ? true : false;

        previousFrameTouchState = touchState;
    }

    public bool TouchState { get => touchState; set => touchState = value; }
    public bool PreviousFrameTouchState { get => previousFrameTouchState; set => previousFrameTouchState = value; }
    public bool TouchReleased { get => touchReleased; set => touchReleased = value; }
    public bool TouchStarted { get => touchStarted; set => touchStarted = value; }
    public bool CanFlap { get => canFlap; set => canFlap = value; }
}
