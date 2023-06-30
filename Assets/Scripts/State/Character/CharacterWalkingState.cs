public class CharacterWalkingState : CharacterState
{
    public CharacterWalkingState(CharacterStateManager stateManager) : base(stateManager)
    {
    }

    public override void EnterState()
    {
        // Ћогика входа в состо€ние "движение"
        // Ќапример, начало движени€ персонажа
    }

    public override void ExitState()
    {
        // Ћогика выхода из состо€ни€ "движение"
        // Ќапример, остановка персонажа
    }

    public override void UpdateState()
    {
        // Ћогика обновлени€ состо€ни€ "движение"
        // Ќапример, проверка условий перехода в другие состо€ни€
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
            // Ћогика выполнени€ действий в состо€нии "движение"
            // Ќапример, передвижение по миру или следование к цели
        }
    }
}