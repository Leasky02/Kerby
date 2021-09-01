using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public static int[,] shopItems = new int[5, 12];
    public int coins;
    public Text coinsTxt;
    private static int firstLoad = 0;

    void Awake()
    {
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        coinsTxt.text = coins.ToString();

        //ID'S
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;
        shopItems[1, 6] = 6;
        shopItems[1, 7] = 7;
        shopItems[1, 8] = 8;
        shopItems[1, 9] = 9;
        shopItems[1, 10] = 10;

        //original ball
        shopItems[1, 11] = 11;

        //price
        shopItems[2, 1] = 5;
        shopItems[2, 2] = 10;
        shopItems[2, 3] = 15;
        shopItems[2, 4] = 20;
        shopItems[2, 5] = 50;
        shopItems[2, 6] = 50;
        shopItems[2, 7] = 150;
        shopItems[2, 8] = 150;
        shopItems[2, 9] = 150;
        shopItems[2, 10] = 150;

        if (firstLoad == 0)
        {
            firstLoad = 1;

            //active sprite status ( 1 = active)

            shopItems[4, 1] = 0;
            shopItems[4, 2] = 0;
            shopItems[4, 3] = 0;
            shopItems[4, 4] = 0;
            shopItems[4, 5] = 0;
            shopItems[4, 6] = 0;
            shopItems[4, 7] = 0;
            shopItems[4, 8] = 0;
            shopItems[4, 9] = 0;
            shopItems[4, 10] = 0;

            //default ball
            shopItems[4, 11] = 1;
        }


        //default ball has been bought
        shopItems[3, 11] = 1;
        PlayerPrefs.SetInt("ball11", shopItems[3, 11]);

        //items bought? default 0 = not bought
        shopItems[3, 1] = PlayerPrefs.GetInt("ball1");
        shopItems[3, 2] = PlayerPrefs.GetInt("ball2");
        shopItems[3, 3] = PlayerPrefs.GetInt("ball3");
        shopItems[3, 4] = PlayerPrefs.GetInt("ball4");
        shopItems[3, 5] = PlayerPrefs.GetInt("ball5");
        shopItems[3, 6] = PlayerPrefs.GetInt("ball6");
        shopItems[3, 7] = PlayerPrefs.GetInt("ball7");
        shopItems[3, 8] = PlayerPrefs.GetInt("ball8");
        shopItems[3, 9] = PlayerPrefs.GetInt("ball9");
        shopItems[3, 10] = PlayerPrefs.GetInt("ball10");

    }

    public void BuyWithCoins(GameObject ButtonRef)
    {
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            ButtonRef.GetComponent<Button>().interactable = false;
            coinsTxt.GetComponent<CoinCount>().SubtractCoins(shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID]);
            GetComponent<AudioSource>().Play();
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().itemID] = 1;

            //save
            PlayerPrefs.SetInt("ball1", shopItems[3,1]);
            PlayerPrefs.SetInt("ball2", shopItems[3,2]);
            PlayerPrefs.SetInt("ball3", shopItems[3,3]);
            PlayerPrefs.SetInt("ball4", shopItems[3,4]);
            PlayerPrefs.SetInt("ball5", shopItems[3,5]);
            PlayerPrefs.SetInt("ball6", shopItems[3,6]);
            PlayerPrefs.SetInt("ball7", shopItems[3,7]);
            PlayerPrefs.SetInt("ball8", shopItems[3,8]);
            PlayerPrefs.SetInt("ball9", shopItems[3,9]);
            PlayerPrefs.SetInt("ball10", shopItems[3,10]);
            PlayerPrefs.SetInt("ball11", shopItems[3,11]);
        }
    }

    public void BuyWithRank(int ID)
    {
        int rank = coinsTxt.GetComponent<Statistics>().rank;

            shopItems[3, ID] = 1;

        //save
        PlayerPrefs.SetInt("ball1", shopItems[3, 1]);
        PlayerPrefs.SetInt("ball2", shopItems[3, 2]);
        PlayerPrefs.SetInt("ball3", shopItems[3, 3]);
        PlayerPrefs.SetInt("ball4", shopItems[3, 4]);
        PlayerPrefs.SetInt("ball5", shopItems[3, 5]);
        PlayerPrefs.SetInt("ball6", shopItems[3, 6]);
        PlayerPrefs.SetInt("ball7", shopItems[3, 8]);
        PlayerPrefs.SetInt("ball8", shopItems[3, 9]);
        PlayerPrefs.SetInt("ball9", shopItems[3, 0]);
        PlayerPrefs.SetInt("ball10", shopItems[3, 10]);
        PlayerPrefs.SetInt("ball11", shopItems[3, 11]);
    }

    public int GetItemAvailability(int ID)
    {
        //Debug.Log(shopItems[3, ID]);
        return shopItems[3, ID];
    }

    public int IsSelected(int ID)
    {
        //Debug.Log(shopItems[3, ID]);
        return shopItems[4, ID];
    }

    public int GetPrice(int ID)
    {
        //Debug.Log(shopItems[3, ID]);
        return shopItems[2, ID];
    }

    public void SetActive(GameObject ButtonRef)
    {
        if (shopItems[3, ButtonRef.GetComponent<ButtonInfoSetup>().itemID] == 1)
        {
            shopItems[4, 1] = 0;
            shopItems[4, 2] = 0;
            shopItems[4, 3] = 0;
            shopItems[4, 4] = 0;
            shopItems[4, 5] = 0;
            shopItems[4, 6] = 0;
            shopItems[4, 7] = 0;
            shopItems[4, 8] = 0;
            shopItems[4, 9] = 0;
            shopItems[4, 10] = 0;
            shopItems[4, 11] = 0;

            shopItems[4, ButtonRef.GetComponent<ButtonInfoSetup>().itemID] = 1;
        }
    }
}
