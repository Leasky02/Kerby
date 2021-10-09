using System.Collections.Generic;
using UnityEngine;

public class ShopItemListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject shopItemTemplate;

    [SerializeField]
    private GameManager.ShopItemType shopItemType;

    void Start()
    {
        List<ShopItem> shopItems = GameManager.Instance.GetShopItemsOfType(shopItemType);
        shopItems.ForEach(delegate(ShopItem item) {
            if (item.showInShop == false)
                return;

            GameObject shopItem = Instantiate(shopItemTemplate) as GameObject;
            
            shopItem.GetComponent<ShopItemComponent>().AssignShopItemKey(item.key);
            shopItem.GetComponent<ShopItemComponent>().SetTitle(item.name);
            shopItem.GetComponent<ShopItemComponent>().SetPrice(item.price);
            shopItem.GetComponent<ShopItemComponent>().SetDescription(item.description);
            shopItem.GetComponent<ShopItemComponent>().SetImage(item.image);

            shopItem.transform.SetParent(shopItemTemplate.transform.parent, false);

            shopItem.SetActive(true);
        });
    }
}
