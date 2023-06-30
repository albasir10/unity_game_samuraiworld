public class StateMachine
{
    private CharacterState currentState;
    public StateMachine()
    {
        currentState = null;
    }

    public void SetState(CharacterState state)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.EnterState();
        }
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }
    public CharacterState GetCurrentState()
    {
        return currentState;
    }
}