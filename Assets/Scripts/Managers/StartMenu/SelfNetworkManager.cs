using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public struct CreateCharacterMessage : NetworkMessage
{
    //Передаем данные с клиента на сервер для информации
    public string player_name;
}
public class SelfNetworkManager : NetworkManager
{
    [Header("Self Parameters")]
    [Tooltip("Имя игрока при подключении.")]
    public string name_player;
    public override void OnStartServer()
    {
        base.OnStartServer();
        // отправляем запрос клиенту для получения сообщения и запускаем функцию в скобках
        NetworkServer.RegisterHandler<CreateCharacterMessage>(OnCreateCharacter);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        
        // При подключение игрока срабатаывает данная функция и мы делаем сообщение после чего отправляем на сервер
        CreateCharacterMessage characterMessage = new()
        {
            player_name = name_player
        };
        NetworkClient.Send(characterMessage);
    }
    
    void OnCreateCharacter(NetworkConnectionToClient conn, CreateCharacterMessage message)
    {
        // создаем объект игрока
        GameObject player_obj;
        player_obj = Instantiate(spawnPrefabs[0], startPositions[0].position, startPositions[0].rotation);
        player_obj.name = message.player_name;
        // привязываем подключенного игрока к объекту
        NetworkServer.AddPlayerForConnection(conn, player_obj);
        // даем ему авторизацию
        player_obj.GetComponent<NetworkIdentity>().AssignClientAuthority(conn);
        // передаем имя и тип платформы (подробнее в IPlayerAttribute) на объект
        //player_obj.GetComponent<PlayerManagerMain>().CommandSetAndGetParameters(player_obj, conn.identity, message.player_name, type_controller);
    }
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        //PlayerManagerMain.player_local_obj.GetComponent<PlayerCanvasAdminPanel>().RemovePlayerFromMenu(conn.identity);
        base.OnServerDisconnect(conn);
    }
}
