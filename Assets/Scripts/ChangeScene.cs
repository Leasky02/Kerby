﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string loadScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(loadScene);
    }

}
