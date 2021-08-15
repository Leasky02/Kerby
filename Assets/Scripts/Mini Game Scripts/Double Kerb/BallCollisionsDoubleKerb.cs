using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCollisionsDoubleKerb : MonoBehaviour
{

    string barrierTag = "barrier";
    string kerbTag = "kerb";
    string road2Tag = "road2";

    public GameObject coinsDisplay;
    public GameObject announcement;
    public bool shotTaken = false;
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
    public int doubleKerbsHit;

    private float randomYlocation;

    public ParticleSystem missParticles;
    public AudioClip bounceSound;
    public AudioClip failSound;

    private float xPos;
    private float yPos;

    private void Start()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        xPos = GetComponent<Transform>().position.x;
        yPos = GetComponent<Transform>().position.y;
        doubleKerbsHit = GetComponent<Statistics>().ReturnDoubleKerb();
        currentStreak.GetComponent<Text>().text = "Double Kerbs Hit: " + doubleKerbsHit;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!ballCollision)
        {
            GetComponent<AudioSource>().clip = bounceSound;
            GetComponent<AudioSource>().Play();
            ballCollision = true;
        }
        //if 2nd kerb has been hit...
        if (collision.collider.CompareTag(road2Tag) == true)
        {
            //then has the first kerb been hit? if not then miss
            if (!kerbHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("Miss");
                announcement.GetComponent<Text>().color = new Color(184f / 255f, 31f / 255f, 31f / 255f, 100f);
                timerActive = true;
                roadHit = true;
                missParticles.transform.position = gameObject.transform.position;
                missParticles.Play();
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<AudioSource>().clip = failSound;
                GetComponent<AudioSource>().Play();
            }
        }
        //has the 2nd kerb been hit as well as the first and the barrier hasnt? 
        if (collision.collider.CompareTag(road2Tag) == true && kerbHit && !barrierHit)
        {
            announcement.GetComponent<DisplayText>().Announcement("Double Kerb");
            coinsDisplay.GetComponent<CoinCount>().AddCoins(25);
            announcement.GetComponent<Text>().color = new Color(0.388f, 0.658f, 0.203f);
            timerActive = true;
            roadHit = true;
            GetComponent<Statistics>().DoubleKerb();
            pointScored = true;
            doubleKerbsHit = GetComponent<Statistics>().ReturnDoubleKerb();
            currentStreak.GetComponent<Text>().text = "Double Kerbs Hit: " + doubleKerbsHit;
        }
        //if kerb has been hit and barrier hasnt...
        if (collision.collider.CompareTag(kerbTag) == true && !barrierHit && !roadHit)
        {
            kerbHit = true;
        }
        //if the barrier has been hit and there hasnt been a point scored...
        if (collision.collider.CompareTag(barrierTag) == true && !pointScored)
        {
            announcement.GetComponent<DisplayText>().Announcement("Miss");
            announcement.GetComponent<Text>().color = new Color(184f / 255f, 31f / 255f, 31f / 255f, 100f);
            timerActive = true;
            barrierHit = true;
            missParticles.transform.position = gameObject.transform.position;
            missParticles.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<AudioSource>().clip = failSound;
            GetComponent<AudioSource>().Play();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if the barrier has been hit and no points scored...
        if (collision.CompareTag(barrierTag) == true && !pointScored)
        {
            announcement.GetComponent<DisplayText>().Announcement("Miss");
            announcement.GetComponent<Text>().color = new Color(184f / 255f, 31f / 255f, 31f / 255f, 100f);
            timerActive = true;
            barrierHit = true;
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
        if (ballCollision)
        {
            ballTimer++;
            if (ballTimer == 8)
            {
                ballCollision = false;
                ballTimer = 0;
            }
        }
        if (timerActive)
        {
            timer++;
            if (timer == 30 && barrierHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                timer = 0;
                timerActive = false;
                barrierHit = false;
                randomYlocation = Random.Range(yPos, yPos - 0.2f);
                GetComponent<Transform>().position = new Vector3(xPos, randomYlocation, 0);
                GetComponent<SpriteRenderer>().enabled = true;
                pointScored = false;
                shotTaken = false;
                roadHit = false;
                kerbHit = false;
            }

            if (timer == 30 && roadHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                timer = 0;
                timerActive = false;
                kerbHit = false;
                roadHit = false;
                randomYlocation = Random.Range(yPos, yPos - 0.2f);
                GetComponent<Transform>().position = new Vector3(xPos, randomYlocation, 0);
                GetComponent<SpriteRenderer>().enabled = true;
                pointScored = false;
                shotTaken = false;
            }
        }
    }

}
