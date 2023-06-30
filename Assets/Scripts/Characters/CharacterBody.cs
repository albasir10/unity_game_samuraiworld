public class CharacterBody
{
    public BodyPart hands;
    public BodyPart legs;
    public BodyPart head;
    public BodyPart neck;
    public BodyPart torso;

    public CharacterBody()
    {
        hands = new BodyPart();
        legs = new BodyPart();
        head = new BodyPart();
        neck = new BodyPart();
        torso = new BodyPart();
    }

    // Дополнительные методы и функциональность
    // ...

    // Обновление состояния тела персонажа
    public void UpdateBodyState()
    {
        // Логика обновления состояния тела
        // ...
    }
}