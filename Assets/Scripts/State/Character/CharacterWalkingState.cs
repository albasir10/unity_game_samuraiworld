using Mirror;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterWalkingState : CharacterState
{
    private Vector2 destination; // Целевая позиция для передвижения

    public CharacterWalkingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // Логика входа в состояние "движение"
        // Например, получение целевой позиции и скорости передвижения

        // Начать передвижение к цели
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
        // Логика выхода из состояния "движение"
        // Например, остановка персонажа
        stateManager.character.tasks.RemoveTask(stateManager.character.tasks.currentTask);
        stateManager.character.attributes.isMoving = false;
    }
}