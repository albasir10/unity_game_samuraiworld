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
        // Логика создания задач для персонажа

        // Пример: создаем задачу поедания, если персонажу голодно
        if (needs.IsHungry())
        {
            Task eatTask = new Task("Eat", TaskPriority.High);
            AddTask(eatTask);
        }

        // Пример: создаем задачу отдыха, если персонаж устал
        if (needs.IsTired())
        {
            Task restTask = new Task("Rest", TaskPriority.Medium);
            AddTask(restTask);
        }

        // Другие логики создания задач...

        SortTasks();
    }

    public void PerformCurrentTask(Character character)
    {
        if (currentTask != null)
        {
            // Логика выполнения текущей задачи персонажа

            // Пример: выполняем задачу поедания
            if (currentTask.Name == "Eat")
            {
                character.CmdEat();
            }

            // Пример: выполняем задачу отдыха
            if (currentTask.Name == "Rest")
            {
                character.CmdRest();
            }

            // Другие логики выполнения задач...

            // Удаляем выполненную задачу
            RemoveTask(currentTask);
        }
    }
}