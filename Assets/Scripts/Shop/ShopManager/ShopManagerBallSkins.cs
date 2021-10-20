using System.Collections.Generic;
using UnityEngine;

public class ShopManagerBallSkins : IShopManager
{
    // Ball Skin IDs
    private const string BALL_SKIN_ID_ORANGE = "ball11";
    private const string BALL_SKIN_ID_BLUE = "ball1";
    private const string BALL_SKIN_ID_YELLOW = "ball2";
    private const string BALL_SKIN_ID_RED = "ball3";
    private const string BALL_SKIN_ID_PURPLE = "ball4";
    private const string BALL_SKIN_ID_TRACTOR_WHEEL = "ball5";
    private const string BALL_SKIN_ID_FLUMBLE_GREY = "ball6";
    private const string BALL_SKIN_ID_DONUT = "ball7";
    private const string BALL_SKIN_ID_WATERMELON = "ball8";
    private const string BALL_SKIN_ID_GLOBE = "ball9";
    private const string BALL_SKIN_ID_COIN = "ball10";

    // Default Ball Skin ID
    private const string BALL_SKIN_ID_DEFAULT = BALL_SKIN_ID_ORANGE;

    // Ball Bounce Audio Clip IDs
    private const string RUBBER_BOUNCE = "rubber";
    private const string STONE_BOUNCE = "stone";
    private const string SLUDGE_BOUNCE = "sludge";
    private const string MONEY_BOUNCE = "money";

    private Dictionary<string, Color> ballParticleColors = new Dictionary<string, Color>();

    private Dictionary<string, AudioClip> ballBounceAudioClips = new Dictionary<string, AudioClip>();

    private Dictionary<string, string> ballToAudioClipID = new Dictionary<string, string>();

    public ShopManagerBallSkins() : base()
    {
        ballParticleColors.Add(BALL_SKIN_ID_ORANGE,         new Color(0.972f, 0.564f, 0f));         // orange ball (default)
        ballParticleColors.Add(BALL_SKIN_ID_BLUE,           new Color(0.058f, 0.101f, 0.960f));     // blue ball
        ballParticleColors.Add(BALL_SKIN_ID_YELLOW,         new Color(0.941f, 0.984f, 0.035f));     // yellow ball
        ballParticleColors.Add(BALL_SKIN_ID_RED,            new Color(1f, 0.058f, 0.058f));         // red ball
        ballParticleColors.Add(BALL_SKIN_ID_PURPLE,         new Color(0.549f, 0.086f, 0.552f));     // purple ball
        ballParticleColors.Add(BALL_SKIN_ID_TRACTOR_WHEEL,  new Color(0, 0, 0));                    // tractor wheel - black color
        ballParticleColors.Add(BALL_SKIN_ID_FLUMBLE_GREY,   new Color(0.5f, 0.5f, 0.5f));           // flumble ball - grey color
        ballParticleColors.Add(BALL_SKIN_ID_DONUT,          new Color(0.631f, 0.611f, 0.827f));     // donut - cream color
        ballParticleColors.Add(BALL_SKIN_ID_WATERMELON,     new Color(0.184f, 0.447f, 0.133f));     // watermelon - dark green color
        ballParticleColors.Add(BALL_SKIN_ID_GLOBE,          new Color(0.513f, 0.807f, 0.749f));     // globe - light blue color
        ballParticleColors.Add(BALL_SKIN_ID_COIN,           new Color(0.941f, 0.984f, 0.035f));     // coin - gold color

        ballBounceAudioClips.Add(RUBBER_BOUNCE, Resources.Load<AudioClip>("Audio/SoundEffects/BallBounce/BasketballBounce"));
        ballBounceAudioClips.Add(STONE_BOUNCE, Resources.Load<AudioClip>("Audio/SoundEffects/BallBounce/StoneBounce"));
        ballBounceAudioClips.Add(SLUDGE_BOUNCE, Resources.Load<AudioClip>("Audio/SoundEffects/BallBounce/FoodBounce"));
        ballBounceAudioClips.Add(MONEY_BOUNCE, Resources.Load<AudioClip>("Audio/SoundEffects/BallBounce/CoinBounce"));

        ballToAudioClipID.Add(BALL_SKIN_ID_ORANGE, RUBBER_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_BLUE, RUBBER_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_YELLOW, RUBBER_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_RED, RUBBER_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_PURPLE, RUBBER_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_TRACTOR_WHEEL, RUBBER_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_FLUMBLE_GREY, STONE_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_DONUT, SLUDGE_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_WATERMELON, SLUDGE_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_GLOBE, STONE_BOUNCE);
        ballToAudioClipID.Add(BALL_SKIN_ID_COIN, MONEY_BOUNCE);

        AddShopItem(ShopItem.CreateBallSkinItem(
            "Donut",
            BALL_SKIN_ID_DONUT,
            150, 0,
            "Who doesn't love a chocolate donut",
            "Sprites/Balls/BallDonut"
        ));
        AddShopItem(ShopItem.CreateBallSkinItem(
            "Watermelon",
            BALL_SKIN_ID_WATERMELON,
            150, 0,
            "I've always wanted to throw a watermelon",
            "Sprites/Balls/BallWatermelon"
        ));
        AddShopItem(ShopItem.CreateBallSkinItem(
            "Globe",
            BALL_SKIN_ID_GLOBE,
            150, 0,
            "The world is in your hands... literally",
            "Sprites/Balls/BallGlobe"
        ));
        AddShopItem(ShopItem.CreateBallSkinItem(
            "Coin",
            BALL_SKIN_ID_COIN,
            150, 0,
            "A normal coin... but bigger",
            "Sprites/Balls/BallCoin"
        ));
        AddShopItem(ShopItem.CreateBallSkinItem(
            "Orange Ball",
            BALL_SKIN_ID_ORANGE,
            0, 1,
            "The standard ball",
            "Sprites/Balls/BallOrange"
        ));
        AddShopItem(ShopItem.CreateBallSkinItem(
            "Blue Ball",
            BALL_SKIN_ID_BLUE,
            0, 5,
            "Available at Rank 5",
            "Sprites/Balls/BallBlue"
        ));
        AddShopItem(ShopItem.CreateBallSkinItem(
            "Yellow Ball",
            BALL_SKIN_ID_YELLOW,
            0, 10,
            "Available at Rank 10",
            "Sprites/Balls/BallYellow"
        ));
        AddShopItem(ShopItem.CreateBallSkinItem(
            "Red Ball",
            BALL_SKIN_ID_RED,
            0, 15,
            "Available at Rank 15",
            "Sprites/Balls/BallRed"
        ));
        AddShopItem(ShopItem.CreateBallSkinItem(
            "Purple Ball",
            BALL_SKIN_ID_PURPLE,
            0, 20,
            "Available at Rank 20",
            "Sprites/Balls/BallPurple"
        ));
        // AddShopItem(ShopItem.CreateBallSkinItem(
        //     "Tractor Wheel",
        //     BALL_SKIN_ID_TRACTOR_WHEEL,
        //     150, 0,
        //     "...",
        //     "Sprites/Balls/BallTractorWheel"
        // ));
        // AddShopItem(ShopItem.CreateBallSkinItem(
        //     "What's this?",
        //     BALL_SKIN_ID_FLUMBLE_GREY,
        //     150, 0,
        //     "...",
        //     "Sprites/Balls/BallFlumbleGrey"
        // ));
    }

    private ShopItem GetDefaultBallSkin()
    {
        return GetItem(BALL_SKIN_ID_DEFAULT);
    }

    public Sprite GetActiveBallSkinSprite()
    {
        return (HasActiveItem() ? GetActiveItem() : GetDefaultBallSkin()).image;
    }

    public Color GetActiveBallParticleColor()
    {
        ShopItem activeItem = HasActiveItem() ? GetActiveItem() : GetDefaultBallSkin();
        Color ballParticleColor;
        ballParticleColors.TryGetValue(activeItem.key, out ballParticleColor);
        return ballParticleColor;
    }

    public AudioClip GetActiveBallBounceAudioClip()
    {
        ShopItem activeItem = HasActiveItem() ? GetActiveItem() : GetDefaultBallSkin();
        string ballBounceAudioClipID;
        ballToAudioClipID.TryGetValue(activeItem.key, out ballBounceAudioClipID);
        AudioClip ballBounceAudioClip;
        ballBounceAudioClips.TryGetValue(ballBounceAudioClipID, out ballBounceAudioClip);
        return ballBounceAudioClip;
    }
}
