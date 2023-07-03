using Mirror;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterWalkingState : CharacterState
{
    private Vector2 destination; // ������� ������� ��� ������������

    public CharacterWalkingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // ������ ����� � ��������� "��������"
        // ��������, ��������� ������� ������� � �������� ������������

        // ������ ������������ � ����
        destination = stateManager.character.tasks.currentTask.destination;
        stateManager.character.attributes.isMoving = true;
    }
    public override void UpdateState()
    {
        stateManager.character.Moving(destination);
        base.UpdateState();
    }
    public override void ExitState()
    {
        // ������ ������ �� ��������� "��������"
        // ��������, ��������� ���������
        stateManager.character.tasks.RemoveTask(stateManager.character.tasks.currentTask);
        stateManager.character.attributes.isMoving = false;
    }
}