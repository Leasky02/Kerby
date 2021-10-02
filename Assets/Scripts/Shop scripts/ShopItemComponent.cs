using UnityEngine;
using UnityEngine.UI;

public class ShopItemComponent : MonoBehaviour
{
    [SerializeField]
    private IShopManager shopManager;

    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Text descriptionText;

    [SerializeField]
    private Text priceText;

    [SerializeField]
    private Button buyButton;

    private string shopItemKey = null;

    public void AssignShopItemKey(string key)
    {
        shopItemKey = key;
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        if (shopItemKey == null)
            return;
        
        ColorBlock colorBlock = buyButton.colors;
        if (shopManager.IsItemAvailable(shopItemKey))
        {
            colorBlock.disabledColor = new Color(121f / 255f, 121f / 255f, 121f / 255f, 1f);
            buyButton.colors = colorBlock;
            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = ("Owned");
        }
        else if (shopManager.CanBuyWithCoins(shopItemKey) == false)
        {
            colorBlock.disabledColor = new Color(194f / 255f, 12f / 255f, 12f / 255f, 0.5f);
            buyButton.colors = colorBlock;
            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = ("Locked");
        }
        else
        {
            buyButton.interactable = true;
            buyButton.GetComponentInChildren<Text>().text = ("Buy");
        }
    }

    public void OnClick()
    {
        if (shopManager.TryBuyWithCoins(shopItemKey))
            UpdateButtonState();
    }

    public void SetTitle(string titleString)
    {
        titleText.text = titleString;
    }

    public void SetPrice(int priceInt)
    {
        priceText.text = priceInt.ToString();
    }

    public void SetDescription(string descriptionString)
    {
        descriptionText.text = descriptionString;
    }

    public void SetImage()
    {

    }
}
