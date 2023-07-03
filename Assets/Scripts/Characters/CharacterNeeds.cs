using UnityEngine;

public class CharacterNeeds
{
    public float hunger;
    public float sleep;
    public float hungerDecreaseRate; // �������� ���������� ������
    public float sleepDecreaseRate; // �������� ���������� ���
    public float hungerThreshold; // ����� ���
    public float sleepThreshold; // ����� ���
    public Character character;
    public CharacterNeeds(Character character, float initialHunger, float initialSleep, float hungerRate, float sleepRate, float hungerThreshold, float sleepThreshold)
    {
        hunger = initialHunger;
        sleep = initialSleep;
        hungerDecreaseRate = hungerRate;
        sleepDecreaseRate = sleepRate;
        this.hungerThreshold = hungerThreshold;
        this.sleepThreshold = sleepThreshold;
        this.character = character;
    }

    public void UpdateNeeds()
    {
        // ���������� �������� ������������ � ������������ � ������� ����
        if (!character.attributes.isSleeping)
            DecreaseSleep();
        if (!character.attributes.isEatting)
            DecreaseHunger();
            

        // �������� ������ ������������ � ���������� ��������������� ��������
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
    public void IncreaseSleep()
    {
        sleep += sleepDecreaseRate * Time.deltaTime;
        if (sleep > 100)
            sleep = 100;
    }
    public void IncreaseHunger()
    {
        hunger += hungerDecreaseRate * Time.deltaTime;
        if (hunger >= 100)
            hunger = 100;
    }
}