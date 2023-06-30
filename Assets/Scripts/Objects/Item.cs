public class Item
{
    public string itemName; // Название предмета
    public ItemType itemType; // Тип предмета
    public int itemValue; // Значение предмета (например, стоимость или сила)

    // Конструктор класса
    public Item(string name, ItemType type, int value)
    {
        itemName = name;
        itemType = type;
        itemValue = value;
    }
}

public enum ItemType
{
    Weapon, // Оружие
    Armor, // Броня
    Consumable, // Потребляемый предмет
    Resource // Ресурс
    // Другие типы предметов, если необходимо
}