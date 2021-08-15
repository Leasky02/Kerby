using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlGoldenKerb : MonoBehaviour
{
    public float power;
    public float maxDrag;
    public Rigidbody2D rb;
    public LineRenderer lr;
    public GameObject twoPointZone;

    Vector3 dragStartPos;
    Touch touch;

    private void Start()
    {
        //set the line renderer to 0
        lr.positionCount = 0;
    }
    private void Update()
    {
        //if the screen is being touched...
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            //then begin drag start
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }

            //if the touch is moving, do drag moving function
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }

            //if the touch has been released... do the drag release function
            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }
    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }
    void Dragging()
    {
        if (GetComponent<BallCollisionsGoldenKerb>().shotTaken == false)
        {
            Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
            draggingPos.z = 0f;
            lr.positionCount = 2;
            lr.SetPosition(1, draggingPos);
        }
    }

    public void DragRelease()
    {
        if (GetComponent<BallCollisionsGoldenKerb>().shotTaken == false)
        {
            lr.positionCount = 0;
            Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
            dragReleasePos.z = 0f;

            Vector3 force = dragStartPos - dragReleasePos;
            Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
            if (clampedForce.x > 2 && clampedForce.y > 2)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(clampedForce, ForceMode2D.Impulse);
                twoPointZone.GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<BallCollisionsGoldenKerb>().shotTaken = true;
            }
        }
    }
}
