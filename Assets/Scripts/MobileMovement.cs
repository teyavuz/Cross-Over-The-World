using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private bool isSwiping = false;
    
    [SerializeField] private float lerpCount = 5f;

    public float swipeThreshold = 20f;
    public float minX = -5f;
    public float maxX = 5f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float lerpTime = 1f;
    private float currentLerpTime;
    private float perc = 1f;

    private void Update()
    {
        DetectSwipe();
        MoveCharacter();
    }

    void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    touchEndPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    if (isSwiping)
                    {
                        Vector3 swipeDirection = touchEndPos - touchStartPos;

                        if (swipeDirection.magnitude >= swipeThreshold)
                        {
                            // Swipe mesafesi yeterince uzunsa bir swipe algılandı
                            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                            {
                                // Yatay yönde bir swipe algılandı
                                if (swipeDirection.x > 0)
                                {
                                    // Sağa swipe yapıldı
                                    endPosition = new Vector3(Mathf.Clamp(transform.position.x + 2, minX, maxX), transform.position.y, transform.position.z);
                                    gameObject.transform.rotation=Quaternion.Euler(0,90,0);
                                }
                                else
                                {
                                    // Sola swipe yapıldı
                                    endPosition = new Vector3(Mathf.Clamp(transform.position.x - 2, minX, maxX), transform.position.y, transform.position.z);
                                    gameObject.transform.rotation=Quaternion.Euler(0,-90,0);
                                }
                            }
                            else
                            {
                                // Dikey yönde bir swipe algılandı
                                if (swipeDirection.y > 0)
                                {
                                    // Yukarı swipe yapıldı
                                    endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
                                    gameObject.transform.rotation=Quaternion.Euler(0,0,0);
                                }
                                else
                                {
                                    // Aşağı swipe yapıldı
                                    endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
                                    gameObject.transform.rotation=Quaternion.Euler(0,-180,0);
                                }
                            }

                            // Swipe hareketini başlat
                            startPosition = transform.position;
                            currentLerpTime = 0;
                        }
                    }
                    break;
            }
        }
        else
        {
            isSwiping = false;
        }
    }

    void MoveCharacter()
    {
        // Swipe hareketini yürüt
        if (currentLerpTime < lerpTime)
        {
            currentLerpTime += Time.deltaTime;
            perc = currentLerpTime / lerpTime * lerpCount;
            transform.position = Vector3.Lerp(startPosition, endPosition, perc);
        }
    }
}