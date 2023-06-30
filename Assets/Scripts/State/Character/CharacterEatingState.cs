public class CharacterEatingState : CharacterState
{
    public CharacterEatingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // Логика входа в состояние "поедание"
        // Например, начало анимации поедания еды
        stateManager.character.CmdEat();
    }

    public override void ExitState()
    {
        // Логика выхода из состояния "поедание"
        // Например, завершение анимации поедания еды
    }

    public override void UpdateState()
    {
        // Логика обновления состояния "поедание"
        // Например, проверка условий завершения поедания еды
        if (!stateManager.character.needs.IsHungry())
        {
            stateManager.ChangeState(new CharacterIdleState(stateManager));
        }
        else if (stateManager.character.state.IsAttacked)
        {
            stateManager.ChangeState(new CharacterAttackedState(stateManager));
        }
        else
        {
            // Логика выполнения действий в состоянии "поедание"
            // Например, ожидание или взаимодействие с едой
        }
    }
}