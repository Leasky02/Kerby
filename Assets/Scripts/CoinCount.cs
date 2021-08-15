using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinCount : MonoBehaviour
{
    public static int totalCoins;
    public ParticleSystem ps;
    public int jackpotTotal;
    public bool displayCoins;
    public GameObject AdsManager;
    public GameObject currentStreak;
    public GameObject claimButton;
    public GameObject Ball;
    public GameObject jackpotAudio;
    public bool inGame;

    public void Awake()
    {
        jackpotTotal = 0;
        totalCoins = PlayerPrefs.GetInt("coins");

        if(displayCoins)
            DisplayCoins();
    }

    public void DisplayCoins()
    {
        GetComponent<Text>().text = ("" + totalCoins);
    }

    public void AddCoins(int coinCount)
    {
        totalCoins += coinCount;
        DisplayCoins();
        GetComponent<AudioSource>().Play();
        ps.GetComponent<ParticleSystem>().maxParticles = coinCount;
        ps.Play();
        PlayerPrefs.SetInt("coins", totalCoins);
    }

    public void AddCoinsCheat(int coinCount)
    {
        totalCoins += coinCount;
        DisplayCoins();
        PlayerPrefs.SetInt("coins", totalCoins);
    }

    public void SubtractCoins(int coinCount)
    {
        totalCoins -= coinCount;
        DisplayCoins();
        PlayerPrefs.SetInt("coins", totalCoins);
    }

    public int GetCoins()
    {
        return totalCoins;
    }

    public void AddToJackpot(int coins)
    {
        jackpotTotal += coins;
        GetComponent<AudioSource>().Play();
        ps.GetComponent<ParticleSystem>().maxParticles = coins;
        if (ps.GetComponent<ParticleSystem>().maxParticles > 15)
            ps.GetComponent<ParticleSystem>().maxParticles = 15;
        ps.Play();
    }

    public void ResetJackpot()
    {
        jackpotTotal = 0;
    }

    public void CompleteJackpot()
    {
        totalCoins += jackpotTotal;
        DisplayCoins();
        PlayerPrefs.SetInt("coins", totalCoins);
        Debug.Log(jackpotTotal);
        //Debug.Log("played");
        AdsManager.GetComponent<AdsManagerScript>().AddCounterDuringGame();
        GetComponent<ScoreStreak>().currentStreak(0);
        Ball.GetComponent<BallCollisionsGoldenKerb>().ResetStreak();
        //Debug.Log("claimed");
        jackpotTotal = 0;
        currentStreak.GetComponent<Text>().text = "Jackpot: " + jackpotTotal;
        jackpotAudio.GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        if(inGame)
        {
            if (jackpotTotal > 0)
                claimButton.GetComponent<Button>().interactable = true;
            if (jackpotTotal == 0)
                claimButton.GetComponent<Button>().interactable = false;
        }
    }

}