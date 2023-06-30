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

    public override void UpdateState()
    {
        // Логика обновления состояния "покой"
        // Например, проверка условий перехода в другие состояния
        if (stateManager.character.needs.IsHungry())
        {
            stateManager.ChangeState(new CharacterEatingState(stateManager));
        }
        else if (stateManager.character.needs.IsTired())
        {
            stateManager.ChangeState(new CharacterRestingState(stateManager));
        }
        else if (stateManager.character.state.IsAttacked)
        {
            stateManager.ChangeState(new CharacterAttackedState(stateManager));
        }
        else
        {
            // Логика выполнения действий в состоянии "покой"
            // Например, ожидание или взаимодействие с окружением
        }
    }
}