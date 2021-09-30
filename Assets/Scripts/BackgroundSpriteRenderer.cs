using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpriteRenderer : MonoBehaviour
{
    public SpriteRenderer backgroundSpriteRenderer;
    public GameObject skyGameObject;
    public bool useLocationBackgrounds = true;

    private void Start()
    {
        if (useLocationBackgrounds)
        {
            skyGameObject.GetComponent<SpriteRenderer>().color = GetComponent<ShopManagerScriptLocations>().GetSkyColorForSelectedLocation();
            backgroundSpriteRenderer.sprite = GetComponent<ShopManagerScriptLocations>().GetBackgroundSpriteForSelectedLocation();
        }
        
        ResizeToFitDevice();
    }

    private void ResizeToFitDevice()
    {
        var topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        var worldSpaceWidth = topRightCorner.x * 2;
        var worldSpaceHeight = topRightCorner.y * 2;

        var spriteSize = backgroundSpriteRenderer.bounds.size;

        var scaleFactorX = worldSpaceWidth / spriteSize.x;
        var scaleFactorY = worldSpaceHeight / spriteSize.y;

        // Maintain aspect ratio
        if (scaleFactorX > scaleFactorY)
        {
            scaleFactorY = scaleFactorX;
        }
        else
        {
            scaleFactorX = scaleFactorY;
        }

        backgroundSpriteRenderer.transform.localScale = new Vector3(scaleFactorX, scaleFactorY, 1);
    }
}
