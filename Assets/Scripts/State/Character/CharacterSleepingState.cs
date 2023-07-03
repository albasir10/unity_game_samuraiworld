public class CharacterSleepingState : CharacterState
{
    public CharacterSleepingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // ������ ����� � ��������� "�����"
        // ��������, ������ �������� ������
        //stateManager.character.needs.Rest();
        stateManager.character.attributes.isSleeping = true;
    }
    public override void UpdateState()
    {
        stateManager.character.Sleeping();
        base.UpdateState();
    }
    public override void ExitState()
    {
        // ������ ������ �� ��������� "�����"
        // ��������, ���������� �������� ������
        stateManager.character.tasks.RemoveTask(stateManager.character.tasks.currentTask);
        stateManager.character.attributes.isSleeping = false;
    }
}
