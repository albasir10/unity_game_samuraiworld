using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraController : NetworkBehaviour
{
    public bool move_in_border = false;
    public float moveSpeed = 10f;
    public float boundary = 25f;
    public static CameraController singleon;
    public GameObject panel_object;
    public Button button_character_name;
    void Update()
    {
        if (!isLocalPlayer)
            return;

        // ������ ��� ������� ������ WASD

        Move();
        // �������������� � ��������� ��� ������� ������ ������ ����
        if (Input.GetMouseButtonDown(1))
        {
            CmdTryInteractWithObjects();
        }

        // ��������� �������� ��� ������� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            CmdSelectObject();
        }
    }
    [Client]
    private void Move()
    {
        Vector3 new_transform = new(0,0,0);
        // ������ ��� ������� ���� ������ ������
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
        // ������ �������������� � ���������

        // ��������� ��������� ������� �� �������
        // ...
    }

    [Command]
    private void CmdSelectObject()
    {
        // ������ ��������� �������

        // ��������� ��������� ������� �� �������
        // ...
    }

    // �������������� ����� OnStartLocalPlayer
    public override void OnStartLocalPlayer()
    {
        singleon = this;
        EnabledParameters();
        StartOptions();
        // �������� ������ ��������� ������ ��� ���������� ������, ���� ����������
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
        // ������������� ������ ������� ��� ����� �� �������
        GetComponentInChildren<UIPlayer>().SetCanvasUI(GetComponentInChildren<Canvas>().gameObject);
        // ����������� �����
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