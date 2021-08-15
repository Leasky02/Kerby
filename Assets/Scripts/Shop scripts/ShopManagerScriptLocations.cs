using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScriptLocations : MonoBehaviour
{
    public static int[,] shopItems = new int[5, 7];
    public int coins;
    public Text coinsTxt;
    private static int firstLoad;


    void Awake()
    {
        firstLoad = PlayerPrefs.GetInt("firstLoadLocations");
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        coinsTxt.text = coins.ToString();

        //ID'S
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;

        //default new york
        shopItems[1, 6] = 6;


        //price
        shopItems[2, 1] = 300;
        shopItems[2, 2] = 350;
        shopItems[2, 3] = 400;
        shopItems[2, 4] = 450;
        shopItems[2, 5] = 500;

        if (firstLoad == 0)
        {

            //price
            shopItems[2, 1] = 300;
            shopItems[2, 2] = 350;
            shopItems[2, 3] = 400;
            shopItems[2, 4] = 450;
            shopItems[2, 5] = 500;


            //bought status (0 = not bought, 1 = bought)

            shopItems[3, 1] = 0;
            shopItems[3, 2] = 0;
            shopItems[3, 3] = 0;
            shopItems[3, 4] = 0;
            shopItems[3, 5] = 0;


            firstLoad = 1;
            PlayerPrefs.SetInt("firstLoadLocations", firstLoad);

            //active sprite status ( 1 = active)

            shopItems[4, 1] = 0;
            shopItems[4, 2] = 0;
            shopItems[4, 3] = 0;
            shopItems[4, 4] = 0;
            shopItems[4, 5] = 0;

            //default new york...
            shopItems[4, 6] = 1;

        }

        //default has been bought
        shopItems[3, 6] = 1;
        PlayerPrefs.SetInt("background6", shopItems[3, 6]);


        //items bought? default 0 = not bought
        shopItems[3, 1] = PlayerPrefs.GetInt("background1");
        shopItems[3, 2] = PlayerPrefs.GetInt("background2");
        shopItems[3, 3] = PlayerPrefs.GetInt("background3");
        shopItems[3, 4] = PlayerPrefs.GetInt("background4");
        shopItems[3, 5] = PlayerPrefs.GetInt("background5");
        shopItems[3, 6] = PlayerPrefs.GetInt("background6");
    }

    public void BuyWithCoins(GameObject ButtonRef)
    {
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfoLocations>().itemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfoLocations>().itemID];
            ButtonRef.GetComponent<Button>().interactable = false;
            coinsTxt.GetComponent<CoinCount>().SubtractCoins(shopItems[2, ButtonRef.GetComponent<ButtonInfoLocations>().itemID]);
            GetComponent<AudioSource>().Play();
            shopItems[3, ButtonRef.GetComponent<ButtonInfoLocations>().itemID] = 1;

            //save
            PlayerPrefs.SetInt("background1", shopItems[3, 1]);
            PlayerPrefs.SetInt("background2", shopItems[3, 2]);
            PlayerPrefs.SetInt("background3", shopItems[3, 3]);
            PlayerPrefs.SetInt("background4", shopItems[3, 4]);
            PlayerPrefs.SetInt("background5", shopItems[3, 5]);
            PlayerPrefs.SetInt("background6", shopItems[3, 6]);
        }
    }

    public void BuyWithRank(GameObject ButtonRef)
    {
        int rank = coinsTxt.GetComponent<Statistics>().rank;
        if (rank >= ButtonRef.GetComponent<ButtonInfoLocations>().requiredRank)
        {
            shopItems[3, ButtonRef.GetComponent<ButtonInfoLocations>().itemID] = 1;
            ButtonRef.GetComponent<Button>().interactable = false;

            //save
            PlayerPrefs.SetInt("background1", shopItems[3, 1]);
            PlayerPrefs.SetInt("background2", shopItems[3, 2]);
            PlayerPrefs.SetInt("background3", shopItems[3, 3]);
            PlayerPrefs.SetInt("background4", shopItems[3, 4]);
            PlayerPrefs.SetInt("background5", shopItems[3, 5]);
            PlayerPrefs.SetInt("background6", shopItems[3, 6]);
        }
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
        if(shopItems[3, ButtonRef.GetComponent<ButtonInfoLocationsSetup>().itemID] == 1)
        {
            shopItems[4, 1] = 0;
            shopItems[4, 2] = 0;
            shopItems[4, 3] = 0;
            shopItems[4, 4] = 0;
            shopItems[4, 5] = 0;
            shopItems[4, 6] = 0;

            shopItems[4, ButtonRef.GetComponent<ButtonInfoLocationsSetup>().itemID] = 1;
        }
    }
}
