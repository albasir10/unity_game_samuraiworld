public class CharacterBody
{
    public CharacterBodyPart hands;
    public CharacterBodyPart legs;
    public CharacterBodyPart head;
    public CharacterBodyPart neck;
    public CharacterBodyPart torso;

    public CharacterBody()
    {
        hands = new CharacterBodyPart("hands");
        legs = new CharacterBodyPart("legs");
        head = new CharacterBodyPart("head");
        neck = new CharacterBodyPart("neck");
        torso = new CharacterBodyPart("torso");
    }

    // �������������� ������ � ����������������
    // ...

    // ���������� ��������� ���� ���������
    public void UpdateBodyState()
    {
        // ������ ���������� ��������� ����
        // ...
    }
}