public class CharacterWalkingState : CharacterState
{
    public CharacterWalkingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // ������ ����� � ��������� "��������"
        // ��������, ������ �������� ���������
    }

    public override void ExitState()
    {
        // ������ ������ �� ��������� "��������"
        // ��������, ��������� ���������
    }

    public override void UpdateState()
    {
        // ������ ���������� ��������� "��������"
        // ��������, �������� ������� �������� � ������ ���������
        if (stateManager.character.needs.IsHungry())
        {
            stateManager.ChangeState(new CharacterEatingState(stateManager));
        }
        else if (stateManager.character.needs.IsTired())
        {
            stateManager.ChangeState(new CharacterRestingState(stateManager));
        }
        else if (stateManager.character.state.IsAttacked)
        {
            stateManager.ChangeState(new CharacterAttackedState(stateManager));
        }
        else
        {
            // ������ ���������� �������� � ��������� "��������"
            // ��������, ������������ �� ���� ��� ���������� � ����
        }
    }
}