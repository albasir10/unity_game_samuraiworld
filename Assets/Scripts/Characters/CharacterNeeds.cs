using UnityEngine;

public class CharacterNeeds
{
    public float hunger;
    public float sleep;
    public float hungerDecreaseRate; // �������� ���������� ������
    public float sleepDecreaseRate; // �������� ���������� ���
    public float hungerThreshold; // ����� ���
    public float sleepThreshold; // ����� ���
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
        // ���������� �������� ������������ � ������������ � ������� ����
        DecreaseHunger();
        DecreaseSleep();

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

    public void Eat()
    {
        // ������ �������� ���
        // ...
    }

    public void Rest()
    {
        // ������ ������
        // ...
    }
    // �������������� ������ � ����������������
    // ...
}