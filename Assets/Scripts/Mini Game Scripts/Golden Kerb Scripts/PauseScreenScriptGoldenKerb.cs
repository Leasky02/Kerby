using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreenScriptGoldenKerb : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject rankUpScreen;
    public GameObject ball;
    public GameObject announcement;
    public GameObject menuButton;
    public GameObject claimButton;
    public GameObject CoinDisplay;
    public static bool rankUp;
    public string levelToLoad;
    public bool miniGame;

    private void Start()
    {
        //sets pause screens off the screen
        rankUp = false;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        rankUpScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        if(miniGame)
            menuButton.GetComponent<Button>().interactable = false;
            claimButton.GetComponent<Button>().interactable = false;
    }

    public void PauseScreen()
    {
        //disbale touch screen and make pause screen appear
        ball.GetComponent<BallControlGoldenKerb>().enabled = false;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        announcement.GetComponent<Text>().enabled = false;
        menuButton.GetComponent<Button>().interactable = false;
        claimButton.GetComponent<Button>().interactable = false;
    }

    public void CancelPauseScreen()
    {
        //move pause scren off screen and re enable the ball touch movement
        ball.GetComponent<BallControlGoldenKerb>().enabled = true;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        announcement.GetComponent<Text>().enabled = true;
        menuButton.GetComponent<Button>().interactable = true;
        claimButton.GetComponent<Button>().interactable = true;
    }

    public void ProceedExit()
    {
        //upon exit, if the player has ranked up, show the rank screen
        if (rankUp)
        {
            RankUpScreen();
        }
        //if not... just load menu
        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
    //leave directly
    public void Exit()
    {
            CoinDisplay.GetComponent<CoinCount>().CompleteJackpot();
            SceneManager.LoadScene(levelToLoad);
    }
    //show the rank up screen when called when leavingrol
    public void RankUpScreen()
    {
        menuButton.GetComponent<AudioSource>().Play();
        ball.GetComponent<BallControlGoldenKerb>().enabled = false;
        rankUpScreen.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        announcement.GetComponent<Text>().enabled = false;
    }

    public void RankAchieved()
    {
        rankUp = true;
    }
}
