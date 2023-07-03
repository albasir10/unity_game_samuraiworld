public class CharacterAttackedState : CharacterState
{
    public CharacterAttackedState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // ������ ����� � ��������� �����
        stateManager.character.attributes.isAttacked = true;
        //stateManager.character.StartAttacked();
    }

    public override void ExitState()
    {
        // ������ ������ �� ��������� �����
        stateManager.character.attributes.isAttacked = false;
        //stateManager.character.StopAttacked();
    }

}