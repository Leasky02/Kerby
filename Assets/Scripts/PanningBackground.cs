using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningBackground : MonoBehaviour
{
    float scrollSpeed = -0.1f;
    Vector2 startPos;
    float width;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 17.77f);
        transform.position = startPos + Vector2.right * newPos;

    }
}
