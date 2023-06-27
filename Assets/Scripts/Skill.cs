using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string name; // �������� ������
    public int level; // ������� ������
    public int experience; // ���� ������
    public float maxExperience; // ������������ �������� ����� ��� �������� �� ��������� �������

    // ����������� ������
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
    // ����� ��� ��������� �����
    public void GainExperience(int amount)
    {
        experience += amount;

        // ��������, ������ �� ����� ������������� �������� ����� ��� �������� �� ��������� �������
        if (experience >= maxExperience)
        {
            LevelUp();
        }
    }

    // ����� ��� ��������� ������ ������
    private void LevelUp()
    {
        level++;
        experience = 0;
        maxExperience = CalculateMaxExperience();

        // �������������� �������� ��� ��������� ������ ������
    }

    // ����� ��� ������� ������������� �������� ����� ��� �������� �� ��������� �������
    private float CalculateMaxExperience()
    {
        // ������ ������� ������������� �������� �����
        return 100 * Mathf.Pow(1.5f, level - 1);
    }
}
