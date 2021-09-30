using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    private const int ITEM_COUNT = 12;

    private const int ID_INDEX = 0;
    private const int PRICE_INDEX = 1;
    private const int PUCHASED_INDEX = 2;
    private const int ACTIVE_INDEX = 3;
    private const int SHOP_ITEM_ROWS = 4;

    public static int[,] shopItems = new int[SHOP_ITEM_ROWS, ITEM_COUNT];
    public int coins;
    public Text coinsTxt;

    private static int firstLoad = 0;

    void Awake()
    {
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        coinsTxt.text = coins.ToString();

        //ID'S
        shopItems[ID_INDEX, 1] = 1;
        shopItems[ID_INDEX, 2] = 2;
        shopItems[ID_INDEX, 3] = 3;
        shopItems[ID_INDEX, 4] = 4;
        shopItems[ID_INDEX, 5] = 5;
        shopItems[ID_INDEX, 6] = 6;
        shopItems[ID_INDEX, 7] = 7;
        shopItems[ID_INDEX, 8] = 8;
        shopItems[ID_INDEX, 9] = 9;
        shopItems[ID_INDEX, 10] = 10;

        //original ball
        shopItems[ID_INDEX, 11] = 11;

        //price
        shopItems[PRICE_INDEX, 1] = 5;
        shopItems[PRICE_INDEX, 2] = 10;
        shopItems[PRICE_INDEX, 3] = 15;
        shopItems[PRICE_INDEX, 4] = 20;
        shopItems[PRICE_INDEX, 5] = 50;
        shopItems[PRICE_INDEX, 6] = 50;
        shopItems[PRICE_INDEX, 7] = 150;
        shopItems[PRICE_INDEX, 8] = 150;
        shopItems[PRICE_INDEX, 9] = 150;
        shopItems[PRICE_INDEX, 10] = 150;

        if (firstLoad == 0)
        {
            firstLoad = 1;

            //active sprite status (1 = active)
            shopItems[ACTIVE_INDEX, 1] = 0;
            shopItems[ACTIVE_INDEX, 2] = 0;
            shopItems[ACTIVE_INDEX, 3] = 0;
            shopItems[ACTIVE_INDEX, 4] = 0;
            shopItems[ACTIVE_INDEX, 5] = 0;
            shopItems[ACTIVE_INDEX, 6] = 0;
            shopItems[ACTIVE_INDEX, 7] = 0;
            shopItems[ACTIVE_INDEX, 8] = 0;
            shopItems[ACTIVE_INDEX, 9] = 0;
            shopItems[ACTIVE_INDEX, 10] = 0;

            //default ball
            shopItems[ACTIVE_INDEX, 11] = 1;
        }


        //default ball has been bought
        shopItems[PUCHASED_INDEX, 11] = 1;
        PlayerPrefs.SetInt("ball11", shopItems[PUCHASED_INDEX, 11]);

        LoadFromPlayerPrefs();
    }

    public void BuyWithCoins(GameObject ButtonRef)
    {
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        int buttonBallSkinID = ButtonRef.GetComponent<ButtonInfo>().itemID;
        if (coins >= shopItems[PRICE_INDEX, buttonBallSkinID])
        {
            coins -= shopItems[PRICE_INDEX, buttonBallSkinID];
            ButtonRef.GetComponent<Button>().interactable = false;
            coinsTxt.GetComponent<CoinCount>().SubtractCoins(shopItems[PRICE_INDEX, buttonBallSkinID]);
            GetComponent<AudioSource>().Play();
            UnlockItem(buttonBallSkinID);
        }
    }

    public void UnlockItem(int ID)
    {
        shopItems[PUCHASED_INDEX, ID] = 1;
        SaveToPlayerPrefs();
    }

    public bool IsItemAvailable(int ID)
    {
        return shopItems[PUCHASED_INDEX, ID] == 1;
    }

    public bool IsSelected(int ID)
    {
        return shopItems[ACTIVE_INDEX, ID] == 1;
    }

    public int GetPrice(int ID)
    {
        return shopItems[PRICE_INDEX, ID];
    }

    public void SetActive(GameObject ButtonRef)
    {
        int ballSkinID = ButtonRef.GetComponent<ButtonInfoSetup>().itemID;
        if (IsItemAvailable(ballSkinID))
        {
            for (int ID = 0; ID < ITEM_COUNT; ++ID)
            {
                shopItems[ACTIVE_INDEX, ID] = 0;
            }
            shopItems[ACTIVE_INDEX, ballSkinID] = 1;
        }
    }

    public int GetSelectedBallID()
    {
        for (int ID = 0; ID < ITEM_COUNT; ++ID)
        {
            if (IsSelected(ID))
            {
                return ID;
            }
        }
        return 0;
    }

    private void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetInt("ball1", shopItems[PUCHASED_INDEX, 1]);
        PlayerPrefs.SetInt("ball2", shopItems[PUCHASED_INDEX, 2]);
        PlayerPrefs.SetInt("ball3", shopItems[PUCHASED_INDEX, 3]);
        PlayerPrefs.SetInt("ball4", shopItems[PUCHASED_INDEX, 4]);
        PlayerPrefs.SetInt("ball5", shopItems[PUCHASED_INDEX, 5]);
        PlayerPrefs.SetInt("ball6", shopItems[PUCHASED_INDEX, 6]);
        PlayerPrefs.SetInt("ball7", shopItems[PUCHASED_INDEX, 7]);
        PlayerPrefs.SetInt("ball8", shopItems[PUCHASED_INDEX, 8]);
        PlayerPrefs.SetInt("ball9", shopItems[PUCHASED_INDEX, 9]);
        PlayerPrefs.SetInt("ball10", shopItems[PUCHASED_INDEX, 10]);
        PlayerPrefs.SetInt("ball11", shopItems[PUCHASED_INDEX, 11]);
    }

    private void LoadFromPlayerPrefs()
    {
        shopItems[PUCHASED_INDEX, 1] = PlayerPrefs.GetInt("ball1");
        shopItems[PUCHASED_INDEX, 2] = PlayerPrefs.GetInt("ball2");
        shopItems[PUCHASED_INDEX, 3] = PlayerPrefs.GetInt("ball3");
        shopItems[PUCHASED_INDEX, 4] = PlayerPrefs.GetInt("ball4");
        shopItems[PUCHASED_INDEX, 5] = PlayerPrefs.GetInt("ball5");
        shopItems[PUCHASED_INDEX, 6] = PlayerPrefs.GetInt("ball6");
        shopItems[PUCHASED_INDEX, 7] = PlayerPrefs.GetInt("ball7");
        shopItems[PUCHASED_INDEX, 8] = PlayerPrefs.GetInt("ball8");
        shopItems[PUCHASED_INDEX, 9] = PlayerPrefs.GetInt("ball9");
        shopItems[PUCHASED_INDEX, 10] = PlayerPrefs.GetInt("ball10");
    }
}
