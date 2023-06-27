using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string name; // Название задачи
    public int priority; // Приоритет задачи
    public bool isCompleted; // Флаг завершения задачи

    // Конструктор класса
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

    public bool IsCompleted()
    {
        return isCompleted;
    }

    public void SetCompleted(bool completed)
    {
        isCompleted = completed;
    }
    // Метод для выполнения задачи
    public void CompleteTask()
    {
        // Логика выполнения задачи
        isCompleted = true;
        // Дополнительные действия после выполнения задачи
    }
}
