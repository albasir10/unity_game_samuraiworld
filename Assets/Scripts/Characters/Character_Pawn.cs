using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Character_Pawn : NetworkBehaviour
{
    // Класс для описания частей тела
    public class BodyPart
    {
        [SyncVar]
        public int health; // Здоровье части тела

        // Конструктор для инициализации здоровья части тела
        public BodyPart(int initialHealth)
        {
            health = initialHealth;
        }
    }
    [Header("Аттрибуты персонажа")]
    public string first_name = "";
    public string second_name = "";
    public int status = 0;
    public int charisma = 0;
    public int strength = 0;
    public int agility = 0;
    public int intelligence = 0;
    public int leadership = 0;
    public int sensitivity = 0;
    public int speed = 5;
    public List<Skill> skills;
    [Header("Части тела персонажа")]
    public BodyPart hands;
    public BodyPart legs;
    public BodyPart head;
    public BodyPart neck;
    public BodyPart torso;
    [Header("Инвентарь персонажа")]
    public List<Item> inventory;
    [Header("Потребности персонажа")]
    [SyncVar]
    public float hungry = 100;
    [SyncVar]
    public float sleep = 100;
    [Header("Задачи персонажа")]
    public string current_task_string;
    public List<Task> tasks = new();
    public Task current_task;
    public TaskListWork work_task = new();
    [Header("О персонаже")]
    public TextMeshProUGUI textmesh_name;
    public GameObject icon_obj;
    [Header("Дом персонаже")]
    public GameObject home_obj;
    [Header("Состояние персонажа")]
    public StateCharacter stateCharacter = new();
    void Update()
    {
        if (isServer)
        {
            UpdateServer();
        }
        CreateTasks();
        work_task.WorkTask(current_task, this);
    }
    public void CreateTasks()
    {
        if (hungry < 40)
        {
            if (tasks.IndexOf(TaskCreateList.eat) == -1)
            {
                Debug.Log("Create Task Eat");
                tasks.Add(TaskCreateList.eat);
                SortTasks();
            }

        }
        if (sleep < 40)
        {
            if (tasks.IndexOf(TaskCreateList.sleep) == -1)
            {
                Debug.Log("Create Task Sleep");
                tasks.Add(TaskCreateList.sleep);
                SortTasks();
            }

        }
    }
    public void SortTasks()
    {
        tasks.Sort((x, y) => y.priority.CompareTo(x.priority));
        current_task = tasks[0];
        current_task_string = tasks[0].name;
    }
    [Server]
    public void UpdateServer()
    {
        if (!stateCharacter.is_eating)
            hungry -= Time.deltaTime;
        if (!stateCharacter.is_sleeping)
            sleep -= Time.deltaTime;
    }
    // Конструктор класса
    public virtual void Move(Vector3 direction)
    {
        // Логика перемещения персонажа в указанном направлении
    }
    // Функция для получения урона в конкретную часть тела
    public virtual void TakeDamage(BodyPart bodyPart, int damage)
    {
        bodyPart.health -= damage;

        if (bodyPart.health <= 0)
        {
            // Часть тела повреждена или уничтожена
            // Здесь можно добавить дополнительную логику, если необходимо
        }
    }

    // Перегруженная функция для получения урона в указанную часть тела по имени
    public virtual void TakeDamage(string bodyPart, int damage)
    {
        switch (bodyPart)
        {
            case "hands":
                TakeDamage(hands, damage);
                break;
            case "legs":
                TakeDamage(legs, damage);
                break;
            case "head":
                TakeDamage(head, damage);
                break;
            case "neck":
                TakeDamage(neck, damage);
                break;
            case "torso":
                TakeDamage(torso, damage);
                break;
            default:
                Debug.Log("Invalid body part");
                break;
        }
    }

    // Функция для получения инвентаря персонажа
    public List<Item> GetInventory()
    {
        return inventory;
    }

    // Дополнительные методы и функциональность
    // ...
}