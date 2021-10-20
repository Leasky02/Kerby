using System.Collections.Generic;
using UnityEngine;

public class ShopItemListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject shopItemTemplate;

    [SerializeField]
    private GameObject shopItemRankedTemplate;

    [SerializeField]
    private GameManager.ShopItemType shopItemType;

    void Start()
    {
        List<ShopItem> shopItems = GameManager.Instance.GetShopItemsOfType(shopItemType);
        shopItems.ForEach(delegate(ShopItem item) {
            if (item.showInShop == false)
                return;

            bool itemUnlocksWithRank = (item.availableAtRank > 0);

            GameObject shopItem = itemUnlocksWithRank ? Instantiate(shopItemRankedTemplate) as GameObject : Instantiate(shopItemTemplate) as GameObject;
            
            shopItem.GetComponent<ShopItemComponent>().AssignShopItemKey(item.key);
            shopItem.GetComponent<ShopItemComponent>().SetTitle(item.name);
            shopItem.GetComponent<ShopItemComponent>().SetDescription(item.description);
            shopItem.GetComponent<ShopItemComponent>().SetImage(item.image);

            if (itemUnlocksWithRank)
                shopItem.GetComponent<ShopItemComponent>().SetRank(item.availableAtRank);
            else
                shopItem.GetComponent<ShopItemComponent>().SetPrice(item.price);

            shopItem.transform.SetParent(shopItemTemplate.transform.parent, false);

            shopItem.SetActive(true);
        });
    }
}
