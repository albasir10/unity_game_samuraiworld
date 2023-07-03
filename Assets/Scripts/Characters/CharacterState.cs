public abstract class CharacterState
{
    protected CharacterStateManager stateManager;
    public CharacterState(CharacterStateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public abstract void EnterState();
    public abstract void ExitState();
    public virtual void UpdateState()
    {
        if (stateManager.character.tasks.currentTask == TaskList.eat && stateManager.currentState.GetType() != typeof(CharacterEatingState))
        {
            stateManager.ChangeState(new CharacterEatingState(stateManager));
        }
        else if (stateManager.character.tasks.currentTask == TaskList.sleep && stateManager.currentState.GetType() != typeof(CharacterSleepingState))
        {
            stateManager.ChangeState(new CharacterSleepingState(stateManager));
        }
        else if (stateManager.character.tasks.currentTask == TaskList.move && stateManager.currentState.GetType() != typeof(CharacterWalkingState))
        {
            stateManager.ChangeState(new CharacterWalkingState(stateManager));
        }
        else if (stateManager.character.tasks.currentTask == TaskList.idle && stateManager.currentState.GetType() != typeof(CharacterIdleState))
        {
            stateManager.ChangeState(new CharacterIdleState(stateManager));
        }
        else if (stateManager.character.tasks.currentTask == TaskList.attack && stateManager.currentState.GetType() != typeof(CharacterAttackedState))
        {
            stateManager.ChangeState(new CharacterAttackedState(stateManager));
        }
    }

}