using System.Collections.Generic;

public class CharacterTasks
{
    public List<Task> tasks;
    public Task currentTask;

    public CharacterTasks()
    {
        tasks = new List<Task>();
        currentTask = null;
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
        SortTasks();
    }

    public void RemoveTask(Task task)
    {
        tasks.Remove(task);
    }

    public void SortTasks()
    {
        tasks.Sort((x, y) => y.Priority.CompareTo(x.Priority));
    }

    public void CreateTasks(CharacterNeeds needs)
    {
        // ������ �������� ����� ��� ���������

        // ������: ������� ������ ��������, ���� ��������� �������
        if (needs.IsHungry())
        {
            Task eatTask = new Task("Eat", TaskPriority.High);
            AddTask(eatTask);
        }

        // ������: ������� ������ ������, ���� �������� �����
        if (needs.IsTired())
        {
            Task restTask = new Task("Rest", TaskPriority.Medium);
            AddTask(restTask);
        }

        // ������ ������ �������� �����...

        SortTasks();
    }

    public void PerformCurrentTask(Character character)
    {
        if (currentTask != null)
        {
            // ������ ���������� ������� ������ ���������

            // ������: ��������� ������ ��������
            if (currentTask.Name == "Eat")
            {
                character.CmdEat();
            }

            // ������: ��������� ������ ������
            if (currentTask.Name == "Rest")
            {
                character.CmdRest();
            }

            // ������ ������ ���������� �����...

            // ������� ����������� ������
            RemoveTask(currentTask);
        }
    }
}