using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManagerScript : MonoBehaviour, IUnityAdsListener
{

    public GameObject pauseScreen;
    public GameObject[] buttons;
#if UNITY_IOS
    private string gameId = "4203626";
    string mySurfacingId = "Rewarded_iOS";

#elif UNITY_ANDROID
    private string gameId = "4203627";
    string mySurfacingId = "Rewarded_Android";
#endif

    private static int addCounter = 0;
    private bool getReward = false;
    bool testMode = false;
    public bool inGame = true;

    public bool timer;
    private int time;

    public bool mainMenu;
    public GameObject coinDisplay;

    private void Start()
    {
        Initialise();

        if(inGame)
            AddCountdown();

        if(mainMenu)
        {
            if(addCounter>=4)
            {
                ShowInterstitialAd();
                addCounter = 0;
                Debug.Log("Show ad");
            }
        }
    }
    void Initialise()
    {
        Advertisement.AddListener(this);
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowInterstitialAd()
    {
        getReward = false;
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
        Initialise();
    }


    public void ShowRewardedVideo()
    {
        getReward = true;
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            //Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
            ShowError();
        }
        Initialise();
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if(getReward)
            {
                coinDisplay.GetComponent<CoinCount>().AddCoins(30);
            }
            
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            //Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }



    public void AddCountdown()
    {
        addCounter++;
        Debug.Log(addCounter);
        if (addCounter >= 4)
        {
            ShowInterstitialAd();
            addCounter = 0;
            Debug.Log("Show ad");
        }
    }

    public void AddCounterDuringGame()
    {
        addCounter++;
        Debug.Log(addCounter);
    }

    private void FixedUpdate()
    {
        if(timer)
        {
            time++;
            //Debug.Log(time);
            if(time >5400)
            {
                AddCounterDuringGame();
                time = 0;
            }
        }
    }

    public void ShowError()
    {
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        buttons[0].GetComponent<Button>().interactable = false;
        buttons[1].GetComponent<Button>().interactable = false;
        buttons[2].GetComponent<Button>().interactable = false;
        buttons[3].GetComponent<Button>().interactable = false;
        buttons[4].GetComponent<Button>().interactable = false;
        buttons[5].GetComponent<Button>().interactable = false;
        buttons[6].GetComponent<Button>().interactable = false;
        buttons[7].GetComponent<Button>().interactable = false;
    }

    public void HideError()
    {
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        buttons[0].GetComponent<Button>().interactable = true;
        buttons[1].GetComponent<Button>().interactable = true;
        buttons[2].GetComponent<Button>().interactable = true;
        buttons[3].GetComponent<Button>().interactable = true;
        buttons[4].GetComponent<Button>().interactable = true;
        buttons[5].GetComponent<Button>().interactable = true;
        buttons[6].GetComponent<Button>().interactable = true;
        buttons[7].GetComponent<Button>().interactable = true;
    }
}
