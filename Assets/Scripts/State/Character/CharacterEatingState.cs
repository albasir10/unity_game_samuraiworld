public class CharacterEatingState : CharacterState
{
    public CharacterEatingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // ������ ����� � ��������� "��������"
        // ��������, ������ �������� �������� ���
        if (IsCanEat())
        {

        }
        else
        {
            
        }
    }

    public override void ExitState()
    {
        // ������ ������ �� ��������� "��������"
        // ��������, ���������� �������� �������� ���
    }
    public bool IsCanEat()
    {

        return false;
    }
}