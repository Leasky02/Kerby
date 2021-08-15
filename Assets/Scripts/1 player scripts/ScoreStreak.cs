using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStreak : MonoBehaviour
{
    public GameObject streakDisplay;
    public GameObject coinDisplay;
    public int streak;
    public int multiplier;
    public string gameName;
    public bool doubleKerbGame;

    private void Start()
    {
        streak = GetComponent<Statistics>().ReturnStreak(gameName);
        if(doubleKerbGame)
            streakDisplay.GetComponent<Text>().text = "Double Kerbs Hit: " + streak;
        if (!doubleKerbGame)
            streakDisplay.GetComponent<Text>().text = "Highest Streak: " + streak;
    }

    public void StreakUpdate(int newScore, int difference)
    {
        if (newScore >= 45)
        {
            coinDisplay.GetComponent<CoinCount>().AddCoins(difference * multiplier + 4);

        }else if (newScore >= 35)
        {
            coinDisplay.GetComponent<CoinCount>().AddCoins(difference * multiplier + 3);

        }else if (newScore >= 25)
        {
            coinDisplay.GetComponent<CoinCount>().AddCoins(difference * multiplier +2);

        }else if (newScore >= 15)
        {
            coinDisplay.GetComponent<CoinCount>().AddCoins(difference * multiplier +1);

        }else if (newScore >= 5)
        {
            coinDisplay.GetComponent<CoinCount>().AddCoins(difference * multiplier);

        }

        if (newScore > streak)
        {
            streak = newScore;
            streakDisplay.GetComponent<Text>().text = "Highest Streak: " + streak;
            GetComponent<Statistics>().HighestStreakCheck(streak, gameName);
        }
    }

    public void currentStreak(int streak)
    {
        streakDisplay.GetComponent<Text>().text = "Coins Added: " + streak;
    }
}
