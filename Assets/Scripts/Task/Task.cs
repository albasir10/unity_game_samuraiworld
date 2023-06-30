public class Task
{
    public string Name { get; }
    public TaskPriority Priority { get; }
    public bool IsCompleted { get; private set; }

    public Task(string name, TaskPriority priority)
    {
        Name = name;
        Priority = priority;
        IsCompleted = false;
    }

    public void PerformTask()
    {
        // Логика выполнения задачи

        IsCompleted = true;
    }
}