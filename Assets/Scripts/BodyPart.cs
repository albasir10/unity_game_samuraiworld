public class BodyPart
{
    public int health;

    public BodyPart()
    {
        health = 100;
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