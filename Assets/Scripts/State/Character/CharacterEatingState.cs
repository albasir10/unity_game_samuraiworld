public class CharacterEatingState : CharacterState
{
    public CharacterEatingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // Логика входа в состояние "поедание"
        // Например, начало анимации поедания еды
        if (IsCanEat())
        {

        }
        else
        {
            
        }
    }

    public override void ExitState()
    {
        // Логика выхода из состояния "поедание"
        // Например, завершение анимации поедания еды
    }
    public bool IsCanEat()
    {

        return false;
    }
}