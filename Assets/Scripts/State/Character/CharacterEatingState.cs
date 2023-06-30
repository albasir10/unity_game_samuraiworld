public class CharacterEatingState : CharacterState
{
    public CharacterEatingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // ������ ����� � ��������� "��������"
        // ��������, ������ �������� �������� ���
        stateManager.character.CmdEat();
    }

    public override void ExitState()
    {
        // ������ ������ �� ��������� "��������"
        // ��������, ���������� �������� �������� ���
    }

    public override void UpdateState()
    {
        // ������ ���������� ��������� "��������"
        // ��������, �������� ������� ���������� �������� ���
        if (!stateManager.character.needs.IsHungry())
        {
            stateManager.ChangeState(new CharacterIdleState(stateManager));
        }
        else if (stateManager.character.state.IsAttacked)
        {
            stateManager.ChangeState(new CharacterAttackedState(stateManager));
        }
        else
        {
            // ������ ���������� �������� � ��������� "��������"
            // ��������, �������� ��� �������������� � ����
        }
    }
}