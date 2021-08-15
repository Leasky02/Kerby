using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpriteRenderer : MonoBehaviour
{
    public Sprite[] ballSprites;
    public SpriteRenderer mySpriteRenderer;
    public GameObject skyColor;

    private Color desertColor = new Color(0.894f, 0.447f, 0.156f);
    private Color lochNessColor = new Color(0.568f, 0.866f, 0.882f);
    private Color suburbsColor = new Color(0.862f, 0.741f, 0.741f);
    private Color himalayasColor = new Color(0.592f, 0.768f, 0.803f);
    private Color rainforestColor = new Color(0.647f, 0.878f, 0.658f);
    private Color newYorkColor = new Color(0.631f, 0.611f, 0.827f);
    private int[] activeSpriteID = new int[12];

    private void Start()
    {
        activeSpriteID[1] = GetComponent<ShopManagerScriptLocations>().IsSelected(1);
        activeSpriteID[2] = GetComponent<ShopManagerScriptLocations>().IsSelected(2);
        activeSpriteID[3] = GetComponent<ShopManagerScriptLocations>().IsSelected(3);
        activeSpriteID[4] = GetComponent<ShopManagerScriptLocations>().IsSelected(4);
        activeSpriteID[5] = GetComponent<ShopManagerScriptLocations>().IsSelected(5);
        activeSpriteID[6] = GetComponent<ShopManagerScriptLocations>().IsSelected(6);

        if (activeSpriteID[1] == 1) //desert
        {
            skyColor.GetComponent<SpriteRenderer>().color = desertColor;
            mySpriteRenderer.sprite = ballSprites[1];
        }
        else if (activeSpriteID[2] == 1) //loch ness 
        {
            skyColor.GetComponent<SpriteRenderer>().color = lochNessColor;
            mySpriteRenderer.sprite = ballSprites[2];
        }
        else if (activeSpriteID[3] == 1) // suburbs
        {
            skyColor.GetComponent<SpriteRenderer>().color = suburbsColor;
            mySpriteRenderer.sprite = ballSprites[3];
        }
        else if (activeSpriteID[4] == 1) // himalayas
        {
            skyColor.GetComponent<SpriteRenderer>().color = himalayasColor;
            mySpriteRenderer.sprite = ballSprites[4];
        }
        else if (activeSpriteID[5] == 1) //rainforest
        {
            skyColor.GetComponent<SpriteRenderer>().color = rainforestColor;
            mySpriteRenderer.sprite = ballSprites[5];
        }
        else if (activeSpriteID[6] == 1) //new york
        {
            skyColor.GetComponent<SpriteRenderer>().color = newYorkColor;
            mySpriteRenderer.sprite = ballSprites[6];
        }
    }
}
