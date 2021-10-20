using UnityEngine;

public class LightningSounsaScript : MonoBehaviour
{
    public AudioClip[] lightningSound;
    public void PlayLightning()
    {
        GetComponent<AudioSource>().clip = lightningSound[Random.Range(0, 2)];
        GetComponent<AudioSource>().Play();
    }
}
