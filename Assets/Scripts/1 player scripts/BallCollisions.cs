using UnityEngine;
using UnityEngine.UI;

public class BallCollisions : MonoBehaviour
{

    string barrierTag = "barrier";
    string kerbTag = "kerb";
    string roadTag = "road";
    string road2Tag = "road2";

    public GameObject announcement;
    public bool shotTaken = false;
    public GameObject twoPointZone;
    public GameObject currentStreak;

    private int timer = 0;
    private bool timerActive = false;

    private bool barrierHit = false;
    private bool kerbHit = false;
    private bool roadHit = false;
    private bool pointScored = false;

    private bool ballCollision = false;
    private int ballTimer = 0;

    public int streak = 0;

    private float randomYlocation;

    public ParticleSystem missParticles;
    public AudioClip bounceSound;
    public AudioClip failSound;

    private float xPos;
    private float yPos;

    private void Awake()
    {
        //set ball so its doesnt move
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //make the green zone for 2 pointers disappear
        twoPointZone.GetComponent<SpriteRenderer>().enabled = false;
        xPos = GetComponent<Transform>().position.x;
        yPos = GetComponent<Transform>().position.y;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if the ball hasnt already collided, set it to collided and play the sound
        if (!ballCollision)
        {
            GetComponent<AudioSource>().clip = bounceSound;
            GetComponent<AudioSource>().Play();
            ballCollision = true;
        }
        //if it has collided with the road2...
        if (collision.collider.CompareTag(roadTag) == true || collision.collider.CompareTag(road2Tag) == true)
        {
            //then has it already hit the kerb? if not...
            if(!kerbHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("Miss");
                announcement.GetComponent<Text>().color = new Color(184f / 255f, 31f / 255f, 31f / 255f, 100f); 
                timerActive = true;
                roadHit = true;
                streak = 0;
                currentStreak.GetComponent<Text>().text = "Score: " + streak;
                GetComponent<Statistics>().ShotScored(false);
                missParticles.transform.position = gameObject.transform.position;
                missParticles.Play();
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<AudioSource>().clip = failSound;
                GetComponent<AudioSource>().Play();
            }
        }
        //has it hit the road1 as well as not hit the kerb or the road already...
        if (collision.collider.CompareTag(roadTag) == true && kerbHit && !roadHit && !barrierHit)
        {
            announcement.GetComponent<DisplayText>().Announcement("1 point");
            announcement.GetComponent<Text>().color = new Color(0.388f, 0.658f, 0.203f); 
            timerActive = true;
            roadHit = true;
            pointScored = true;
            streak++;
            GetComponent<ScoreStreak>().StreakUpdate(streak, 1);
            currentStreak.GetComponent<Text>().text = "Score: " + streak;
            GetComponent<Statistics>().ShotScored(true);
            GetComponent<Statistics>().AddTotalPoints(1);
        }
        //has it hit the 2nd road or the kerb or rad before...
        if (collision.collider.CompareTag(road2Tag) == true && kerbHit && !roadHit && !barrierHit)
        {
            announcement.GetComponent<DisplayText>().Announcement("2 points");
            announcement.GetComponent<Text>().color = new Color(0.388f, 0.658f, 0.203f);
            timerActive = true;
            roadHit = true;
            pointScored = true;
            streak += 2;
            GetComponent<ScoreStreak>().StreakUpdate(streak, 2);
            currentStreak.GetComponent<Text>().text = "Score: " + streak;
            GetComponent<Statistics>().ShotScored(true);
            GetComponent<Statistics>().AddTotalPoints(2);
        }
        //has it hit the kerb? if so, hit the kerb = true
        if (collision.collider.CompareTag(kerbTag) == true && !barrierHit && !roadHit)
        {
            kerbHit = true;
        }
    }
    //controls trigger entry
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if it hits the barrier and the player hasnt already scored a point
        if (collision.CompareTag(barrierTag) == true && !pointScored)
        {
            announcement.GetComponent<DisplayText>().Announcement("Miss");
            announcement.GetComponent<Text>().color = new Color(184f / 255f, 31f / 255f, 31f / 255f, 100f);
            timerActive = true;
            barrierHit = true;
            streak = 0;
            currentStreak.GetComponent<Text>().text = "Score: " + streak;
            GetComponent<Statistics>().ShotScored(false);
            missParticles.transform.position = gameObject.transform.position;
            missParticles.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<AudioSource>().clip = failSound;
            GetComponent<AudioSource>().Play();
        }
    }

    private void FixedUpdate()
    {
        //has the ball collided?
        if(ballCollision)
        {
            //if so, add 1 to timer
            ballTimer++;
            //if ballTimer is 8, set to 0 and turn it off
            if(ballTimer == 8)
            {
                ballCollision = false;
                ballTimer = 0;
            }
        }
        //if timer is active...
        if(timerActive)
        {
            timer++;
            //then if it has reached 30(1 second) then reset
            if(timer == 30 && barrierHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                timer = 0;
                timerActive = false;
                barrierHit = false;
                randomYlocation = Random.Range(yPos, yPos - 0.3f);
                GetComponent<Transform>().position = new Vector3(xPos, randomYlocation, 0);
                GetComponent<SpriteRenderer>().enabled = true;
                pointScored = false;
                shotTaken = false;
                roadHit = false;
                kerbHit = false;
                twoPointZone.GetComponent<SpriteRenderer>().enabled = false;
            }

            //then if it has reached 30(1 second) then reset
            if (timer == 30 && roadHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                timer = 0;
                timerActive = false;
                kerbHit = false;
                roadHit = false;
                randomYlocation = Random.Range(yPos, yPos - 0.3f);
                GetComponent<Transform>().position = new Vector3(xPos, randomYlocation, 0);
                GetComponent<SpriteRenderer>().enabled = true;
                pointScored = false;
                shotTaken = false;
                twoPointZone.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

}
