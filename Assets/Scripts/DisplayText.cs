using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public void Announcement(string announcement)
    {
        GetComponent<Text>().text = announcement;
    }
}
