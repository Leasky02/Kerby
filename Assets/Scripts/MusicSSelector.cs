using UnityEngine;

public class MusicSSelector : MonoBehaviour
{
    private int randomTrack;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
}
