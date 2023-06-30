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
        // ������������� ����������� ���������
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
        // ���������� ������������ ���������
        needs.UpdateNeeds();

        // �������� ����� ��� ��������� �� ������ ��� ������� ������������
        tasks.CreateTasks(needs);

        // ���������� ������� ������ ���������
        tasks.PerformCurrentTask(this);

        // ���������� ��������� ��������� �������������� ����� CharacterStateManager
    }

    // �������������� ������ � ����������������
    // ...

    [Command]
    public void CmdEat()
    {
        if (!needs.IsHungry())
            return;

        // �������� ������� �������� ��� �� CharacterNeeds
        needs.Eat();
    }

    [Command]
    public void CmdRest()
    {
        if (!needs.IsTired())
            return;

        // �������� ������� ������ �� CharacterNeeds
        needs.Rest();
    }
}