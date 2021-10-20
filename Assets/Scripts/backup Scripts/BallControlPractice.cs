using UnityEngine;

public class BallControlPractice : MonoBehaviour
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
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                DragRelease();
            }
        }
    }
    void DragStart()
    {
        if (GetComponent<BallCollisions>().shotTaken == false)
        {
            dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
            dragStartPos.z = 0f;
            lr.positionCount = 1;
            lr.SetPosition(0, dragStartPos);
        }
    }
    void Dragging()
    {
        if (GetComponent<BallCollisions>().shotTaken == false)
        {
            Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
            draggingPos.z = 0f;
            lr.positionCount = 2;
            lr.SetPosition(1, draggingPos);
        }
    }

    public void DragRelease()
    {
        if (GetComponent<BallCollisions>().shotTaken == false)
        {
            GetComponent<BallCollisions>().shotTaken = true;
            lr.positionCount = 0;
            Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
            dragReleasePos.z = 0f;

            Vector3 force = dragStartPos - dragReleasePos;
            Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
            rb.AddForce(clampedForce, ForceMode2D.Impulse);
            twoPointZone.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
