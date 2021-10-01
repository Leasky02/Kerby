using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    private const int ITEM_COUNT = 12;

    private const int ID_INDEX = 0;
    private const int PRICE_INDEX = 1;
    private const int PUCHASED_INDEX = 2;
    private const int ACTIVE_INDEX = 3;
    private const int SHOP_ITEM_ROWS = 4;

    public static int[,] shopItems = new int[SHOP_ITEM_ROWS, ITEM_COUNT];
    public int coins;
    public Text coinsTxt;

    private Sprite[] ballSprites = new Sprite[ITEM_COUNT];
    private Color[] ballParticleColors = new Color[ITEM_COUNT];
    
    private const int RUBBER_BOUNCE = 0;
    private const int STONE_BOUNCE = 1;
    private const int SLUDGE_BOUNCE = 2;
    private const int MONEY_BOUNCE = 3;
    private const int AUDIO_CLIPS_COUNT = 4;
    private AudioClip[] bounceAudioClips = new AudioClip[AUDIO_CLIPS_COUNT];

    private int[] ballToAudioClips = new int[ITEM_COUNT];

    private static int firstLoad = 0;

    void Awake()
    {
        ballSprites[0] = Resources.Load<Sprite>("Sprites/Balls/BallOrange");        // orange ball (default)
        ballSprites[1] = Resources.Load<Sprite>("Sprites/Balls/BallBlue");          // blue ball
        ballSprites[2] = Resources.Load<Sprite>("Sprites/Balls/BallYellow");        // yellow ball
        ballSprites[3] = Resources.Load<Sprite>("Sprites/Balls/BallRed");           // red ball
        ballSprites[4] = Resources.Load<Sprite>("Sprites/Balls/BallPurple");        // purple ball
        ballSprites[5] = Resources.Load<Sprite>("Sprites/Balls/BallTractorWheel");  // tractor wheel
        ballSprites[6] = Resources.Load<Sprite>("Sprites/Balls/BallFlumbleGrey");       // flumble ball
        ballSprites[7] = Resources.Load<Sprite>("Sprites/Balls/BallDonut");         // donut
        ballSprites[8] = Resources.Load<Sprite>("Sprites/Balls/BallWatermelon");    // watermelon
        ballSprites[9] = Resources.Load<Sprite>("Sprites/Balls/BallGlobe");         // globe
        ballSprites[10] = Resources.Load<Sprite>("Sprites/Balls/BallCoin");         // coin
        ballSprites[11] = Resources.Load<Sprite>("Sprites/Balls/BallOrange");       // orange ball (default)

        ballParticleColors[0] = new Color(0.972f, 0.564f, 0f);      // orange ball (default)
        ballParticleColors[1] = new Color(0.058f, 0.101f, 0.960f);  // blue ball
        ballParticleColors[2] = new Color(0.941f, 0.984f, 0.035f);  // yellow ball
        ballParticleColors[3] = new Color(1f, 0.058f, 0.058f);      // red ball
        ballParticleColors[4] = new Color(0.549f, 0.086f, 0.552f);  // purple ball
        ballParticleColors[5] = new Color(0, 0, 0);                 // tractor wheel - black color
        ballParticleColors[6] = new Color(0.5f, 0.5f, 0.5f);        // flumble ball - grey color
        ballParticleColors[7] = new Color(0.631f, 0.611f, 0.827f);  // donut - cream color
        ballParticleColors[8] = new Color(0.184f, 0.447f, 0.133f);  // watermelon - dark green color
        ballParticleColors[9] = new Color(0.513f, 0.807f, 0.749f);  // globe - light blue color
        ballParticleColors[10] = new Color(0.941f, 0.984f, 0.035f); // coin - gold color
        ballParticleColors[11] = new Color(0.972f, 0.564f, 0f);     // orange ball (default)

        bounceAudioClips[RUBBER_BOUNCE] = Resources.Load<AudioClip>("Audio/Ball Bounce/BasketballBounce");
        bounceAudioClips[STONE_BOUNCE] = Resources.Load<AudioClip>("Audio/Ball Bounce/StoneBounce");
        bounceAudioClips[SLUDGE_BOUNCE] = Resources.Load<AudioClip>("Audio/Ball Bounce/FoodBounce");
        bounceAudioClips[MONEY_BOUNCE] = Resources.Load<AudioClip>("Audio/Ball Bounce/CoinBounce");

        ballToAudioClips[0] = RUBBER_BOUNCE;    // orange ball (default)
        ballToAudioClips[1] = RUBBER_BOUNCE;    // blue ball
        ballToAudioClips[2] = RUBBER_BOUNCE;    // yellow ball
        ballToAudioClips[3] = RUBBER_BOUNCE;    // red ball
        ballToAudioClips[4] = RUBBER_BOUNCE;    // purple ball
        ballToAudioClips[5] = RUBBER_BOUNCE;    // tractor wheel
        ballToAudioClips[6] = STONE_BOUNCE;     // flumble ball
        ballToAudioClips[7] = SLUDGE_BOUNCE;    // donut
        ballToAudioClips[8] = SLUDGE_BOUNCE;    // watermelon
        ballToAudioClips[9] = STONE_BOUNCE;     // globe
        ballToAudioClips[10] = MONEY_BOUNCE;    // coin
        ballToAudioClips[11] = RUBBER_BOUNCE;   // orange ball (default)

        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        coinsTxt.text = coins.ToString();

        //ID'S
        shopItems[ID_INDEX, 1] = 1;
        shopItems[ID_INDEX, 2] = 2;
        shopItems[ID_INDEX, 3] = 3;
        shopItems[ID_INDEX, 4] = 4;
        shopItems[ID_INDEX, 5] = 5;
        shopItems[ID_INDEX, 6] = 6;
        shopItems[ID_INDEX, 7] = 7;
        shopItems[ID_INDEX, 8] = 8;
        shopItems[ID_INDEX, 9] = 9;
        shopItems[ID_INDEX, 10] = 10;

        //original ball
        shopItems[ID_INDEX, 11] = 11;

        //price
        shopItems[PRICE_INDEX, 1] = 5;
        shopItems[PRICE_INDEX, 2] = 10;
        shopItems[PRICE_INDEX, 3] = 15;
        shopItems[PRICE_INDEX, 4] = 20;
        shopItems[PRICE_INDEX, 5] = 50;
        shopItems[PRICE_INDEX, 6] = 50;
        shopItems[PRICE_INDEX, 7] = 150;
        shopItems[PRICE_INDEX, 8] = 150;
        shopItems[PRICE_INDEX, 9] = 150;
        shopItems[PRICE_INDEX, 10] = 150;

        if (firstLoad == 0)
        {
            firstLoad = 1;

            //active sprite status (1 = active)
            shopItems[ACTIVE_INDEX, 1] = 0;
            shopItems[ACTIVE_INDEX, 2] = 0;
            shopItems[ACTIVE_INDEX, 3] = 0;
            shopItems[ACTIVE_INDEX, 4] = 0;
            shopItems[ACTIVE_INDEX, 5] = 0;
            shopItems[ACTIVE_INDEX, 6] = 0;
            shopItems[ACTIVE_INDEX, 7] = 0;
            shopItems[ACTIVE_INDEX, 8] = 0;
            shopItems[ACTIVE_INDEX, 9] = 0;
            shopItems[ACTIVE_INDEX, 10] = 0;

            //default ball
            shopItems[ACTIVE_INDEX, 11] = 1;
        }


        //default ball has been bought
        shopItems[PUCHASED_INDEX, 11] = 1;
        PlayerPrefs.SetInt("ball11", shopItems[PUCHASED_INDEX, 11]);

        LoadFromPlayerPrefs();
    }

    public void BuyWithCoins(GameObject ButtonRef)
    {
        coins = coinsTxt.GetComponent<CoinCount>().GetCoins();
        int buttonBallID = ButtonRef.GetComponent<ButtonInfo>().itemID;
        if (coins >= shopItems[PRICE_INDEX, buttonBallID])
        {
            coins -= shopItems[PRICE_INDEX, buttonBallID];
            ButtonRef.GetComponent<Button>().interactable = false;
            coinsTxt.GetComponent<CoinCount>().SubtractCoins(shopItems[PRICE_INDEX, buttonBallID]);
            GetComponent<AudioSource>().Play();
            UnlockItem(buttonBallID);
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
        int ballID = ButtonRef.GetComponent<ButtonInfoSetup>().itemID;
        if (IsItemAvailable(ballID))
        {
            for (int ID = 0; ID < ITEM_COUNT; ++ID)
            {
                shopItems[ACTIVE_INDEX, ID] = 0;
            }
            shopItems[ACTIVE_INDEX, ballID] = 1;
        }
    }

    private Color GetBallParticleColorForBall(int ballID)
    {
        return ballParticleColors[ballID];
    }

    private AudioClip GetBounceAudioClipForBall(int ballID)
    {
        return bounceAudioClips[ballToAudioClips[ballID]];
    }

    private Sprite GetBallSpriteForBall(int ballID)
    {
        return ballSprites[ballID];
    }

    private int GetSelectedBallID()
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
    
    public Color GetBallParticleColorForSelectedBall()
    {
        return GetBallParticleColorForBall(GetSelectedBallID());
    }
    
    public AudioClip GetBounceAudioClipForSelectedBall()
    {
        return GetBounceAudioClipForBall(GetSelectedBallID());
    }

    public Sprite GetBallSpriteForSelectedBall()
    {
        return GetBallSpriteForBall(GetSelectedBallID());
    }

    private void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetInt("ball1", shopItems[PUCHASED_INDEX, 1]);
        PlayerPrefs.SetInt("ball2", shopItems[PUCHASED_INDEX, 2]);
        PlayerPrefs.SetInt("ball3", shopItems[PUCHASED_INDEX, 3]);
        PlayerPrefs.SetInt("ball4", shopItems[PUCHASED_INDEX, 4]);
        PlayerPrefs.SetInt("ball5", shopItems[PUCHASED_INDEX, 5]);
        PlayerPrefs.SetInt("ball6", shopItems[PUCHASED_INDEX, 6]);
        PlayerPrefs.SetInt("ball7", shopItems[PUCHASED_INDEX, 7]);
        PlayerPrefs.SetInt("ball8", shopItems[PUCHASED_INDEX, 8]);
        PlayerPrefs.SetInt("ball9", shopItems[PUCHASED_INDEX, 9]);
        PlayerPrefs.SetInt("ball10", shopItems[PUCHASED_INDEX, 10]);
        PlayerPrefs.SetInt("ball11", shopItems[PUCHASED_INDEX, 11]);
    }

    private void LoadFromPlayerPrefs()
    {
        shopItems[PUCHASED_INDEX, 1] = PlayerPrefs.GetInt("ball1");
        shopItems[PUCHASED_INDEX, 2] = PlayerPrefs.GetInt("ball2");
        shopItems[PUCHASED_INDEX, 3] = PlayerPrefs.GetInt("ball3");
        shopItems[PUCHASED_INDEX, 4] = PlayerPrefs.GetInt("ball4");
        shopItems[PUCHASED_INDEX, 5] = PlayerPrefs.GetInt("ball5");
        shopItems[PUCHASED_INDEX, 6] = PlayerPrefs.GetInt("ball6");
        shopItems[PUCHASED_INDEX, 7] = PlayerPrefs.GetInt("ball7");
        shopItems[PUCHASED_INDEX, 8] = PlayerPrefs.GetInt("ball8");
        shopItems[PUCHASED_INDEX, 9] = PlayerPrefs.GetInt("ball9");
        shopItems[PUCHASED_INDEX, 10] = PlayerPrefs.GetInt("ball10");
        shopItems[PUCHASED_INDEX, 11] = PlayerPrefs.GetInt("ball11");
    }
}
