using UnityEngine.UI;

public class Item
{
    public string itemName; // Название предмета
    public ItemType itemType; // Тип предмета
    public int itemValue; // Значение предмета (например, стоимость или сила)
    public Image icon;
    // Конструктор класса
    public Item(string name, ItemType type, int value)
    {
        itemName = name;
        itemType = type;
        itemValue = value;
    }
}

