public class CharacterSleepingState : CharacterState
{
    public CharacterSleepingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // Логика входа в состояние "отдых"
        // Например, начало анимации отдыха
        //stateManager.character.needs.Rest();
        stateManager.character.attributes.isSleeping = true;
    }
    public override void UpdateState()
    {
        stateManager.character.Sleeping();
        base.UpdateState();
    }
    public override void ExitState()
    {
        // Логика выхода из состояния "отдых"
        // Например, завершение анимации отдыха
        stateManager.character.tasks.RemoveTask(stateManager.character.tasks.currentTask);
        stateManager.character.attributes.isSleeping = false;
    }
}
