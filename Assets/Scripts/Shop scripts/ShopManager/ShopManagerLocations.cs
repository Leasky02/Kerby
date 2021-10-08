
public class ShopManagerLocations : IShopManager
{
    private const string LOCATION_ID_NEW_YORK = "background6";
    private const string LOCATION_ID_DESERT = "background1";
    private const string LOCATION_ID_LOCH_NESS = "background2";
    private const string LOCATION_ID_SUBURBS = "background3";
    private const string LOCATION_ID_HIMALAYAS = "background4";
    private const string LOCATION_ID_RAINFOREST = "background5";

    void Start()
    {
        AddShopItem(ShopItem.CreateLocationItem(
            "New York",
            LOCATION_ID_NEW_YORK,
            0,
            "Sprites/Backgrounds/Standard/NewYork",
            false
        ));
        AddShopItem(ShopItem.CreateLocationItem(
            "Desert",
            LOCATION_ID_DESERT,
            300,
            "Sprites/Backgrounds/Standard/Desert",
            true
        ));
        AddShopItem(ShopItem.CreateLocationItem(
            "Loch Ness",
            LOCATION_ID_LOCH_NESS,
            350,
            "Sprites/Backgrounds/Standard/LochNess",
            true
        ));
        AddShopItem(ShopItem.CreateLocationItem(
            "Suburbs",
            LOCATION_ID_SUBURBS,
            400,
            "Sprites/Backgrounds/Standard/Suburbs",
            true
        ));
        AddShopItem(ShopItem.CreateLocationItem(
            "Himalayas",
            LOCATION_ID_HIMALAYAS,
            450,
            "Sprites/Backgrounds/Standard/Himalayas",
            true
        ));
        AddShopItem(ShopItem.CreateLocationItem(
            "Rainforest",
            LOCATION_ID_RAINFOREST,
            500,
            "Sprites/Backgrounds/Standard/Rainforest",
            true
        ));
    }
}
