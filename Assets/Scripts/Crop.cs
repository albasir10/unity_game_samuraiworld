using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop
{
    public string name; // Название культуры
    public int growthStage; // Стадия роста культуры
    public int maxGrowthStage; // Максимальная стадия роста культуры

    // Конструктор класса
    public Crop(string name)
    {
        this.name = name;
        this.growthStage = 0;
        this.maxGrowthStage = 3; // Пример: 3 стадии роста
    }

    // Метод для продвижения культуры на следующую стадию роста
    public void Grow()
    {
        if (growthStage < maxGrowthStage)
        {
            growthStage++;

            // Дополнительные действия при переходе культуры на следующую стадию роста
        }
    }

    // Метод для сбора урожая
    public void Harvest()
    {
        // Логика сбора урожая
    }
}
