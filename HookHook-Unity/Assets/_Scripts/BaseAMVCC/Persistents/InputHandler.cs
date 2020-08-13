using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;

    public TouchState State { get { return _state; } }
    public TouchState _state = TouchState.Drop;

    private Vector3 _startTouchPos;
    [SerializeField]
    private float diffX, diffY;
    private float startFrame;

    public event Action OnSwipeLeft;
    public void SwipeLeft() {
        if (OnSwipeLeft != null)
            OnSwipeLeft();
    }
    public event Action OnSwipeRight;
    public void SwipeRight() {
        if (OnSwipeRight != null)
            OnSwipeRight();
    }
    public event Action OnSwipeUp;
    public void SwipeUp() {
        if (OnSwipeUp != null)
            OnSwipeUp();
    }
    public event Action OnSwipeDown;
    public void SwipeDown() {
        if (OnSwipeDown != null)
            OnSwipeDown();
    }
    public event Action OnTouchScreen;
    public void TouchScreen()
    {
<<<<<<< HEAD
        //Debug.Log("Cc");
=======
>>>>>>> origin/dev-ngh
        if (OnTouchScreen != null)
            OnTouchScreen();
    }
    public event Action OnReleaseScreen;
    public void ReleaseScreen()
    { 
        if (OnReleaseScreen != null)
            OnReleaseScreen();
    }
    private void Awake()
    {
        Instance = this;
    }
    public GameObject GetHoveredObject()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

        if (hit.collider == null) return null;
        return hit.collider.gameObject;
    }
    public GameObject GetHoldObject()
    {
        if (!Input.GetMouseButtonDown(0)) return null;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

        if (hit.collider == null || Input.GetMouseButtonUp(0)) return null;
        return hit.collider.gameObject;
    }
    public GameObject GetClickedObject()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

        if (hit.collider == null) return null;
        if (Input.GetMouseButtonUp(0))
            return hit.collider.gameObject;
        else return null;
    }
    public bool DropObject()
    {
        return (Input.GetMouseButtonUp(0));
    }
    private void MouseCheck()
    {
        if (Input.GetMouseButtonDown(0) && _state == TouchState.Drop)
        {
            _startTouchPos = Input.mousePosition;
            _state = TouchState.Start;
            startFrame = Time.realtimeSinceStartup;
            TouchScreen();
        }

        if (_state == TouchState.Start || _state == TouchState.Drag)
        {
            TouchScreen();
            if (Input.mousePosition != _startTouchPos)
            {   
                _state = TouchState.Drag;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _state = TouchState.Drop;
            ReleaseScreen();
            if (Time.realtimeSinceStartup - startFrame < .5f)
                Swipe();
        }
    }

    #region Move Command Definition
    void Swipe()
    {
        float disX = Mathf.Abs(Input.mousePosition.x - _startTouchPos.x);
        float disY = Mathf.Abs(Input.mousePosition.y - _startTouchPos.y);
        if (disX > diffX && disX > disY)
        {
            if (Input.mousePosition.x > _startTouchPos.x) {
                SwipeRight();
            }
            else {
                SwipeLeft();
            }
        }

        if (disY > diffY && disY > disX)
        {
            if (Input.mousePosition.y > _startTouchPos.y) {
                Debug.Log("SwipeUp");
                SwipeUp();
            }
            else {
                Debug.Log("SwipeDown");
                SwipeDown();
            }

        }
    }
    #endregion
    private void Update()
    {
        MouseCheck();
    }
}
