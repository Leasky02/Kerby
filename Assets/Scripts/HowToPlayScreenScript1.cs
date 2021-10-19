using UnityEngine;
using UnityEngine.UI;

public class HowToPlayScreenScript1 : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject rankUpScreen;
    public GameObject ball;
    public GameObject announcement;
    public GameObject menuButton;
    public static bool rankUp;

    private void Start()
    {
        rankUp = false;
        pauseScreen.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        rankUpScreen.GetComponent<Transform>().position = new Vector3(0, 100, 0);
        menuButton.GetComponent<Button>().interactable = true;
        PauseScreen();
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
}
