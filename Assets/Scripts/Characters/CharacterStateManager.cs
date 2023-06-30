public class CharacterStateManager
{
    public Character character;
    private CharacterState currentState;

    public CharacterStateManager(Character character)
    {
        this.character = character;
        currentState = new CharacterIdleState(this);
    }

    public void UpdateState()
    {
        currentState.UpdateState();
    }

    public void ChangeState(CharacterState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}