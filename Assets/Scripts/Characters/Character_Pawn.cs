using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    // �������� ���������
    public string first_name;
    public string second_name;
    public int status;
    public int charisma;
    public int strength;
    public int agility;
    public int intelligence;
    public int leadership;
    public int sensitivity;

    // ����� ���� ���������
    public BodyPart hands;
    public BodyPart legs;
    public BodyPart head;
    public BodyPart neck;
    public BodyPart torso;

    public List<Item> inventory;
    public List<Task> tasks;
    public List<Skill> skills;

    public TextMeshProUGUI textmesh_name;
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