using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Merchant : Character_Pawn
{
     // ��������� ��������

    public void SetInventory(List<Item> newInventory)
    {
        inventory = newInventory;
    }
    // ����� ��� ���������� �������� � ��������� ��������
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    // ����� ��� �������� �������� �� ��������� ��������
    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
    }

    // ����� ��� ������ ���������� � ������ NPC ��� �������
    public void TradeWith(Character_Pawn character, Item merchantItem, Item characterItem)
    {
        // ������ ������ ���������� ����� ��������� � ������ NPC ��� �������
        if (inventory.Contains(merchantItem) && character.GetInventory().Contains(characterItem))
        {
            // ������ ������ ���������� ����� ��������� � ������ NPC ��� �������
            inventory.Remove(merchantItem);
            character.GetInventory().Remove(characterItem);
            inventory.Add(characterItem);
            character.GetInventory().Add(merchantItem);
        }
        else
        {
            Debug.Log("Trade items not found");
        }
    }
}
