using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public string objectTag;
    //allows the same music to play continuously between scenes and allows only 1 to exist
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objectTag);
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

}
