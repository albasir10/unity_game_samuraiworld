public class CharacterRestingState : CharacterState
{
    public CharacterRestingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // Логика входа в состояние "отдых"
        // Например, начало анимации отдыха
        stateManager.character.CmdRest();
    }

    public override void ExitState()
    {
        // Логика выхода из состояния "отдых"
        // Например, завершение анимации отдыха
    }

    public override void UpdateState()
    {
        // Логика обновления состояния "отдых"
        // Например, проверка условий завершения отдыха
        if (!stateManager.character.needs.IsTired())
        {
            stateManager.ChangeState(new CharacterIdleState(stateManager));
        }
        else if (stateManager.character.state.IsAttacked)
        {
            stateManager.ChangeState(new CharacterAttackedState(stateManager));
        }
        else
        {
            // Логика выполнения действий в состоянии "отдых"
            // Например, ожидание или взаимодействие с окружением во время отдыха
        }
    }
}
