using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CameraController : NetworkBehaviour
{
    public bool move_in_border = false;
    public float moveSpeed = 10f;
    public float boundary = 25f;
    public static CameraController singleon;
    public GameObject select_character;
    void Update()
    {
        if (!isLocalPlayer)
            return;

        // Лететь при нажатии клавиш WASD

        Move();
        // Взаимодействие с объектами при нажатии правой кнопки мыши
        if (Input.GetMouseButtonDown(1))
        {
            CmdTryInteractWithObjects();
        }

        // Выделение объектов при нажатии левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            ClientSelectObject();
        }
    }
    [Client]
    private void Move()
    {
        Vector3 new_transform = new(0,0,0);
        // Лететь при касании края экрана мышкой
        if (Input.mousePosition.x >= Screen.width - boundary && move_in_border)
        {
            new_transform.x = moveSpeed * Time.deltaTime;
        }
        else if (Input.mousePosition.x <= boundary && move_in_border)
        {
            new_transform.x = -(moveSpeed * Time.deltaTime);
        }

        if (Input.mousePosition.y >= Screen.height - boundary && move_in_border)
        {
            new_transform.y = (moveSpeed * Time.deltaTime);
        }
        else if (Input.mousePosition.y <= boundary && move_in_border)
        {
            new_transform.y = -(moveSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput < 0) 
            {
                new_transform.x = -(moveSpeed * Time.deltaTime);
            }
            else if  (horizontalInput > 0)
            {
                new_transform.x = (moveSpeed * Time.deltaTime);
            }
            float verticalInput = Input.GetAxis("Vertical");
            if (verticalInput < 0)
            {
                new_transform.y = -(moveSpeed * Time.deltaTime);
            }
            else if (verticalInput > 0)
            {
                new_transform.y = (moveSpeed * Time.deltaTime);
            }
        }
        transform.position += new_transform;
    }
    [Command]
    private void CmdTryInteractWithObjects()
    {
        // Логика взаимодействия с объектами

        // Обновляем состояние объекта на сервере
        // ...
    }
    public void ClientSelectObject()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        Debug.Log(hit.collider);
        if (hit.collider != null && hit.collider.GetComponent<Character_Pawn>() && hit.collider.GetComponent<Character_Pawn>().gameObject == select_character)
            return;
        if (hit.collider != null && hit.collider.GetComponent<Character_Pawn>())
        {
            Character_Pawn character = hit.collider.GetComponent<Character_Pawn>();
            // Обработка нажатия на объект
            UIPlayer.singleon.OpenPanelInfoCharacter(character);
            select_character = character.gameObject;
            CmdSelectObject(select_character);
        }
        else if (hit.collider != null && hit.collider.GetComponentInParent<Character_Pawn>())
        {
            Character_Pawn character = hit.collider.GetComponentInParent<Character_Pawn>();
            // Обработка нажатия на объект
            UIPlayer.singleon.OpenPanelInfoCharacter(character);
            select_character = character.gameObject;
            CmdSelectObject(select_character);
        }
        else if (hit.collider != null && UIPlayer.singleon.is_opened_info_character_panel)
        {
            UIPlayer.singleon.ClosePanelInfoCharacter();
            CmdUnSelectObject(select_character);
            select_character = null;
        }
    }
    [Command]
    private void CmdSelectObject(GameObject character_obj)
    {
        // Логика выделения объекта

        // Обновляем состояние объекта на сервере
        // ...
    }
    [Command]
    private void CmdUnSelectObject(GameObject character_obj)
    {
        // Логика выделения объекта

        // Обновляем состояние объекта на сервере
        // ...
    }
    // Переопределяем метод OnStartLocalPlayer
    public override void OnStartLocalPlayer()
    {
        singleon = this;
        EnabledParameters();
        StartOptions();
        // Добавьте другие настройки камеры для локального игрока, если необходимо
    }
    [Client]
    public void EnabledParameters()
    {
        GetComponent<Camera>().enabled = true;
        GetComponent<AudioListener>().enabled = true;
        GetComponentInChildren<Canvas>().enabled = true;
        GetComponentInChildren<CanvasScaler>().enabled = true;
        GetComponentInChildren<GraphicRaycaster>().enabled = true;
        GetComponentInChildren<EventSystem>().enabled = true;
        GetComponentInChildren<StandaloneInputModule>().enabled = true;
        GetComponentInChildren<UIPlayer>().enabled = true;
    }
    [Client]
    public void StartOptions()
    {
        UIPlayer.singleon = GetComponentInChildren<UIPlayer>();
        UIPanelInfoCharacter.singleon = GetComponentInChildren<UIPanelInfoCharacter>();
        UIPanelInfoCharacter.singleon.gameObject.SetActive(false);
        // настраиваем пешки
        Character_Pawn[] NPCs =  FindObjectsOfType<Character_Pawn>();
        foreach (Character_Pawn npc in NPCs) 
        {
            Canvas npc_canvas = npc.GetComponentInChildren<Canvas>();
            npc_canvas.worldCamera = GetComponent<Camera>();
            npc.textmesh_name = npc_canvas.GetComponentInChildren<TextMeshProUGUI>();
            npc.textmesh_name.SetText(npc.second_name + " " + npc.first_name);
        }
    }
}