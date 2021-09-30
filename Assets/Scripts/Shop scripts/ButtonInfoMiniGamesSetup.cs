using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfoMiniGamesSetup : MonoBehaviour
{
    public int itemID;
    public GameObject shopManager;

    private void Start()
    {
        var newColorBlock = GetComponent<Button>().colors;
        //has it been bought?
        if (shopManager.GetComponent<ShopManagerScriptMiniGames>().IsItemAvailable(itemID))
        {
                GetComponent<Button>().interactable = true;
        }
        //if it hasnt been bought...
        else if (shopManager.GetComponent<ShopManagerScriptMiniGames>().IsItemAvailable(itemID) == false)
        {
            //turns red
            newColorBlock.disabledColor = new Color(194f / 255f, 12f / 255f, 12f / 255f, 0.5f);
            GetComponent<Button>().colors = newColorBlock;
            GetComponent<Button>().interactable = false;
            GetComponentInChildren<Text>().text = ("Locked");
        }
    }
}
