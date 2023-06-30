public class CharacterRestingState : CharacterState
{
    public CharacterRestingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // ������ ����� � ��������� "�����"
        // ��������, ������ �������� ������
        stateManager.character.CmdRest();
    }

    public override void ExitState()
    {
        // ������ ������ �� ��������� "�����"
        // ��������, ���������� �������� ������
    }

    public override void UpdateState()
    {
        // ������ ���������� ��������� "�����"
        // ��������, �������� ������� ���������� ������
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
            // ������ ���������� �������� � ��������� "�����"
            // ��������, �������� ��� �������������� � ���������� �� ����� ������
        }
    }
}
