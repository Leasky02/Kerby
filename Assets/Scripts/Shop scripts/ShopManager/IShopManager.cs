using System.Collections.Generic;
using UnityEngine;

public abstract class IShopManager
{
    private Dictionary<string, ShopItem> shopItemsDict = new Dictionary<string, ShopItem>();
    
    private Dictionary<string, bool> shopItemsPurchasedDict = new Dictionary<string, bool>();

    private string activeItemKey;

    protected IShopManager()
    {
        activeItemKey = "";
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
        
        int coins = CoinCount.GetCoins();
        ShopItem item;
        return shopItemsDict.TryGetValue(key, out item) ? (coins >= item.price) : false;
    }
    
    public bool TryBuyWithCoins(string key)
    {
        // Have we purchased the item already?
        if (IsItemAvailable(key))
            return false;
        
        int coins = CoinCount.GetCoins();
        ShopItem item;
        if (shopItemsDict.TryGetValue(key, out item))
        {
            if (coins >= item.price)
            {
                GameObject coinsTxt = GameObject.FindWithTag("CoinTxt");
                if (coinsTxt != null)
                    coins = coinsTxt.GetComponent<CoinCount>().SubtractCoins(item.price);
                else
                    Debug.LogWarning("Active GameObject with tag CoinTxt not found in scene");
                
                GameObject purchaseAudio = GameObject.FindWithTag("AudioPurchase");
                if (purchaseAudio != null)
                    purchaseAudio.GetComponent<AudioSource>().Play();
                else
                    Debug.LogWarning("Active GameObject with tag AudioPurchase not found in scene");
                
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

    public void SetActiveItem(string key)
    {
        activeItemKey = key;
    }

    protected ShopItem GetItem(string key)
    {
        ShopItem item;
        return shopItemsDict.TryGetValue(key, out item) ? item : null;
    }

    public bool HasActiveItem()
    {
        return activeItemKey.Length > 0 && shopItemsDict.ContainsKey(activeItemKey);
    }

    public ShopItem GetActiveItem()
    {
        return GetItem(activeItemKey);
    }
}
