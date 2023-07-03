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
    StartOptionsPlayer startOptionsPlayer;
    CameraSelecting cameraSelecting;
    public override void OnStartLocalPlayer()
    {
        singleon = this;
        startOptionsPlayer = new(this);
        cameraSelecting = GetComponent<CameraSelecting>();
        startOptionsPlayer.SetAllOptions();
        // Добавьте другие настройки камеры для локального игрока, если необходимо
    }

    [Client]
    void Update()
    {
        if (!isLocalPlayer)
            return;

        Move();
        // Взаимодействие с объектами при нажатии правой кнопки мыши
        if (Input.GetMouseButtonDown(1))
        {
            cameraSelecting.PressRightClickMouse();
        }

        // Выделение объектов при нажатии левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            cameraSelecting.PressLeftClickMouse();
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



}