using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScriptMiniGames : MonoBehaviour
{
    private const int ITEM_COUNT = 6;
    
    private const int ID_INDEX = 0;
    private const int PRICE_INDEX = 1;
    private const int PUCHASED_INDEX = 2;
    private const int SHOP_ITEM_ROWS = 3;

    public static int[,] shopItems = new int[SHOP_ITEM_ROWS, ITEM_COUNT];
    public int coins;
    public Text coinsTxt;

    private static int firstLoad;

    void Awake()
    {
        firstLoad = PlayerPrefs.GetInt("firstLoadMiniGames");
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        coinsTxt.text = coins.ToString();

        //ID'S
        shopItems[ID_INDEX, 1] = 1;
        shopItems[ID_INDEX, 2] = 2;
        shopItems[ID_INDEX, 3] = 3;
        shopItems[ID_INDEX, 4] = 4;
        shopItems[ID_INDEX, 5] = 5;

        //price
        shopItems[PRICE_INDEX, 1] = 250;
        shopItems[PRICE_INDEX, 2] = 350;
        shopItems[PRICE_INDEX, 3] = 400;
        shopItems[PRICE_INDEX, 4] = 500;
        shopItems[PRICE_INDEX, 5] = 800;

        if (firstLoad == 0)
        {

            //bought status (0 = not bought, 1 = bought)
            shopItems[PUCHASED_INDEX, 1] = 0;
            shopItems[PUCHASED_INDEX, 2] = 0;
            shopItems[PUCHASED_INDEX, 3] = 0;
            shopItems[PUCHASED_INDEX, 4] = 0;
            shopItems[PUCHASED_INDEX, 5] = 0;

            firstLoad = 1;
            PlayerPrefs.SetInt("firstLoadMiniGames", firstLoad);
        }

        LoadFromPlayerPrefs();
    }

    public void BuyWithCoins(GameObject ButtonRef)
    {
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        int buttonMiniGameID = ButtonRef.GetComponent<ButtonInfoMiniGames>().itemID;
        if (coins >= shopItems[PRICE_INDEX, buttonMiniGameID])
        {
            coins -= shopItems[PRICE_INDEX, buttonMiniGameID];
            ButtonRef.GetComponent<Button>().interactable = false;
            coinsTxt.GetComponent<CoinCount>().SubtractCoins(shopItems[PRICE_INDEX, buttonMiniGameID]);
            GetComponent<AudioSource>().Play();
            UnlockItem(buttonMiniGameID);
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

    public int GetPrice(int ID)
    {
        return shopItems[PRICE_INDEX, ID];
    }

    private void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetInt("miniGames1", shopItems[PUCHASED_INDEX, 1]);
        PlayerPrefs.SetInt("miniGames2", shopItems[PUCHASED_INDEX, 2]);
        PlayerPrefs.SetInt("miniGames3", shopItems[PUCHASED_INDEX, 3]);
        PlayerPrefs.SetInt("miniGames4", shopItems[PUCHASED_INDEX, 4]);
        PlayerPrefs.SetInt("miniGames5", shopItems[PUCHASED_INDEX, 5]);
    }

    private void LoadFromPlayerPrefs()
    {
        shopItems[PUCHASED_INDEX, 1] = PlayerPrefs.GetInt("miniGames1");
        shopItems[PUCHASED_INDEX, 2] = PlayerPrefs.GetInt("miniGames2");
        shopItems[PUCHASED_INDEX, 3] = PlayerPrefs.GetInt("miniGames3");
        shopItems[PUCHASED_INDEX, 4] = PlayerPrefs.GetInt("miniGames4");
        shopItems[PUCHASED_INDEX, 5] = PlayerPrefs.GetInt("miniGames5");
    }
}
