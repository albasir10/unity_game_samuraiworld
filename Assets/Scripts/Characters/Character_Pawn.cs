using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    // Атрибуты персонажа
    public string first_name;
    public string second_name;
    public int status;
    public int charisma;
    public int strength;
    public int agility;
    public int intelligence;
    public int leadership;
    public int sensitivity;

    // Части тела персонажа
    public BodyPart hands;
    public BodyPart legs;
    public BodyPart head;
    public BodyPart neck;
    public BodyPart torso;

    public List<Item> inventory;
    public List<Task> tasks;
    public List<Skill> skills;

    public TextMeshProUGUI textmesh_name;
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