using static UnityEditor.Progress;
using UnityEngine;

public class Player : Character_Pawn
{

    // ����� ��� ����������� ������
    public override void Move(Vector3 direction)
    {
        base.Move(direction);
        // ������ ����������� ������ � ��������� �����������
    }

    // ����� ��� ���������� ������
    public void PerformTask(Task task)
    {
        // ������ ���������� ������ �������
    }

    // ����� ��� �������������� � �������� � ���������� �����
    public void InteractWithObject(GameObject targetObject)
    {
        // ������ �������������� ������ � ��������
    }

    // ����� ��� ������������� �������� �� ���������
    public void UseItem(Item item)
    {
        // ������ ������������� �������� �������
    }

    // ����� ��� ������ ���������� � ������ ������� ��� NPC
    public void TradeWith(Character_Pawn character, Item playerItem, Item characterItem)
    {
        // ������ ������ ���������� ����� ������� � ������ ����������
    }

    // �������������� ������ � ���������������� ��� ������ Player
    // ...
}