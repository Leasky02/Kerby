using System.Collections.Generic;
using UnityEngine;

public class SetupItemListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject setupItemTemplate;

    [SerializeField]
    private GameManager.ShopItemType setupItemType;

    void Start()
    {
        List<ShopItem> shopItems = GameManager.Instance.GetShopItemsOfType(setupItemType);

        // We want standard coloured ball skins to appear first in the set up scenes,
        shopItems.Sort(SortByIsRankedUnlock);

        shopItems.ForEach(delegate(ShopItem item) {
            GameObject setupItem = Instantiate(setupItemTemplate) as GameObject;
            
            setupItem.GetComponent<SetupItemComponent>().AssignShopItemKey(item.key);
            setupItem.GetComponent<SetupItemComponent>().SetTitle(item.name);
            setupItem.GetComponent<SetupItemComponent>().SetImage(item.image);

            setupItem.transform.SetParent(setupItemTemplate.transform.parent, false);

            setupItem.SetActive(true);
        });
    }

    static int SortByIsRankedUnlock(ShopItem item1, ShopItem item2)
    {
        bool item1UnlocksWithRank = item1.availableAtRank > 0;
        bool item2UnlocksWithRank = item2.availableAtRank > 0;
        if (item1UnlocksWithRank && item2UnlocksWithRank)
            return 0;
        return item1UnlocksWithRank ? -1 : 1;
    }
}
