using System.Collections.Generic;

public class CharacterInventory
{
    public List<Item> items;

    public CharacterInventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public bool HasItem(Item item)
    {
        return items.Contains(item);
    }
    // ���������� ��������� ���������
    public void UpdateInventory()
    {
        // ������ ���������� ���������
        // ...
    }
    // �������������� ������ � ����������������
    // ...
}