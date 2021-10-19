using UnityEngine;

public class ButtonInfoSetup : MonoBehaviour
{
    public int itemID;
    public GameObject shopManager;

    private void Start()
    {
        UpdateButtonTextAndColor();
    }

    private void Update()
    {
        UpdateButtonTextAndColor();
    }

    private void UpdateButtonTextAndColor()
    {
        // var newColorBlock = GetComponent<Button>().colors;
        // //has it been bought?
        // if (shopManager.GetComponent<ShopManagerBallSkins>().IsItemAvailable(itemID))
        // {
        //     //if so, has it been selected?
        //     if (shopManager.GetComponent<ShopManagerBallSkins>().IsSelected(itemID))
        //     {
        //         //turns grey
        //         newColorBlock.disabledColor = new Color(121f / 255f, 121f / 255f, 121f / 255f, 1f);
        //         GetComponent<Button>().colors = newColorBlock;
        //         GetComponent<Button>().interactable = false;
        //         GetComponentInChildren<Text>().text = ("Selected");
        //     }
        //     else
        //     {
        //         //if not then its available
        //         GetComponent<Button>().interactable = true;
        //         GetComponentInChildren<Text>().text = ("Select");
        //     }
        // }
        // //if it hasnt been bought...
        // else
        // {
        //     //turns red
        //     newColorBlock.disabledColor = new Color(194f / 255f, 12f / 255f, 12f / 255f, 0.5f);
        //     GetComponent<Button>().colors = newColorBlock;
        //     GetComponent<Button>().interactable = false;
        //     GetComponentInChildren<Text>().text = ("Locked");
        // }
    }
}
