using UnityEngine;

public class Task
{
    public string Name { get; }
    public TaskPriority Priority { get; }
    public bool IsCompleted { get; private set; }
    public Vector2 destination { get; set; }
    public Task(string name, TaskPriority priority)
    {
        Name = name;
        Priority = priority;
        IsCompleted = false;
    }
    public Task(string name, TaskPriority priority, Vector2 destination)
    {
        Name = name;
        Priority = priority;
        IsCompleted = false;
        this.destination = destination;
    }
    public void PerformTask()
    {
        // Логика выполнения задачи

        IsCompleted = true;
    }
}