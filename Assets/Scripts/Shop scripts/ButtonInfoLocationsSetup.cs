using UnityEngine;
using UnityEngine.UI;

public class ButtonInfoLocationsSetup : MonoBehaviour
{
    [SerializeField] private string locationID;

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
        ColorBlock newColorBlock = GetComponent<Button>().colors;
        if (GameManager.Instance.GetLocationsShopManager().IsItemAvailable(locationID))
        {
            if (GameManager.Instance.GetLocationsShopManager().GetActiveItem().key == locationID)
            {
                // turns grey
                newColorBlock.disabledColor = new Color(121f / 255f, 121f / 255f, 121f / 255f, 1f);
                GetComponent<Button>().colors = newColorBlock;
                GetComponent<Button>().interactable = false;
                GetComponentInChildren<Text>().text = ("Selected");
            }
            else
            {
                GetComponent<Button>().interactable = true;
                GetComponentInChildren<Text>().text = ("Select");
            }
        }
        else
        {
            // turns red
            newColorBlock.disabledColor = new Color(194f / 255f, 12f / 255f, 12f / 255f, 0.5f);
            GetComponent<Button>().colors = newColorBlock;
            GetComponent<Button>().interactable = false;
            GetComponentInChildren<Text>().text = ("Locked");
        }
    }
}
