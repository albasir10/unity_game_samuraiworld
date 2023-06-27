using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public struct CreateCharacterMessage : NetworkMessage
{
    //�������� ������ � ������� �� ������ ��� ����������
    public string player_name;
}
public class SelfNetworkManager : NetworkManager
{
    [Header("Self Parameters")]
    [Tooltip("��� ������ ��� �����������.")]
    public string name_player;
    public override void OnStartServer()
    {
        base.OnStartServer();
        // ���������� ������ ������� ��� ��������� ��������� � ��������� ������� � �������
        NetworkServer.RegisterHandler<CreateCharacterMessage>(OnCreateCharacter);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        
        // ��� ����������� ������ ������������ ������ ������� � �� ������ ��������� ����� ���� ���������� �� ������
        CreateCharacterMessage characterMessage = new()
        {
            player_name = name_player
        };
        NetworkClient.Send(characterMessage);
    }
    
    void OnCreateCharacter(NetworkConnectionToClient conn, CreateCharacterMessage message)
    {
        // ������� ������ ������
        GameObject player_obj;
        player_obj = Instantiate(spawnPrefabs[0], startPositions[0].position, startPositions[0].rotation);
        player_obj.name = message.player_name;
        // ����������� ������������� ������ � �������
        NetworkServer.AddPlayerForConnection(conn, player_obj);
        // ���� ��� �����������
        player_obj.GetComponent<NetworkIdentity>().AssignClientAuthority(conn);
        // �������� ��� � ��� ��������� (��������� � IPlayerAttribute) �� ������
        //player_obj.GetComponent<PlayerManagerMain>().CommandSetAndGetParameters(player_obj, conn.identity, message.player_name, type_controller);
    }
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        //PlayerManagerMain.player_local_obj.GetComponent<PlayerCanvasAdminPanel>().RemovePlayerFromMenu(conn.identity);
        base.OnServerDisconnect(conn);
    }
}
