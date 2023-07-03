using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterAttributes
{
    public string firstName;
    public string secondName;
    public int status;
    public int charisma;
    public int strength;
    public int agility;
    public int intelligence;
    public int leadership;
    public int sensitivity;
    public float speed;
    public List<Skill> skills;
    public bool isAttacked = false;
    public bool isEatting = false;
    public bool isSleeping = false;
    public bool isMoving = false;
    public bool isInBed = false;
    public bool isInHome = false;
    public CharacterAttributes()
    {
        skills = new List<Skill>();
        if (firstName == null)
        {
            speed = 10f;
            CharacterNameLoader loader = new CharacterNameLoader();
            List<string> names = loader.LoadCharacterNames("Data/Character_first_names.txt");
            System.Random random = new System.Random();
            int randomIndex = random.Next(names.Count);
            string randomName = names[randomIndex];
            firstName = randomName;

            names = loader.LoadCharacterNames("Data/Character_second_names.txt");
            randomIndex = random.Next(names.Count);
            randomName = names[randomIndex];
            secondName = randomName;
        }
    }

    // Дополнительные методы и функциональность
    // ...

    // Обновление атрибутов персонажа
    public void UpdateAttributes()
    {
        // Логика обновления атрибутов
        // ...
    }
}