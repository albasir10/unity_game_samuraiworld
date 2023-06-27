using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop
{
    public string name; // �������� ��������
    public int growthStage; // ������ ����� ��������
    public int maxGrowthStage; // ������������ ������ ����� ��������

    // ����������� ������
    public Crop(string name)
    {
        this.name = name;
        this.growthStage = 0;
        this.maxGrowthStage = 3; // ������: 3 ������ �����
    }

    // ����� ��� ����������� �������� �� ��������� ������ �����
    public void Grow()
    {
        if (growthStage < maxGrowthStage)
        {
            growthStage++;

            // �������������� �������� ��� �������� �������� �� ��������� ������ �����
        }
    }

    // ����� ��� ����� ������
    public void Harvest()
    {
        // ������ ����� ������
    }
}
