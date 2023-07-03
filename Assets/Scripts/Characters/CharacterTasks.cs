using System.Collections.Generic;
using UnityEngine;

public class CharacterTasks
{
    public List<Task> tasksList;
    public Task currentTask;
    public Character character;
    public CharacterTasks(Character character)
    {
        tasksList = new List<Task>();
        currentTask = null;
        this.character = character;
        tasksList.Add(TaskList.idle);
    }
    public string GetTasksNames()
    {
        string tasksNames = "";
        foreach (Task task in tasksList)
        {
            tasksNames += task.Name + " ";
        }
        return tasksNames;
    }
    public void AddTask(Task task)
    {
        tasksList.Add(task);
        SortTasks();
    }
    public void AddTask(Task task, Vector2 destination)
    {
        task.destination = destination;
        tasksList.Add(task);
        SortTasks();
    }
    public void RemoveTask(Task task)
    {
        tasksList.Remove(task);
    }

    public void SortTasks()
    {
        tasksList.Sort((x, y) => y.Priority.CompareTo(x.Priority));
        currentTask = tasksList[0];
    }

    public void CreateTasks(CharacterNeeds needs)
    {
        // Логика создания задач для персонажа

        if (needs.IsTired() ) // сонливый
        {
            if (tasksList.IndexOf(TaskList.sleep) == -1)
            {
                AddTask(TaskList.sleep);
            }
        }
        if (needs.IsHungry()) // голодный
        {
            if (tasksList.IndexOf(TaskList.eat) == -1)
            {
                AddTask(TaskList.eat);
            }
        }



        CheckNeedMovingToTask();
        SortTasks();
    }

    public void CheckNeedMovingToTask()
    {
        if (currentTask == TaskList.sleep)
        {
            if (!character.attributes.isInHome)
            {
                AddTask(TaskList.move, character.home.transform.position);
            }
            else if (!character.attributes.isInBed)
            {
                AddTask(TaskList.move, character.bed.transform.position);
            }
            else
            {

            }
        }
        else if (currentTask == TaskList.eat)
        {
            //AddTask(TaskList.move);
        }
    }
}