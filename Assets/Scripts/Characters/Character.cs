using UnityEngine;
using Mirror;
using TMPro;

public class Character : NetworkBehaviour
{
    [Header("О персонаже")]
    [Tooltip("Объект для иконки в UI")] public GameObject objIconCharacter;
    [Tooltip("Текст Меш с Именем нпс")] public TextMeshProUGUI textMeshProNameCharacter;
    [Tooltip("Дом персонажа")] public GameObject home;
    [Tooltip("Кровать персонажа")] public GameObject bed;
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
        // Инициализация компонентов персонажа
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
                "Статистика:" +
                "\nЗадачи: " + tasks.GetTasksNames() +
                "\nНужды:" +
                "\nГолод: " + needs.hunger.ToString() +
                "\nСон: " + needs.sleep.ToString() +
                "\nТекущее состояние: " + stateManager.currentState.ToString()
                );
        // Обновление потребностей персонажа
        needs.UpdateNeeds();

        // Создание задач для персонажа на основе его текущих потребностей
        tasks.CreateTasks(needs);
        stateManager.UpdateState();

        // Обновление состояния персонажа осуществляется через CharacterStateManager
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