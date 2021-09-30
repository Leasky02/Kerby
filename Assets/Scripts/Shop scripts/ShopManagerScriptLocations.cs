using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScriptLocations : MonoBehaviour
{
    private const int ITEM_COUNT = 7;

    public static int[,] shopItems = new int[5, ITEM_COUNT];
    public int coins;
    public Text coinsTxt;

    private Sprite[] backgroundSprites = new Sprite[ITEM_COUNT];
    private Color[] skyColors = new Color[ITEM_COUNT];

    private static int firstLoad = 0;

    private const int ID_INDEX = 1;
    private const int PRICE_INDEX = 2;
    private const int PUCHASED_INDEX = 3;
    private const int ACTIVE_INDEX = 4;

    void Awake()
    {
        backgroundSprites[0] = Resources.Load<Sprite>("Sprites/Backgrounds/Standard/NewYork");      // New York (Default)
        backgroundSprites[1] = Resources.Load<Sprite>("Sprites/Backgrounds/Standard/Desert");       // Desert
        backgroundSprites[2] = Resources.Load<Sprite>("Sprites/Backgrounds/Standard/LochNess");     // Loch Ness
        backgroundSprites[3] = Resources.Load<Sprite>("Sprites/Backgrounds/Standard/Suburbs");      // Suburbs
        backgroundSprites[4] = Resources.Load<Sprite>("Sprites/Backgrounds/Standard/Himalayas");    // Himalayas
        backgroundSprites[5] = Resources.Load<Sprite>("Sprites/Backgrounds/Standard/Rainforest");   // Rainforest
        backgroundSprites[6] = Resources.Load<Sprite>("Sprites/Backgrounds/Standard/NewYork");      // New York

        skyColors[0] = new Color(0.631f, 0.611f, 0.827f);  // New York (Default)
        skyColors[1] = new Color(0.894f, 0.447f, 0.156f);  // Desert
        skyColors[2] = new Color(0.568f, 0.866f, 0.882f);  // Loch Ness
        skyColors[3] = new Color(0.862f, 0.741f, 0.741f);  // Suburbs
        skyColors[4] = new Color(0.592f, 0.768f, 0.803f);  // Himalayas
        skyColors[5] = new Color(0.647f, 0.878f, 0.658f);  // Rainforest
        skyColors[6] = new Color(0.631f, 0.611f, 0.827f);  // New York

        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        coinsTxt.text = coins.ToString();

        //ID'S
        shopItems[ID_INDEX, 1] = 1;
        shopItems[ID_INDEX, 2] = 2;
        shopItems[ID_INDEX, 3] = 3;
        shopItems[ID_INDEX, 4] = 4;
        shopItems[ID_INDEX, 5] = 5;

        //default new york
        shopItems[ID_INDEX, 6] = 6;


        //price
        shopItems[PRICE_INDEX, 1] = 300;
        shopItems[PRICE_INDEX, 2] = 350;
        shopItems[PRICE_INDEX, 3] = 400;
        shopItems[PRICE_INDEX, 4] = 450;
        shopItems[PRICE_INDEX, 5] = 500;

        if (firstLoad == 0)
        {
            firstLoad = 1;

            //active sprite status (1 = active)
            shopItems[ACTIVE_INDEX, 1] = 0;
            shopItems[ACTIVE_INDEX, 2] = 0;
            shopItems[ACTIVE_INDEX, 3] = 0;
            shopItems[ACTIVE_INDEX, 4] = 0;
            shopItems[ACTIVE_INDEX, 5] = 0;

            //default new york...
            shopItems[ACTIVE_INDEX, 6] = 1;
        }

        //default has been bought
        shopItems[PUCHASED_INDEX, 6] = 1;
        PlayerPrefs.SetInt("background6", shopItems[PUCHASED_INDEX, 6]);


        //items bought? default 0 = not bought
        shopItems[PUCHASED_INDEX, 1] = PlayerPrefs.GetInt("background1");
        shopItems[PUCHASED_INDEX, 2] = PlayerPrefs.GetInt("background2");
        shopItems[PUCHASED_INDEX, 3] = PlayerPrefs.GetInt("background3");
        shopItems[PUCHASED_INDEX, 4] = PlayerPrefs.GetInt("background4");
        shopItems[PUCHASED_INDEX, 5] = PlayerPrefs.GetInt("background5");
        shopItems[PUCHASED_INDEX, 6] = PlayerPrefs.GetInt("background6");
    }

    public void BuyWithCoins(GameObject ButtonRef)
    {
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        int buttonLocationID = ButtonRef.GetComponent<ButtonInfoLocations>().itemID;
        if (coins >= shopItems[PRICE_INDEX, buttonLocationID])
        {
            coins -= shopItems[PRICE_INDEX, buttonLocationID];
            ButtonRef.GetComponent<Button>().interactable = false;
            coinsTxt.GetComponent<CoinCount>().SubtractCoins(shopItems[PRICE_INDEX, buttonLocationID]);
            GetComponent<AudioSource>().Play();
            shopItems[PUCHASED_INDEX, buttonLocationID] = 1;

            SaveToPlayerPrefs();
        }
    }

    public void BuyWithRank(GameObject ButtonRef)
    {
        int rank = coinsTxt.GetComponent<Statistics>().rank;
        if (rank >= ButtonRef.GetComponent<ButtonInfoLocations>().requiredRank)
        {
            shopItems[PUCHASED_INDEX, ButtonRef.GetComponent<ButtonInfoLocations>().itemID] = 1;
            ButtonRef.GetComponent<Button>().interactable = false;

            SaveToPlayerPrefs();
        }
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
        int locationID = ButtonRef.GetComponent<ButtonInfoLocationsSetup>().itemID;
        if (IsItemAvailable(locationID))
        {
            for (int ID = 0; ID < ITEM_COUNT; ++ID)
            {
                shopItems[ACTIVE_INDEX, ID] = 0;
            }
            shopItems[ACTIVE_INDEX, locationID] = 1;
        }
    }

    private Color GetSkyColorForLocation(int locationID)
    {
        return skyColors[locationID];
    }

    private Sprite GetBackgroundSpriteForLocation(int locationID)
    {
        return backgroundSprites[locationID];
    }

    public int GetSelectedLocationID()
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
    
    public Color GetSkyColorForSelectedLocation()
    {
        return skyColors[GetSelectedLocationID()];
    }

    public Sprite GetBackgroundSpriteForSelectedLocation()
    {
        return backgroundSprites[GetSelectedLocationID()];
    }

    private void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetInt("background1", shopItems[PUCHASED_INDEX, 1]);
        PlayerPrefs.SetInt("background2", shopItems[PUCHASED_INDEX, 2]);
        PlayerPrefs.SetInt("background3", shopItems[PUCHASED_INDEX, 3]);
        PlayerPrefs.SetInt("background4", shopItems[PUCHASED_INDEX, 4]);
        PlayerPrefs.SetInt("background5", shopItems[PUCHASED_INDEX, 5]);
        PlayerPrefs.SetInt("background6", shopItems[PUCHASED_INDEX, 6]);
    }
}
