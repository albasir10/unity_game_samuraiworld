public class CharacterAttackedState : CharacterState
{
    public CharacterAttackedState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // Логика входа в состояние атаки
        stateManager.character.attributes.isAttacked = true;
        //stateManager.character.StartAttacked();
    }

    public override void ExitState()
    {
        // Логика выхода из состояния атаки
        stateManager.character.attributes.isAttacked = false;
        //stateManager.character.StopAttacked();
    }

}