public abstract class CharacterState
{
    protected CharacterStateManager stateManager;

    public CharacterState(CharacterStateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
}