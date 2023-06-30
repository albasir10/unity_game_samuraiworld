public class CharacterAttackedState : CharacterState
{
    public CharacterAttackedState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // ������ ����� � ��������� �����
        stateManager.character.state.StartAttacked();
    }

    public override void UpdateState()
    {
        // ������ ���������� ��������� �����
        if (!stateManager.character.state.IsAttacked)
        {
            // ���� �������� �������� ���� �����������, �������� ���������
            stateManager.ChangeState(new CharacterIdleState(stateManager));
        }
    }

    public override void ExitState()
    {
        // ������ ������ �� ��������� �����
        stateManager.character.state.StopAttacked();
    }
}