using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectMusic : MonoBehaviour
{
    public Slider slider;
    public float volume;
    public GameObject musicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GameObject.Find("Music");
        slider.GetComponent<Slider>().value = musicPlayer.GetComponent<VolumeChanger>().AudioVolume;
        volume = slider.GetComponent<Slider>().value;
        musicPlayer.GetComponent<VolumeChanger>().SetVolume(volume);
    }

    private void Update()
    {
        volume = slider.GetComponent<Slider>().value;
        //Debug.Log(volume);
    }

    public void FindMusicPlayer()
    {
        musicPlayer.GetComponent<VolumeChanger>().SetVolume(volume);
    }
}
