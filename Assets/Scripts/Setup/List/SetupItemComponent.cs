using UnityEngine;
using UnityEngine.UI;

public class SetupItemComponent : MonoBehaviour
{
    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Button selectButton;

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
        
        ColorBlock colorBlock = selectButton.colors;
        if (GameManager.Instance.IsItemOwned(shopItemKey))
        {
            if (GameManager.Instance.IsItemActive(shopItemKey))
            {
                // turns grey
                colorBlock.disabledColor = new Color(121f / 255f, 121f / 255f, 121f / 255f, 1f);
                selectButton.colors = colorBlock;
                selectButton.interactable = false;
                selectButton.GetComponentInChildren<Text>().text = ("Selected");
            }
            else
            {
                selectButton.interactable = true;
                selectButton.GetComponentInChildren<Text>().text = ("Select");
            }
        }
        else
        {
            // turns red
            colorBlock.disabledColor = new Color(194f / 255f, 12f / 255f, 12f / 255f, 0.5f);
            selectButton.colors = colorBlock;
            selectButton.interactable = false;
            selectButton.GetComponentInChildren<Text>().text = ("Locked");
        }
    }

    public void OnClick()
    {
        if (GameManager.Instance.TrySetActiveItem(shopItemKey))
            UpdateButtonState();
    }

    public void SetTitle(string titleString)
    {
        titleText.text = titleString;
    }

    public void SetImage(Sprite image)
    {
        imageSpriteRenderer.sprite = image;
    }
}
