using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour
{
    private int tutorial = 0;
    private static string sceneToLoad;

    private void Awake()
    {
        tutorial = PlayerPrefs.GetInt("tutorial");
    }

    public void DoTutorial(string scene)
    {
        if(tutorial == 0)
        {
            SceneManager.LoadScene("Tutorial1");
            tutorial = 1;
            PlayerPrefs.SetInt("tutorial", tutorial);
            sceneToLoad = scene;
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void EndTutorial()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
