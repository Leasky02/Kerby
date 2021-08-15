using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfoMiniGames : MonoBehaviour
{
    public int itemID;
    public Text priceTxt;
    public GameObject shopManager;
    public int requiredRank;
    public GameObject coins;
    public int rank;

    void Start()
    {
        rank = GetComponent<Statistics>().rank;
        var newColorBlock = GetComponent<Button>().colors;
        if (shopManager.GetComponent<ShopManagerScriptMiniGames>().GetItemAvailability(itemID) == 1)
        {
            newColorBlock.disabledColor = new Color(121f / 255f, 121f / 255f, 121f / 255f, 1f);
            GetComponent<Button>().colors = newColorBlock;
            GetComponent<Button>().interactable = false;
        }
        else if (rank < requiredRank || coins.GetComponent<CoinCount>().GetCoins() < shopManager.GetComponent<ShopManagerScriptMiniGames>().GetPrice(itemID))
        {
            if(shopManager.GetComponent<ShopManagerScriptMiniGames>().GetItemAvailability(itemID) == 0)
            {
                newColorBlock.disabledColor = new Color(194f / 255f, 12f / 255f, 12f / 255f, 0.5f);
                GetComponent<Button>().colors = newColorBlock;
                GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    private void Update()
    {
        var newColorBlock = GetComponent<Button>().colors;
        if (coins.GetComponent<CoinCount>().GetCoins() < shopManager.GetComponent<ShopManagerScriptMiniGames>().GetPrice(itemID))
        {
            if (shopManager.GetComponent<ShopManagerScriptMiniGames>().GetItemAvailability(itemID) == 0)
            {
                newColorBlock.disabledColor = new Color(194f / 255f, 12f / 255f, 12f / 255f, 0.5f);
                GetComponent<Button>().colors = newColorBlock;
                GetComponent<Button>().interactable = false;
            }
        }
    }
}
