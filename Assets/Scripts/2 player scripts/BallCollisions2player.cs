using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCollisions2player : MonoBehaviour
{

    string barrierTag = "barrier";
    string kerbTag = "kerb";
    string roadTag = "road";
    string road2Tag = "road2";

    public GameObject announcement;
    public bool shotTaken = false;
    public GameObject twoPointZone;
    public GameObject activePlayer;
    public GameObject playerView;
    public GameObject scoreDisplay;
    public GameObject winnerDisplay;
    public GameObject coinDisplay;

    private int timer = 0;
    private bool timerActive = false;

    private bool barrierHit = false;
    private bool kerbHit = false;
    private bool roadHit = false;
    private bool pointScored = false;
    private bool endOfGame = false;

    public bool player1 = true;

    public int player1Score = 0;
    public int player2score = 0;

    private bool ballCollision = false;
    private int ballTimer = 0;

    private float randomYlocation;

    public ParticleSystem missParticles;
    public AudioClip bounceSound;
    public AudioClip celebrateSound;
    public AudioClip failSound;

    public ParticleSystem[] confetti;

    private float xPos;
    private float yPos;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        twoPointZone.GetComponent<SpriteRenderer>().enabled = false;
        xPos = GetComponent<Transform>().position.x;
        yPos = GetComponent<Transform>().position.y;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!ballCollision)
        {
            GetComponent<AudioSource>().clip = bounceSound;
            GetComponent<AudioSource>().Play();
            ballCollision = true;
        }

        if (collision.collider.CompareTag(roadTag) == true || collision.collider.CompareTag(road2Tag) == true)
        {
            if (!kerbHit)
            {
                announcement.GetComponent<DisplayText>().Announcement("Miss");
                announcement.GetComponent<Text>().color = new Color(227f / 255f, 28f / 255f, 25f / 255f, 100f);
                timerActive = true;
                roadHit = true;
                GetComponent<Statistics>().ShotScored(false);
                missParticles.transform.position = gameObject.transform.position;
                missParticles.Play();
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<AudioSource>().clip = failSound;
                GetComponent<AudioSource>().Play();
            }
        }

        if (collision.collider.CompareTag(roadTag) == true && kerbHit && !roadHit && !barrierHit)
        {
            announcement.GetComponent<DisplayText>().Announcement("1 point");
            announcement.GetComponent<Text>().color = new Color(0.388f, 0.658f, 0.203f);
            timerActive = true;
            roadHit = true;
            pointScored = true;
            GetComponent<Statistics>().ShotScored(true);
            GetComponent<Statistics>().AddTotalPoints(1);

            if (player1)
            {
                player1Score++;
            }else if(!player1)
            {
                player2score++;
            }

        }

        if (collision.collider.CompareTag(road2Tag) == true && kerbHit && !roadHit && !barrierHit)
        {
            announcement.GetComponent<DisplayText>().Announcement("2 points");
            announcement.GetComponent<Text>().color = new Color(0.388f, 0.658f, 0.203f);
            timerActive = true;
            roadHit = true;
            pointScored = true;
            GetComponent<Statistics>().ShotScored(true);
            GetComponent<Statistics>().AddTotalPoints(2);

            if (player1)
            {
                player1Score+=2;
            }
            else if (!player1)
            {
                player2score+=2;
            }
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
            announcement.GetComponent<Text>().color = new Color(227f / 255f, 28f / 255f, 25f / 255f, 100f);
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

            if (timer == 30)
            {
                player1 = !player1;

                scoreDisplay.GetComponent<setScore>().SetScore(player1Score, player2score);
                if(player1Score >= 10)
                {
                    //end game with player 1 win

                    GetComponent<Transform>().position = new Vector3(xPos, yPos, 0);
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    GetComponent<PauseScreenScript>().PauseScreen();
                    //winner sound and confetti
                    GetComponent<AudioSource>().clip = celebrateSound;
                    GetComponent<AudioSource>().Play();
                    confetti[0].Play();
                    confetti[1].Play();
                    confetti[2].Play();
                    confetti[3].Play();

                    winnerDisplay.GetComponent<Text>().text =("Player 1 wins! Play Again? \n\n   +25");
                    coinDisplay.GetComponent<CoinCount>().AddCoins(25);
                    endOfGame = true;
                    GetComponent<Statistics>().AddGamesPlayed();
                } else if(player2score >= 10)
                {
                    //end game with player 2 win
                    GetComponent<Transform>().position = new Vector3(xPos, yPos, 0);
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    GetComponent<PauseScreenScript>().PauseScreen();
                    //winner and confetti
                    GetComponent<AudioSource>().clip = celebrateSound;
                    GetComponent<AudioSource>().Play();
                    confetti[0].Play();
                    confetti[1].Play();
                    confetti[2].Play();
                    confetti[3].Play();

                    winnerDisplay.GetComponent<Text>().text = ("Player 2 wins! Play Again? \n\n   +25");
                    coinDisplay.GetComponent<CoinCount>().AddCoins(25);
                    endOfGame = true;
                    GetComponent<Statistics>().AddGamesPlayed();
                } else if (player1)
                {
                    activePlayer.GetComponent<DisplayText>().Announcement("Player 1");
                    activePlayer.GetComponent<Animator>().Play("change player");
                    playerView.GetComponent<Transform>().Rotate(0, 180, 0);
                    randomYlocation = Random.Range(yPos, yPos - 0.3f);
                    GetComponent<Transform>().position = new Vector3(xPos, randomYlocation, 0);
                }
                else if (!player1)
                {
                    activePlayer.GetComponent<DisplayText>().Announcement("Player 2");
                    activePlayer.GetComponent<Animator>().Play("change player");
                    playerView.GetComponent<Transform>().Rotate(0, 180, 0);
                    randomYlocation = Random.Range(yPos, yPos - 0.3f);
                    GetComponent<Transform>().position = new Vector3(xPos - (xPos * 2), randomYlocation, 0);
                }
            }

            if (timer == 30 && barrierHit && !endOfGame)
            {
                announcement.GetComponent<DisplayText>().Announcement("");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                timer = 0;
                timerActive = false;
                barrierHit = false;
                pointScored = false;
                shotTaken = false;
                roadHit = false;
                kerbHit = false;
                twoPointZone.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = true;
            } else if (timer == 30 && roadHit &&!endOfGame)
            {
                announcement.GetComponent<DisplayText>().Announcement("");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                timer = 0;
                timerActive = false;
                kerbHit = false;
                roadHit = false;
                pointScored = false;
                shotTaken = false;
                twoPointZone.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = true;
            }

        }
    }

}
