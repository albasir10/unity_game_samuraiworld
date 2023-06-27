using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string name; // Ќазвание навыка
    public int level; // ”ровень навыка
    public int experience; // ќпыт навыка
    public float maxExperience; // ћаксимальное значение опыта дл€ перехода на следующий уровень

    //  онструктор класса
    public Skill(string name)
    {
        this.name = name;
        this.level = 1;
        this.experience = 0;
        this.maxExperience = CalculateMaxExperience();
    }
    public int GetLevel()
    {
        return level;
    }
    public int GetExperience()
    {
        return experience;
    }
    public void SetExperience(int newExperience)
    {
        experience = newExperience;
    }
    // ћетод дл€ получени€ опыта
    public void GainExperience(int amount)
    {
        experience += amount;

        // ѕроверка, достиг ли навык максимального значени€ опыта дл€ перехода на следующий уровень
        if (experience >= maxExperience)
        {
            LevelUp();
        }
    }

    // ћетод дл€ повышени€ уровн€ навыка
    private void LevelUp()
    {
        level++;
        experience = 0;
        maxExperience = CalculateMaxExperience();

        // ƒополнительные действи€ при повышении уровн€ навыка
    }

    // ћетод дл€ расчета максимального значени€ опыта дл€ перехода на следующий уровень
    private float CalculateMaxExperience()
    {
        // Ћогика расчета максимального значени€ опыта
        return 100 * Mathf.Pow(1.5f, level - 1);
    }
}
