using UnityEngine;
using UnityEngine.UI;

public class ShopItemComponent : MonoBehaviour
{
    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Text descriptionText;

    [SerializeField]
    private Text priceText;

    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private SpriteRenderer imageSpriteRenderer;

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
        if (GameManager.Instance.IsItemOwned(shopItemKey))
        {
            // turns grey
            colorBlock.disabledColor = new Color(121f / 255f, 121f / 255f, 121f / 255f, 1f);
            buyButton.colors = colorBlock;
            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = ("Owned");
        }
        else if (GameManager.Instance.IsItemAvailableToBuy(shopItemKey) == false)
        {
            // turns red
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
        if (GameManager.Instance.TryBuyItemWithCoins(shopItemKey))
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

    public void SetRank(int rankInt)
    {
        priceText.text = "Rank " + rankInt.ToString();
    }

    public void SetDescription(string descriptionString)
    {
        if (descriptionText && descriptionString.Length > 0)
            descriptionText.text = descriptionString;
    }

    public void SetImage(Sprite image)
    {
        imageSpriteRenderer.sprite = image;
    }
}
