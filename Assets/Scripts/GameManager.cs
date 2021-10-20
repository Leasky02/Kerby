using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    public enum ShopItemType { BallSkin, Location, MiniGame };
    
    private Dictionary<ShopItemType, IShopManager> shopManagers = new Dictionary<ShopItemType, IShopManager>();

    void Awake ()
    {
        shopManagers.Add(ShopItemType.BallSkin, new ShopManagerBallSkins());
        shopManagers.Add(ShopItemType.Location, new ShopManagerLocations());
        shopManagers.Add(ShopItemType.MiniGame, new ShopManagerMiniGames());
    }

    // private IShopManager GetShopManager(ShopItemType type)
    // {
    //     IShopManager shopManager;
    //     return shopManagers.TryGetValue(type, out shopManager) ? shopManager : null;
    // }

    public ShopManagerBallSkins GetBallSkinsShopManager()
    {
        return shopManagers[ShopItemType.BallSkin] as ShopManagerBallSkins;
    }

    public ShopManagerLocations GetLocationsShopManager()
    {
        return shopManagers[ShopItemType.Location] as ShopManagerLocations;
    }

    public ShopManagerMiniGames GetMiniGamesShopManager()
    {
        return shopManagers[ShopItemType.MiniGame] as ShopManagerMiniGames;
    }

    public List<ShopItem> GetShopItemsOfType(ShopItemType type)
    {
        return shopManagers[type].GetShopItems();
    }

    public bool IsItemOwned(string key)
    {
        foreach (KeyValuePair<ShopItemType, IShopManager> entry in shopManagers)
        {
            if (entry.Value.IsItemAvailable(key))
                return true;
        }
        return false;
    }

    public bool IsItemAvailableToBuy(string key)
    {
        foreach (KeyValuePair<ShopItemType, IShopManager> entry in shopManagers)
        {
            if (entry.Value.CanBuyWithCoins(key))
                return true;
        }
        return false;
    }

    public bool IsItemActive(string key)
    {
        foreach (KeyValuePair<ShopItemType, IShopManager> entry in shopManagers)
        {
            if (entry.Value.HasActiveItem() && entry.Value.GetActiveItem().key == key)
                return true;
        }
        return false;
    }

    public bool TryBuyItemWithCoins(string key)
    {
        foreach (KeyValuePair<ShopItemType, IShopManager> entry in shopManagers)
        {
            if (entry.Value.TryBuyWithCoins(key))
                return true;
        }
        return false;
    }

    public bool TrySetActiveItem(string key)
    {
        foreach (KeyValuePair<ShopItemType, IShopManager> entry in shopManagers)
        {
            if (entry.Value.HasItemForKey(key))
            {
                entry.Value.SetActiveItem(key);
                return true;
            }
        }
        return false;
    }
}
