public class Item
{
    public string itemName; // �������� ��������
    public ItemType itemType; // ��� ��������
    public int itemValue; // �������� �������� (��������, ��������� ��� ����)

    // ����������� ������
    public Item(string name, ItemType type, int value)
    {
        itemName = name;
        itemType = type;
        itemValue = value;
    }
}

public enum ItemType
{
    Weapon, // ������
    Armor, // �����
    Consumable, // ������������ �������
    Resource // ������
    // ������ ���� ���������, ���� ����������
}