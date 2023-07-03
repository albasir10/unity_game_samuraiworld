public class CharacterIdleState : CharacterState
{
    public CharacterIdleState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // Логика входа в состояние "покой"
        // Например, остановка персонажа
    }

    public override void ExitState()
    {
        // Логика выхода из состояния "покой"
        // Например, возобновление движения персонажа
    }

}