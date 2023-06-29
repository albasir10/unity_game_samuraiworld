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
    // ����� ��� �������� ������ ����
    public class BodyPart
    {
        [SyncVar]
        public int health; // �������� ����� ����

        // ����������� ��� ������������� �������� ����� ����
        public BodyPart(int initialHealth)
        {
            health = initialHealth;
        }
    }
    [Header("��������� ���������")]
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
    [Header("����� ���� ���������")]
    public BodyPart hands;
    public BodyPart legs;
    public BodyPart head;
    public BodyPart neck;
    public BodyPart torso;
    [Header("��������� ���������")]
    public List<Item> inventory;
    [Header("����������� ���������")]
    [SyncVar]
    public float hungry = 100;
    [SyncVar]
    public float sleep = 100;
    [Header("������ ���������")]
    public string current_task_string;
    public List<Task> tasks = new();
    public Task current_task;
    public TaskListWork work_task = new();
    [Header("� ���������")]
    public TextMeshProUGUI textmesh_name;
    public GameObject icon_obj;
    [Header("��� ���������")]
    public GameObject home_obj;
    [Header("��������� ���������")]
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
    // ����������� ������
    public virtual void Move(Vector3 direction)
    {
        // ������ ����������� ��������� � ��������� �����������
    }
    // ������� ��� ��������� ����� � ���������� ����� ����
    public virtual void TakeDamage(BodyPart bodyPart, int damage)
    {
        bodyPart.health -= damage;

        if (bodyPart.health <= 0)
        {
            // ����� ���� ���������� ��� ����������
            // ����� ����� �������� �������������� ������, ���� ����������
        }
    }

    // ������������� ������� ��� ��������� ����� � ��������� ����� ���� �� �����
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

    // ������� ��� ��������� ��������� ���������
    public List<Item> GetInventory()
    {
        return inventory;
    }

    // �������������� ������ � ����������������
    // ...
}