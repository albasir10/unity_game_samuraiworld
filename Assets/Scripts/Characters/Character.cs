using UnityEngine;
using Mirror;
using TMPro;

public class Character : NetworkBehaviour
{
    [Header("� ���������")]
    [Tooltip("������ ��� ������ � UI")] public GameObject objIconCharacter;
    [Tooltip("����� ��� � ������ ���")] public TextMeshProUGUI textMeshProNameCharacter;
    [Tooltip("��� ���������")] public GameObject home;
    [Tooltip("������� ���������")] public GameObject bed;
    public CharacterAttributes attributes;
    public CharacterBody body;
    public CharacterInventory inventory;
    public CharacterNeeds needs;
    public CharacterTasks tasks;
    public CharacterStateManager stateManager;
    public StateMachine stateMachine;
    public CharacterState state;
    public bool needDebug = false;
    public override void OnStartServer()
    {
        base.OnStartServer();
        // ������������� ����������� ���������
        attributes = new CharacterAttributes();
        body = new CharacterBody();
        inventory = new CharacterInventory();
        needs = new CharacterNeeds(this, 100, 100, 10, 10, 20, 20);
        tasks = new CharacterTasks(this);
        stateMachine = new StateMachine();
        stateManager = new CharacterStateManager(this);
        state = new CharacterIdleState(stateManager);
    }

    private void Update()
    {
        if (needDebug)
            Debug.Log(
                "����������:" +
                "\n������: " + tasks.GetTasksNames() +
                "\n�����:" +
                "\n�����: " + needs.hunger.ToString() +
                "\n���: " + needs.sleep.ToString() +
                "\n������� ���������: " + stateManager.currentState.ToString()
                );
        // ���������� ������������ ���������
        needs.UpdateNeeds();

        // �������� ����� ��� ��������� �� ������ ��� ������� ������������
        tasks.CreateTasks(needs);
        stateManager.UpdateState();

        // ���������� ��������� ��������� �������������� ����� CharacterStateManager
    }
    public void Moving(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, attributes.speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, destination) < attributes.speed * Time.deltaTime)
        {
            state.ExitState();
        }
    }
    public void Sleeping()
    {
        if (needs.sleep < 100f)
            needs.IncreaseSleep();
        else
            state.ExitState();
    }
}