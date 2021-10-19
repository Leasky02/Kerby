using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreenScript : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject rankUpScreen;
    public GameObject endScreen;
    public GameObject menuButton;
    public GameObject ball;
    public GameObject announcement;
    public static bool rankUp;
    public string levelToLoad;

    private void Awake()
    {
        rankUp = false;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        rankUpScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        menuButton.GetComponent<Button>().interactable = true;
    }

    public void PauseScreen()
    {
        ball.GetComponent<BallControl2player>().enabled = false;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        announcement.GetComponent<Text>().enabled = false;
        menuButton.GetComponent<Button>().interactable = false;
    }

    public void CancelPauseScreen()
    {
        ball.GetComponent<BallControl2player>().enabled = true;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        announcement.GetComponent<Text>().enabled = true;
        menuButton.GetComponent<Button>().interactable = true;
    }

    public void ProceedExit()
    {
        Debug.Log(rankUp);
        if (rankUp)
        {
            RankUpScreen();
            endScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void RankUpScreen()
    {
        menuButton.GetComponent<AudioSource>().Play();
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        ball.GetComponent<BallControl2player>().enabled = false;
        rankUpScreen.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        announcement.GetComponent<Text>().enabled = false;
    }

    public void RankAchieved()
    {
        rankUp = true;
    }
}
