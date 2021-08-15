using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreenScriptDouleKerb : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject rankUpScreen;
    public GameObject ball;
    public GameObject announcement;
    public GameObject menuButton;
    public static bool rankUp;
    public string levelToLoad;
    public bool miniGame;

    private void Start()
    {
        rankUp = false;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        rankUpScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        if(miniGame)
            menuButton.GetComponent<Button>().interactable = false;
    }

    public void PauseScreen()
    {
        ball.GetComponent<BallControlDoubleKerb>().enabled = false;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        announcement.GetComponent<Text>().enabled = false;
        menuButton.GetComponent<Button>().interactable = false;
    }

    public void CancelPauseScreen()
    {
        ball.GetComponent<BallControlDoubleKerb>().enabled = true;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        announcement.GetComponent<Text>().enabled = true;
        menuButton.GetComponent<Button>().interactable = true;
    }

    public void ProceedExit()
    {
        if (rankUp)
        {
            RankUpScreen();
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
        ball.GetComponent<BallControlDoubleKerb>().enabled = false;
        rankUpScreen.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        announcement.GetComponent<Text>().enabled = false;
    }

    public void RankAchieved()
    {
        rankUp = true;
    }
}
