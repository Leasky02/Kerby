using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{

    public GameObject totalPointsDisplay;
    public GameObject accuracyDisplay;

    public GameObject highestStreakDisplay;
    public GameObject highestStreakDisplayShotInTheDark;
    public GameObject highestStreakDisplayMarsMission;

    public GameObject gamesPlayedDisplay;
    public GameObject doubleKerbDisplay;

    public GameObject rankDisplay;
    public GameObject rankIconDisplay;
    public GameObject RankPauseScreen;
    public GameObject rankNameDisplay;
    public Sprite[] rankIcons;
    public Slider rankProgressDisplay;
    //total points scored
    public static int totalPointsScored = 0;

    //accuracy variables
    public static int totalShots =0;
    public static int scoredShots =0;
    public static float accuracy;

    //highest ever streak
    public static int highestStreak =0;
    public static int highestStreakShotInTheDark =0;
    public static int highestStreakMarsMission =0;

    //2 player games played
    public static int gamesPlayed =0;

    //double kerbs hit
    public static int doubleKerbsHit = 0;

    //contains the rank
    public int rank;
    public int startingRank;
    public float rankProgress;
    public int currentRankIcon;

    public bool showStats;
    public bool showRank;
    public bool attemptBallUnlock5;
    public bool attemptBallUnlock10;
    public bool attemptBallUnlock15;
    public bool attemptBallUnlock20;

    public bool Player1Game;
    public bool Player2Game;
    public bool miniGame;

    private void Awake()
    {
        rank = (totalPointsScored / 75) + 1;

        //load
        totalPointsScored = PlayerPrefs.GetInt("totalPointsScored");
        totalShots= PlayerPrefs.GetInt("totalShots");
        scoredShots = PlayerPrefs.GetInt("scoredShots");
        gamesPlayed = PlayerPrefs.GetInt("gamesPlayed");
        doubleKerbsHit = PlayerPrefs.GetInt("doubleKerbHit");

        highestStreak = PlayerPrefs.GetInt("highestStreak");
        highestStreakShotInTheDark = PlayerPrefs.GetInt("highestStreakShotInTheDark");
        highestStreakMarsMission = PlayerPrefs.GetInt("highestStreakMarsMission");
    }
    private void Start()
    {
        if (showStats)
        {
            totalPointsDisplay.GetComponent<Text>().text = ("Total Points Scored : " + totalPointsScored);
            if(totalShots > 0)
            {
                //Debug.Log(scoredShots + " scored shots");
                //Debug.Log(totalShots + " total shots");
                //Debug.Log("calculating...");
                accuracy = ((float)scoredShots / (float)totalShots) * 100;
                //Debug.Log(accuracy + "before rounding");
                accuracy = Mathf.Round(accuracy);
                //Debug.Log(accuracy + "after rounded");
                accuracyDisplay.GetComponent<Text>().text = ("Accuracy: " + accuracy + "%");
            } else if(totalShots == 0)
            {
                accuracyDisplay.GetComponent<Text>().text = ("Accuracy: N/A");
            }

            highestStreakDisplay.GetComponent<Text>().text = ("Highest Streak - Single Player: " + highestStreak);
            highestStreakDisplayShotInTheDark.GetComponent<Text>().text = ("Highest Streak - Shot In The Dark: " + highestStreakShotInTheDark);
            highestStreakDisplayMarsMission.GetComponent<Text>().text = ("Highest Streak - Mars Mission: " + highestStreakMarsMission);

            gamesPlayedDisplay.GetComponent<Text>().text = ("Two Player Games Played: " + gamesPlayed);
            doubleKerbDisplay.GetComponent<Text>().text = ("Double Kerbs hit: " + doubleKerbsHit);
        }

        if (showRank)
        {
            startingRank = rank;
            rankDisplay.GetComponent<Text>().text = ("" + rank);
            rankProgress = totalPointsScored % 75;
            rankProgressDisplay.GetComponent<Slider>().value = rankProgress;
            currentRankIcon = rank - 1;
            if (currentRankIcon > 24)
                currentRankIcon = 24;
            rankIconDisplay.GetComponent<SpriteRenderer>().sprite = rankIcons[currentRankIcon];

            if (rank >= 25)
            {
                rankNameDisplay.GetComponent<Text>().text = ("Top Tier Tosser");
            }
            else if (rank >= 20)
            {
                rankNameDisplay.GetComponent<Text>().text = ("Double point Master");
            }
            else if (rank >= 15)
            {
                rankNameDisplay.GetComponent<Text>().text = ("Expert Aimer");
            }
            else if (rank >= 10)
            {
                rankNameDisplay.GetComponent<Text>().text = ("Standard Shooter");
            }
            else if (rank >= 5 )
            {
                rankNameDisplay.GetComponent<Text>().text = ("One Point Wonder");
            }
            else
            {
                rankNameDisplay.GetComponent<Text>().text = ("Basic Baller");
            }
        }
    }

    public void AddTotalPoints(int points)
    {
        totalPointsScored += points;
        PlayerPrefs.SetInt("totalPointsScored", totalPointsScored);
        //Debug.Log("added");
    }
    public void ShotScored(bool scored)
    {
        totalShots++;
        PlayerPrefs.SetInt("totalShots", totalShots);
        if (scored)
        {
            scoredShots++;
            PlayerPrefs.SetInt("scoredShots", scoredShots);
        }
    }

    public void HighestStreakCheck(int streak, string game)
    {
        switch (game)
        {
            case "1player":
                if (streak > highestStreak)
                {
                    highestStreak = streak;
                    PlayerPrefs.SetInt("highestStreak", highestStreak);
                }
                break;
            case "ShotInTheDark":
                if (streak > highestStreakShotInTheDark)
                {
                    highestStreakShotInTheDark = streak;
                    PlayerPrefs.SetInt("highestStreakShotInTheDark", highestStreakShotInTheDark);
                }
                break;
            case "MarsMission":
                if (streak > highestStreakMarsMission)
                {
                    highestStreakMarsMission = streak;
                    PlayerPrefs.SetInt("highestStreakMarsMission", highestStreakMarsMission);
                }
                break;
        }
    }

    public void AddGamesPlayed()
    {
        gamesPlayed++;
        PlayerPrefs.SetInt("gamesPlayed", gamesPlayed);
    }

    public void DoubleKerb()
    {
        doubleKerbsHit++;
        PlayerPrefs.SetInt("doubleKerbHit", doubleKerbsHit);
    }

    public int ReturnDoubleKerb()
    {
        return doubleKerbsHit;
    }

    public int ReturnStreak(string game)
    {
        int value = 0;
        switch(game)
        {
            case "1player":
                value = highestStreak;
                break;
            case "ShotInTheDark":
                value = highestStreakShotInTheDark;
                break;
            case "MarsMission":
                value = highestStreakMarsMission;
                break;
            case "Doublekerb":
                value = doubleKerbsHit;
                break;
        }
        return value;
    }

    private void Update()
    {
        rank = (totalPointsScored / 75) + 1;
        if (showRank)
        {
            rankProgress = totalPointsScored % 75;
            rankProgressDisplay.GetComponent<Slider>().value = rankProgress;

            if (rank > startingRank)
            {
                //Debug.Log("rank up");
                if (Player1Game)
                    RankPauseScreen.GetComponent<PauseScreenScript1Player>().RankAchieved();
                if (Player2Game)
                    RankPauseScreen.GetComponent<PauseScreenScript>().RankAchieved();
                if(miniGame)
                    RankPauseScreen.GetComponent<PauseScreenScriptGoldenKerb>().RankAchieved();
                rank = (totalPointsScored / 75) + 1;
                startingRank = rank;
                rankDisplay.GetComponent<Text>().text = ("" + rank);
                currentRankIcon = rank - 1;
                if (currentRankIcon > 24)
                    currentRankIcon = 24;
                rankIconDisplay.GetComponent<SpriteRenderer>().sprite = rankIcons[currentRankIcon];
            }
        }

        if (attemptBallUnlock5)
        {
            if (rank > 4)
                GameManager.Instance.GetBallSkinsShopManager().UnlockItem("ball1");
        }
        if (attemptBallUnlock10)
        {
            if (rank > 9)
                GameManager.Instance.GetBallSkinsShopManager().UnlockItem("ball2");
        }
        if (attemptBallUnlock15)
        {
            if (rank > 14)
                GameManager.Instance.GetBallSkinsShopManager().UnlockItem("ball3");
        }
        if (attemptBallUnlock20)
        {
            if (rank > 19)
                GameManager.Instance.GetBallSkinsShopManager().UnlockItem("ball4");
        }
    }
}
