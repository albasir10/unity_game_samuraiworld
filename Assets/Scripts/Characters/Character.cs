using UnityEngine;
using Mirror;

public class Character : NetworkBehaviour
{
    public CharacterAttributes attributes;
    public CharacterBody body;
    public CharacterInventory inventory;
    public CharacterNeeds needs;
    public CharacterTasks tasks;
    public CharacterStateManager stateManager;
    public StateMachine stateMachine;

    private void Start()
    {
        // Инициализация компонентов персонажа
        attributes = new CharacterAttributes();
        body = new CharacterBody();
        inventory = new CharacterInventory();
        needs = new CharacterNeeds(100, 100, 10, 10, 20, 20);
        tasks = new CharacterTasks();
        stateMachine = new StateMachine();
        stateManager = new CharacterStateManager(this);
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        stateManager.UpdateState();
        // Обновление потребностей персонажа
        needs.UpdateNeeds();

        // Создание задач для персонажа на основе его текущих потребностей
        tasks.CreateTasks(needs);

        // Выполнение текущей задачи персонажа
        tasks.PerformCurrentTask(this);

        // Обновление состояния персонажа осуществляется через CharacterStateManager
    }

    // Дополнительные методы и функциональность
    // ...

    [Command]
    public void CmdEat()
    {
        if (!needs.IsHungry())
            return;

        // Вызываем функцию поедания еды из CharacterNeeds
        needs.Eat();
    }

    [Command]
    public void CmdRest()
    {
        if (!needs.IsTired())
            return;

        // Вызываем функцию отдыха из CharacterNeeds
        needs.Rest();
    }
}