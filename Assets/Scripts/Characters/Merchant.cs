using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Merchant : Character_Pawn
{
     // Инвентарь торговца

    public void SetInventory(List<Item> newInventory)
    {
        inventory = newInventory;
    }
    // Метод для добавления предмета в инвентарь торговца
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    // Метод для удаления предмета из инвентаря торговца
    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
    }

    // Метод для обмена предметами с другим NPC или игроком
    public void TradeWith(Character_Pawn character, Item merchantItem, Item characterItem)
    {
        // Логика обмена предметами между торговцем и другим NPC или игроком
        if (inventory.Contains(merchantItem) && character.GetInventory().Contains(characterItem))
        {
            // Логика обмена предметами между торговцем и другим NPC или игроком
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
