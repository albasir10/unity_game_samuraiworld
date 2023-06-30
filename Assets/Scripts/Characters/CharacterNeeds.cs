using UnityEngine;

public class CharacterNeeds
{
    public float hunger;
    public float sleep;
    public float hungerDecreaseRate; // Скорость уменьшения голода
    public float sleepDecreaseRate; // Скорость уменьшения сна
    public float hungerThreshold; // порог еды
    public float sleepThreshold; // порог сна
    public CharacterNeeds(float initialHunger, float initialSleep, float hungerRate, float sleepRate, float hungerThreshold, float sleepThreshold)
    {
        hunger = initialHunger;
        sleep = initialSleep;
        hungerDecreaseRate = hungerRate;
        sleepDecreaseRate = sleepRate;
        this.hungerThreshold = hungerThreshold;
        this.sleepThreshold = sleepThreshold;
    }

    public void UpdateNeeds()
    {
        // Обновление значений потребностей в соответствии с логикой игры
        DecreaseHunger();
        DecreaseSleep();

        // Проверка других потребностей и выполнение соответствующих действий
        // ...
    }

    public void DecreaseHunger()
    {
        hunger -= hungerDecreaseRate * Time.deltaTime;
        if (hunger < 0)
            hunger = 0;
    }

    public void DecreaseSleep()
    {
        sleep -= sleepDecreaseRate * Time.deltaTime;
        if (sleep < 0)
            sleep = 0;
    }
    public bool IsHungry()
    {
        return hunger < hungerThreshold;
    }

    public bool IsTired()
    {
        return sleep < sleepThreshold;
    }

    public void Eat()
    {
        // Логика поедания еды
        // ...
    }

    public void Rest()
    {
        // Логика отдыха
        // ...
    }
    // Дополнительные методы и функциональность
    // ...
}