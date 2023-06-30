public class CharacterAttackedState : CharacterState
{
    public CharacterAttackedState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // Логика входа в состояние атаки
        stateManager.character.state.StartAttacked();
    }

    public override void UpdateState()
    {
        // Логика обновления состояния атаки
        if (!stateManager.character.state.IsAttacked)
        {
            // Если персонаж перестал быть атакованным, изменяем состояние
            stateManager.ChangeState(new CharacterIdleState(stateManager));
        }
    }

    public override void ExitState()
    {
        // Логика выхода из состояния атаки
        stateManager.character.state.StopAttacked();
    }
}