using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Peasant : Character_Pawn
{
    // �������������� �������� �����������
    public int farmingLevel;
    public int craftsmanshipLevel;

    // ������� � ������������
    public int resources;

    // ������� � ������



    // �������������� � ���������� �����
    public void PlantCrop(Crop crop)
    {
        // ���������� ������ �������
    }

    public void HarvestCrop(Crop crop)
    {
        // ���������� ����� ������
    }

    // ������� �� ��������� � ��������
    public void TradeWithMerchant(Merchant merchant)
    {
        // ���������� �������� � ���������
    }

    public void SocializeWithPeasant(Peasant otherPeasant)
    {
        // ���������� �������������� � ������� �����������
    }

    // �������� � ����������
    public void LevelUpFarming()
    {
        farmingLevel++;
        // ��������� ������ ������ � �������� ���������
    }

    public void LevelUpCraftsmanship()
    {
        craftsmanshipLevel++;
        // ��������� ������ ������ � ����������� ����
    }

    // �������������� ������ � ���������������� ��� �����������
}
