using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Swipe : MonoBehaviour
{

    public float comfortZone = 70.0f;
    public float minSwipeDist = 14.0f;
    public float maxSwipeTime = 0.5f;

    private float startTime;
    private Vector2 startPos;
    private bool couldBeSwipe;

    public GameObject p1, p2;

    public GameObject controls;

    Vector2 wp;
    Ray2D ray;
    RaycastHit2D hit;


    public enum SwipeDirection
    {
        None,
        Up,
        Down
    }

    public SwipeDirection lastSwipe = Swipe.SwipeDirection.None;
    public float lastSwipeTime;


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch[] touch = Input.touches;



            for (int i = 0; i < Input.touchCount; i++)
            {
                switch (touch[i].phase)
                {
                    case TouchPhase.Began:

                        lastSwipe = Swipe.SwipeDirection.None;
                        lastSwipeTime = 0;
                        couldBeSwipe = true;

                        startPos = touch[i].position;
                        if (Camera.main.ScreenToViewportPoint(startPos).x < 0.5f)
                            controls = p1;
                        else
                            controls = p2;

                        startTime = Time.time;
                        break;
                    case TouchPhase.Moved:
                        if (Mathf.Abs(touch[i].position.x - startPos.x) > comfortZone)
                        {
                            Debug.Log("Not a swipe. Swipe strayed " + (int)Mathf.Abs(touch[i].position.x - startPos.x) +
                                      "px which is " + (int)(Mathf.Abs(touch[i].position.x - startPos.x) - comfortZone) +
                                      "px outside the comfort zone.");
                            couldBeSwipe = false;
                        }
                        break;
                    case TouchPhase.Ended:
                        if (couldBeSwipe)
                        {
                            float swipeTime = Time.time - startTime;
                            float swipeDist = (new Vector3(0, touch[i].position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                            if ((swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist))
                            {
                                // It's a swiiiiiiiiiiiipe!
                                float swipeValue = Mathf.Sign(touch[i].position.y - startPos.y);

                                // If the swipe direction is positive, it was an upward swipe.
                                // If the swipe direction is negative, it was a downward swipe.
                                if (swipeValue > 0)
                                {
                                    lastSwipe = Swipe.SwipeDirection.Up;
                                    UP();
                                }
                                else if (swipeValue < 0)
                                {
                                    lastSwipe = Swipe.SwipeDirection.Down;
                                    DOWN();
                                }

                                // Set the time the last swipe occured, useful for other scripts to check:
                                lastSwipeTime = Time.time;
                                Debug.Log("Found a swipe!  Direction: " + lastSwipe);
                            }
                        }
                        break;
                }
            }
        }
    }


    public void UP()
    {
        controls.GetComponent<RectTransform>().transform.localPosition = new Vector2(0, 300);
    }

    public void DOWN()
    {
        controls.GetComponent<RectTransform>().transform.localPosition = new Vector2(0, 100);
    }


}
