﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfoLocationsSetup : MonoBehaviour
{
    public int itemID;
    public GameObject shopManager;

    private void Start()
    {
        var newColorBlock = GetComponent<Button>().colors;
        //has it been bought?
        if (shopManager.GetComponent<ShopManagerScriptLocations>().GetItemAvailability(itemID) == 1)
        {
            //if so, has it been selected?
            if (shopManager.GetComponent<ShopManagerScriptLocations>().IsSelected(itemID) == 1)
            {
                //turns grey
                newColorBlock.disabledColor = new Color(121f / 255f, 121f / 255f, 121f / 255f, 1f);
                GetComponent<Button>().colors = newColorBlock;
                GetComponent<Button>().interactable = false;
            }
            else
            {
                //if not then its available
                GetComponent<Button>().interactable = true;
            }
        }
        //if it hasnt been bought...
        else if (shopManager.GetComponent<ShopManagerScriptLocations>().GetItemAvailability(itemID) == 0)
        {
            //turns red
            newColorBlock.disabledColor = new Color(194f / 255f, 12f / 255f, 12f / 255f, 0.5f);
            GetComponent<Button>().colors = newColorBlock;
            GetComponent<Button>().interactable = false;
        }
    }
    void Update()
    {
        var newColorBlock = GetComponent<Button>().colors;
        //has it been bought?
        if (shopManager.GetComponent<ShopManagerScriptLocations>().GetItemAvailability(itemID) == 1)
        {
            //if so, has it been selected?
            if (shopManager.GetComponent<ShopManagerScriptLocations>().IsSelected(itemID) == 1)
            {
                //turns grey
                newColorBlock.disabledColor = new Color(121f / 255f, 121f / 255f, 121f / 255f, 1f);
                GetComponent<Button>().colors = newColorBlock;
                GetComponent<Button>().interactable = false;
            }
            else
            {
                //if not then its available
                GetComponent<Button>().interactable = true;
            }
        }
        //if it hasnt been bought...
        else if (shopManager.GetComponent<ShopManagerScriptLocations>().GetItemAvailability(itemID) == 0)
        {
            //turns red
            newColorBlock.disabledColor = new Color(194f / 255f, 12f / 255f, 12f / 255f, 0.5f);
            GetComponent<Button>().colors = newColorBlock;
            GetComponent<Button>().interactable = false;
        }
    }
}
