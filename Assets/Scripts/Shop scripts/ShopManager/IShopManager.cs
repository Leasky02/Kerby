using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IShopManager : MonoBehaviour
{
    [SerializeField]
    private Text coinsTxt;
    
    private int coins;

    private static Dictionary<string, ShopItem> shopItemsDict = new Dictionary<string, ShopItem>();
    
    private static Dictionary<string, bool> shopItemsPurchasedDict = new Dictionary<string, bool>();

    private static int firstLoad;

    private string playerPrefsPrefix;

    void Awake()
    {
        firstLoad = PlayerPrefs.GetInt("firstLoadMiniGames");
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        coinsTxt.text = coins.ToString();
    }

    protected void AddShopItem(ShopItem item)
    {
        shopItemsDict.Add(item.key, item);
        shopItemsPurchasedDict.Add(item.key, GetFromPlayerPrefsIsItemPurchased(item.key));
    }

    public bool CanBuyWithCoins(string key)
    {
        // Have we purchased the item already?
        if (IsItemAvailable(key))
            return false;
        
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        ShopItem item;
        return shopItemsDict.TryGetValue(key, out item) ? (coins >= item.price) : false;
    }
    
    public bool TryBuyWithCoins(string key)
    {
        // Have we purchased the item already?
        if (IsItemAvailable(key))
            return false;
        
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        ShopItem item;
        if (shopItemsDict.TryGetValue(key, out item))
        {
            if (coins >= item.price)
            {
                coins = coinsTxt.GetComponent<CoinCount>().SubtractCoins(item.price);
                GetComponent<AudioSource>().Play();
                UnlockItem(key);
                return true;
            }
        }
        return false;
    }

    public void UnlockItem(string key)
    {
        bool purchased = true;
        if (shopItemsPurchasedDict.ContainsKey(key))
        {
            shopItemsPurchasedDict[key] = purchased;
            SaveToPlayerPrefsIsItemPurchased(key, purchased);
        }
    }

    public bool IsItemAvailable(string key)
    {
        bool itemPurchased;
        return shopItemsPurchasedDict.TryGetValue(key, out itemPurchased) ? itemPurchased : false;
    }

    public List<ShopItem> GetShopItems()
    {
        return new List<ShopItem>(shopItemsDict.Values);
    }

    private void SaveToPlayerPrefsIsItemPurchased(string key, bool purchased)
    {
        PlayerPrefs.SetInt(key, purchased ? 1 : 0);
    }

    private bool GetFromPlayerPrefsIsItemPurchased(string key)
    {
        return PlayerPrefs.GetInt(key) == 1;
    }
}
