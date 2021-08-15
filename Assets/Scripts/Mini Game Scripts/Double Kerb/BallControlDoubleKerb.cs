using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlDoubleKerb : MonoBehaviour
{
    public float power;
    public float maxDrag;
    public Rigidbody2D rb;
    public LineRenderer lr;

    Vector3 dragStartPos;
    Touch touch;

    private void Start()
    {
        lr.positionCount = 0;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }

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
        if (GetComponent<BallCollisionsDoubleKerb>().shotTaken == false)
        {
            Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
            draggingPos.z = 0f;
            lr.positionCount = 2;
            lr.SetPosition(1, draggingPos);
        }
    }

    public void DragRelease()
    {
        if (GetComponent<BallCollisionsDoubleKerb>().shotTaken == false)
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
                GetComponent<BallCollisionsDoubleKerb>().shotTaken = true;
            }
        }
    }
}
