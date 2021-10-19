using UnityEngine;
using UnityEngine.UI;

public class ButtonInfoMiniGamesSetup : MonoBehaviour
{
    [SerializeField] private string miniGameID;

    private void Start()
    {
        UpdateButtonTextAndColor();
    }

    private void UpdateButtonTextAndColor()
    {
        ColorBlock newColorBlock = GetComponent<Button>().colors;
        if (GameManager.Instance.GetMiniGamesShopManager().IsItemAvailable(miniGameID))
        {
            GetComponent<Button>().interactable = true;
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
