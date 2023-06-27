using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Mirror.Discovery;

public class ConnectToServer : MonoBehaviour
{
    public static ConnectToServer singleion;
	// получение списка серверов
    readonly Dictionary<long, ServerResponse> discoveredServers = new Dictionary<long, ServerResponse>();
    public NetworkDiscovery networkDiscovery;
    public SelfNetworkManager manager;
    // код до #endif работет только в редакторе юнити
    private void Awake()
    {
        singleion = this;
    }
#if UNITY_EDITOR
    void OnValidate()
    {
		// если нет компонента он добавляет его
        if (networkDiscovery == null)
        {
            networkDiscovery = GetComponent<NetworkDiscovery>();
            manager = GetComponent<SelfNetworkManager>();
            UnityEditor.Events.UnityEventTools.AddPersistentListener(networkDiscovery.OnServerFound, OnDiscoveredServer);
            UnityEditor.Undo.RecordObjects(new Object[] { this, networkDiscovery }, "Set NetworkDiscovery");
        }
    }
#endif
    public void LocalStartHost()
    {
        discoveredServers.Clear();
        manager.StartHost();
        networkDiscovery.AdvertiseServer();
        StartCoroutine(Checker());
        Debug.Log("Start Host");
    }
    public void LocalStartClient()
    {
        discoveredServers.Clear();
        networkDiscovery.StartDiscovery();
        StopCoroutine(FindServer());
        StartCoroutine(FindServer());
        Debug.Log("Start Client");
    }
    public void LocalStartServer()
    {
        discoveredServers.Clear();
        manager.StartServer();
        networkDiscovery.AdvertiseServer();
        StartCoroutine(Checker());
        Debug.Log("Start Server");
    }
    IEnumerator FindServer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (discoveredServers.Count > 0)
            {
                foreach (ServerResponse info in discoveredServers.Values)
                    Connect(info);
                break;
            }
        }
    }
    public void StopHost()
    {
        manager.StopHost();
        networkDiscovery.StopDiscovery();
        Debug.Log("Stop Host");
    }

	IEnumerator Checker()
	{
		yield return new WaitForSeconds(3f);
		// GetComponent<SaveFileInfo>().textCube = GameObject.FindGameObjectWithTag("test");
	}
    void Connect(ServerResponse info)
    {
        networkDiscovery.StopDiscovery();
        NetworkManager.singleton.StartClient(info.uri);
    }

    public void OnDiscoveredServer(ServerResponse info)
    {
        // Note that you can check the versioning to decide if you can connect to the server or not using this method
        discoveredServers[info.serverId] = info;
    }
}
