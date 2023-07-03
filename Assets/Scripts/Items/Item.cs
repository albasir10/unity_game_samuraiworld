using UnityEngine.UI;

public class Item
{
    public string itemName; // �������� ��������
    public ItemType itemType; // ��� ��������
    public int itemValue; // �������� �������� (��������, ��������� ��� ����)
    public Image icon;
    // ����������� ������
    public Item(string name, ItemType type, int value)
    {
        itemName = name;
        itemType = type;
        itemValue = value;
    }
}

