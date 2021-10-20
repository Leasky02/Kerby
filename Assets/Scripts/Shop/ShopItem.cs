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
        int _availableAtRank = 0;
        return new ShopItem(name, key, price, description, imagePath, showInShop, _availableAtRank);
    }
    
    public static ShopItem CreateMiniGameItem(string name, string key, int price, string description, string imagePath)
    {
        bool _showInShop = true;
        int _availableAtRank = 0;
        return new ShopItem(name, key, price, description, imagePath, _showInShop, _availableAtRank);
    }
}