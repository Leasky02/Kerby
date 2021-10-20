using System.Collections.Generic;
using UnityEngine;

public class ShopManagerLocations : IShopManager
{
    // Location IDs
    private const string LOCATION_ID_NEW_YORK = "background6";
    private const string LOCATION_ID_DESERT = "background1";
    private const string LOCATION_ID_LOCH_NESS = "background2";
    private const string LOCATION_ID_SUBURBS = "background3";
    private const string LOCATION_ID_HIMALAYAS = "background4";
    private const string LOCATION_ID_RAINFOREST = "background5";

    // Default Location ID
    private const string LOCATION_ID_DEFAULT = LOCATION_ID_NEW_YORK;

    private Dictionary<string, Color> skyColors = new Dictionary<string, Color>();

    public ShopManagerLocations() : base()
    {
        skyColors.Add(LOCATION_ID_NEW_YORK,     new Color(0.631f, 0.611f, 0.827f));  // New York
        skyColors.Add(LOCATION_ID_DESERT,       new Color(0.894f, 0.447f, 0.156f));  // Desert
        skyColors.Add(LOCATION_ID_LOCH_NESS,    new Color(0.568f, 0.866f, 0.882f));  // Loch Ness
        skyColors.Add(LOCATION_ID_SUBURBS,      new Color(0.862f, 0.741f, 0.741f));  // Suburbs
        skyColors.Add(LOCATION_ID_HIMALAYAS,    new Color(0.592f, 0.768f, 0.803f));  // Himalayas
        skyColors.Add(LOCATION_ID_RAINFOREST,   new Color(0.647f, 0.878f, 0.658f));  // Rainforest

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

    private ShopItem GetDefaultLocation()
    {
        return GetItem(LOCATION_ID_DEFAULT);
    }

    public Sprite GetActiveLocationSprite()
    {
        return (HasActiveItem() ? GetActiveItem() : GetDefaultLocation()).image;
    }

    public Color GetActiveSkyColor()
    {
        ShopItem activeItem = HasActiveItem() ? GetActiveItem() : GetDefaultLocation();
        Color skyColor;
        skyColors.TryGetValue(activeItem.key, out skyColor);
        return skyColor;
    }
}
