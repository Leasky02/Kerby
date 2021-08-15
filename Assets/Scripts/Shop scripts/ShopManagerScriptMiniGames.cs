using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScriptMiniGames : MonoBehaviour
{
    public static int[,] shopItems = new int[5, 6];
    public int coins;
    public Text coinsTxt;
    private static int firstLoad;


    void Awake()
    {
        firstLoad = PlayerPrefs.GetInt("firstLoadMiniGames");
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        coinsTxt.text = coins.ToString();

        //ID'S
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;

        //price
        shopItems[2, 1] = 250;
        shopItems[2, 2] = 350;
        shopItems[2, 3] = 400;
        shopItems[2, 4] = 500;
        shopItems[2, 5] = 800;

        if (firstLoad == 0)
        {

            //bought status (0 = not bought, 1 = bought)

            shopItems[3, 1] = 0;
            shopItems[3, 2] = 0;
            shopItems[3, 3] = 0;
            shopItems[3, 4] = 0;
            shopItems[3, 5] = 0;

            firstLoad = 1;
            PlayerPrefs.SetInt("firstLoadMiniGames", firstLoad);
        }

        shopItems[3, 1] = PlayerPrefs.GetInt("miniGames1");
        shopItems[3, 2] = PlayerPrefs.GetInt("miniGames2");
        shopItems[3, 3] = PlayerPrefs.GetInt("miniGames3");
        shopItems[3, 4] = PlayerPrefs.GetInt("miniGames4");
        shopItems[3, 5] = PlayerPrefs.GetInt("miniGames5");
    }

    public void BuyWithCoins(GameObject ButtonRef)
    {
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfoMiniGames>().itemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfoMiniGames>().itemID];
            ButtonRef.GetComponent<Button>().interactable = false;
            coinsTxt.GetComponent<CoinCount>().SubtractCoins(shopItems[2, ButtonRef.GetComponent<ButtonInfoMiniGames>().itemID]);
            GetComponent<AudioSource>().Play();
            shopItems[3, ButtonRef.GetComponent<ButtonInfoMiniGames>().itemID] = 1;

            //save
            PlayerPrefs.SetInt("miniGames1", shopItems[3, 1]);
            PlayerPrefs.SetInt("miniGames2", shopItems[3, 2]);
            PlayerPrefs.SetInt("miniGames3", shopItems[3, 3]);
            PlayerPrefs.SetInt("miniGames4", shopItems[3, 4]);
            PlayerPrefs.SetInt("miniGames5", shopItems[3, 5]);
        }
    }

    public void BuyWithRank(GameObject ButtonRef)
    {
        int rank = coinsTxt.GetComponent<Statistics>().rank;
        if (rank >= ButtonRef.GetComponent<ButtonInfoMiniGames>().requiredRank)
        {
            ButtonRef.GetComponent<Button>().interactable = false;
            shopItems[3, ButtonRef.GetComponent<ButtonInfoMiniGames>().itemID] = 1;

            //save
            PlayerPrefs.SetInt("miniGames1", shopItems[3, 1]);
            PlayerPrefs.SetInt("miniGames2", shopItems[3, 2]);
            PlayerPrefs.SetInt("miniGames3", shopItems[3, 3]);
            PlayerPrefs.SetInt("miniGames4", shopItems[3, 4]);
            PlayerPrefs.SetInt("miniGames5", shopItems[3, 5]);
        }
    }

    public int GetItemAvailability(int ID)
    {
        //Debug.Log(shopItems[3, ID]);
        return shopItems[3, ID];
    }

    public int GetPrice(int ID)
    {
        //Debug.Log(shopItems[3, ID]);
        return shopItems[2, ID];
    }
}
