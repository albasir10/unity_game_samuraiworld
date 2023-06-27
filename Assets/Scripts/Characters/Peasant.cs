using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Peasant : Character_Pawn
{
    // Дополнительные атрибуты крестьянина
    public int farmingLevel;
    public int craftsmanshipLevel;

    // Ресурсы и производство
    public int resources;

    // Задания и навыки



    // Взаимодействие с окружающим миром
    public void PlantCrop(Crop crop)
    {
        // Реализация посева культур
    }

    public void HarvestCrop(Crop crop)
    {
        // Реализация сбора урожая
    }

    // Влияние на экономику и общество
    public void TradeWithMerchant(Merchant merchant)
    {
        // Реализация торговли с торговцем
    }

    public void SocializeWithPeasant(Peasant otherPeasant)
    {
        // Реализация взаимодействия с другими крестьянами
    }

    // Развитие и прогрессия
    public void LevelUpFarming()
    {
        farmingLevel++;
        // Повышение уровня навыка в сельском хозяйстве
    }

    public void LevelUpCraftsmanship()
    {
        craftsmanshipLevel++;
        // Повышение уровня навыка в ремесленном деле
    }

    // Дополнительные методы и функциональность для крестьянина
}
