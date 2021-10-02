using UnityEngine;

public class ShopItem
{
    public string name;
    public string key;
    public int price;
    public string description;

    public ShopItem(string _name, string _key, int _price, string _description)
    {
        name = _name;
        key = _key;
        price = _price;
        description = _description;
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