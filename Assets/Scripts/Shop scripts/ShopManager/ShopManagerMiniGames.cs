
public class ShopManagerMiniGames : IShopManager
{
    private const string MINI_GAME_ID_SHOT_IN_THE_DARK = "miniGames1";
    private const string MINI_GAME_ID_DOUBLE_KERY = "miniGames2";
    private const string MINI_GAME_ID_GOLDEN_KERB = "miniGames4";
    private const string MINI_GAME_ID_MARS_MISSION = "miniGames5";

    void Start()
    {
        AddShopItem(ShopItem.CreateMiniGameItem(
            "Shot in the Dark",
            MINI_GAME_ID_SHOT_IN_THE_DARK,
            250,
            "Reguler Kerby... but where is the kerb?",
            "Sprites/MiniGames/MiniGameShotInTheDark"
        ));
        AddShopItem(ShopItem.CreateMiniGameItem(
            "Double Kerb",
            MINI_GAME_ID_DOUBLE_KERY,
            350,
            "Hit both kerbs and win big!",
            "Sprites/MiniGames/MiniGameDoubleKerb"
        ));
        AddShopItem(ShopItem.CreateMiniGameItem(
            "Golden Kerb",
            MINI_GAME_ID_GOLDEN_KERB,
            500,
            "Risk taking another shot to lose the jackpot!",
            "Sprites/MiniGames/MiniGameGoldenKerb"
        ));
        AddShopItem(ShopItem.CreateMiniGameItem(
            "Mars Mission",
            MINI_GAME_ID_MARS_MISSION,
            800,
            "Hit the kerb to score. Watch out for the spaceships too!",
            "Sprites/MiniGames/MiniGameMarsMission"
        ));
    }
}
