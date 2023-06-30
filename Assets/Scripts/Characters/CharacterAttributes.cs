using System.Collections.Generic;

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
    public int speed;
    public List<Skill> skills;

    public CharacterAttributes()
    {
        skills = new List<Skill>();
    }

    // �������������� ������ � ����������������
    // ...

    // ���������� ��������� ���������
    public void UpdateAttributes()
    {
        // ������ ���������� ���������
        // ...
    }
}