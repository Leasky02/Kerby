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
        totalCoins = LoadPlayerPrefsCoins();

        if (displayCoins)
            UpdateCoinDisplay();
    }

    public void UpdateCoinDisplay()
    {
        GetComponent<Text>().text = totalCoins.ToString();
    }

    public int AddCoins(int coinCount)
    {
        totalCoins += coinCount;
        UpdateCoinDisplay();
        SavePlayerPrefsCoins(totalCoins);
        GetComponent<AudioSource>().Play();
        var psMain = ps.GetComponent<ParticleSystem>().main;
        psMain.maxParticles = coinCount;
        ps.Play();
        return totalCoins;
    }

    public int SubtractCoins(int coinCount)
    {
        totalCoins -= coinCount;
        UpdateCoinDisplay();
        SavePlayerPrefsCoins(totalCoins);
        return totalCoins;
    }

    public int GetCoins()
    {
        return totalCoins;
    }

    public void AddToJackpot(int coins)
    {
        jackpotTotal += coins;
        GetComponent<AudioSource>().Play();
        var psMain = ps.GetComponent<ParticleSystem>().main;
        psMain.maxParticles = Mathf.Min(coins, 15);
        ps.Play();
    }

    public void ResetJackpot()
    {
        jackpotTotal = 0;
    }

    public void CompleteJackpot()
    {
        totalCoins += jackpotTotal;
        UpdateCoinDisplay();
        SavePlayerPrefsCoins(totalCoins);
        Debug.Log(jackpotTotal);
        AdsManager.GetComponent<AdsManagerScript>().AddCounterDuringGame();
        GetComponent<ScoreStreak>().currentStreak(0);
        Ball.GetComponent<BallCollisionsGoldenKerb>().ResetStreak();
        jackpotTotal = 0;
        currentStreak.GetComponent<Text>().text = "Jackpot: " + jackpotTotal;
        jackpotAudio.GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        if (inGame)
        {
            claimButton.GetComponent<Button>().interactable = (jackpotTotal > 0);
        }
    }

    private int LoadPlayerPrefsCoins()
    {
        return PlayerPrefs.GetInt("coins");
    }

    private void SavePlayerPrefsCoins(int coins)
    {
        PlayerPrefs.SetInt("coins", coins);
    }

}