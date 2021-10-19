using UnityEngine;

public class BallCollisionsPractice : MonoBehaviour
{

    string barrierTag = "barrier";
    string kerbTag = "kerb";
    string roadTag = "road";
    string road2Tag = "road2";

    public GameObject announcement;
    public bool shotTaken = false;
    public GameObject twoPointZone;

    private int timer = 0;
    private bool timerActive = false;

    private bool barrierHit = false;
    private bool kerbHit = false;
    private bool roadHit = false;
    private bool pointScored = false;


    private void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        twoPointZone.GetComponent<SpriteRenderer>().enabled = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(roadTag) == true || collision.collider.CompareTag(road2Tag) == true)
        {
            if (!kerbHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("Miss");
                timerActive = true;
                roadHit = true;
            }
        }

        if (collision.collider.CompareTag(roadTag) == true && kerbHit && !roadHit)
        {
            announcement.GetComponent<DisplayText>().Announcement("1 point");
            timerActive = true;
            roadHit = true;
            pointScored = true;
        }

        if (collision.collider.CompareTag(road2Tag) == true && kerbHit && !roadHit)
        {
            announcement.GetComponent<DisplayText>().Announcement("2 points");
            timerActive = true;
            roadHit = true;
            pointScored = true;
        }

        if (collision.collider.CompareTag(kerbTag) == true && !barrierHit && !roadHit)
        {
            kerbHit = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(barrierTag) == true && !pointScored)
        {
            announcement.GetComponent<DisplayText>().Announcement("Miss");
            timerActive = true;
            barrierHit = true;
        }
    }

    private void FixedUpdate()
    {
        if (timerActive)
        {
            timer++;

            if (timer == 60 && barrierHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                timer = 0;
                timerActive = false;
                barrierHit = false;
                GetComponent<Transform>().position = new Vector3(-7, -3, 0);
                pointScored = false;
                shotTaken = false;
                roadHit = false;
                kerbHit = false;
                twoPointZone.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (timer == 60 && roadHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                timer = 0;
                timerActive = false;
                kerbHit = false;
                roadHit = false;
                GetComponent<Transform>().position = new Vector3(-7, -3, 0);
                pointScored = false;
                shotTaken = false;
                twoPointZone.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

}
