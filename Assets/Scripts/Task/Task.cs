using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string name; // �������� ������
    public int priority; // ��������� ������
    public bool isCompleted; // ���� ���������� ������

    // ����������� ������
    public Task(string name, int priority)
    {
        this.name = name;
        this.priority = priority;
        this.isCompleted = false;
    }
    public int GetPriority()
    {
        return priority;
    }

}
