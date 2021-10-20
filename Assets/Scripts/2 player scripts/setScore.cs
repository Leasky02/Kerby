using UnityEngine;
using UnityEngine.UI;

public class setScore : MonoBehaviour
{
    public void SetScore(int player1Score, int player2Score)
    {
        GetComponent<Text>().text = player1Score + " : " + player2Score;
    }
}
