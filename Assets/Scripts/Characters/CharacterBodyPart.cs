public class CharacterBodyPart
{
    public int health;
    public string namePart;

    public CharacterBodyPart(string name)
    {
        health = 100;
        namePart = name;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // ����� ���� ���������� ��� ����������
            // ����� ����� �������� �������������� ������, ���� ����������
        }
    }
}