using UnityEngine;

public class ShopItem
{
    public string name;
    public string key;
    public int price;
    public string description;
    public Sprite image;
    public bool showInShop;
    public int availableAtRank;

    private ShopItem(string _name, string _key, int _price, string _description, string imagePath, bool _showInShop, int _rank)
    {
        name = _name;
        key = _key;
        price = _price;
        description = _description;
        image = Resources.Load<Sprite>(imagePath);
        showInShop = _showInShop;
        availableAtRank = _rank;
    }
    
    public static ShopItem CreateBallSkinItem(string name, string key, int price, int rank, string description, string imagePath)
    {
        return new ShopItem(name, key, price, description, imagePath, true, rank);
    }
    
    public static ShopItem CreateLocationItem(string name, string key, int price, string imagePath, bool showInShop)
    {
        string description = "";
        return new ShopItem(name, key, price, description, imagePath, showInShop, 0);
    }
    
    public static ShopItem CreateMiniGameItem(string name, string key, int price, string description, string imagePath)
    {
        return new ShopItem(name, key, price, description, imagePath, true, 0);
    }

    public static ShopItem CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ShopItem>(jsonString);
    }

    /*
        Given JSON input:
        
        {
            "name": "Double Kerb",
            "key": "miniGames2"
            "price": 350,
            "description": "Hit both kerbs and win big!"
        }
    
        this example will return a ShopItem object with
        name == "Double Kerb", key == "miniGames2", price = 350, and description == "Hit both kerbs and win big!".
    */
}