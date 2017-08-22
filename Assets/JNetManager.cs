using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JNetManager : MonoBehaviour {


    public static string networkSceneName;

    public static NetworkManager singleton;

    [SerializeField]
    public string matchName;
    // Add struct of info here that is serializble?

    [SerializeField]
    public uint matchSize;

    //public bool isNetworkActive{}

    public NetworkClient client;

    private void Start()
    {
        
        if (NetworkServer.Listen(7777))
        {
            Debug.Log("Listen succesfull");
        }
        client = new NetworkClient();

        client.Connect("255.255.255.255", 7777);

        byte[] a = new byte[3];
        a[0] = 3;

        while (client.isConnected == false)
        {

        }
        if(client.SendBytes(a, 1, 0))
        {
            Debug.Log("send succesfull");
        }
        else
        {
            Debug.Log("send fail");
        }
        
    }

    //The maximum delay before sending packets on connections
    public float maxDelay { get; set; }


    public string serverBindAddress { get; set; }

    //  The network address currently in use.
    public string networkAddress { get; set; }


    //    public bool serverBindToIP { get; set; }
    //    public bool scriptCRCCheck { get; set; }


    //     public GlobalConfig globalConfig { get; }


    //    public bool customConfig { get; set; }
    //   public ConnectionConfig connectionConfig { get; }

    public int networkPort { get; set; }

    //     The maximum number of concurrent network connections to support.
    public int maxConnections { get; set; }

    //     The Quality-of-Service channels to use for the network transport layer.
    //  
    //public List<QosType> channels { get; }

    //     Allows you to specify an EndPoint object instead of setting networkAddress and
    //     networkPort (required for some platforms such as Xbox One).
    //public EndPoint secureTunnelEndpoint { get; set; }


    //     This is true if the client loaded a new scene when connecting to the server.
    public bool clientLoadedScene { get; set; }

    // List of prefabs that will be registered with the spawning system.
    public List<GameObject> spawnPrefabs;


    public int numPlayers;



    //     True if the NetworkManagers client is connected to a server.
    public bool IsClientConnected(){ return true; }
   
    //     Connection to the server.
    public  void OnClientConnect(NetworkConnection conn){}
   
    //     Connection to the server.
    public  void OnClientDisconnect(NetworkConnection conn){}
   

    //   errorCode:
    //     Error code.
    public  void OnClientError(NetworkConnection conn, int errorCode){}
    

    //     Connection to a server.
    public  void OnClientNotReady(NetworkConnection conn){}
   
    //     The network connection that the scene change message arrived on.
    public  void OnClientSceneChanged(NetworkConnection conn){}
   

    //   extendedInfo:
    //     A text description for the error if success is false.
    public  void OnDestroyMatch(bool success, string extendedInfo){}
    
    //   extendedInfo:
    //     A text description for the error if success is false.
    public  void OnDropConnection(bool success, string extendedInfo){}
    
    //
    //   extraMessageReader:
    //     An extra message object passed for the new player.
    public  void OnServerAddPlayer(NetworkConnection conn, short playerControllerId){}

    public  void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader){}
   
    //     Connection from client.
    public  void OnServerConnect(NetworkConnection conn){}
    
    //     Connection from client.
    public  void OnServerDisconnect(NetworkConnection conn){}
  
    //     Error code.
    public  void OnServerError(NetworkConnection conn, int errorCode){}
   
    //     Connection from client.
    public  void OnServerReady(NetworkConnection conn){}
  
    //   player:
    //     The player controller to remove.
    public  void OnServerRemovePlayer(NetworkConnection conn, PlayerController player){}
   
    //   sceneName:
    //     The name of the new scene.
    public  void OnServerSceneChanged(string sceneName){}
    //
 
    //   extendedInfo:
    //     A text description for the error if success is false.
    public  void OnSetMatchAttributes(bool success, string extendedInfo){}
  
    //   client:
    //     The NetworkClient object that was started.
    public  void OnStartClient(NetworkClient client){}
    //
    // Summary:
    //     ///
    //     This hook is invoked when a host is started.
    //     ///
    public  void OnStartHost(){}
    //
    // Summary:
    //     ///
    //     This hook is invoked when a server is started - including when a host is started.
    //     ///
    public  void OnStartServer(){}
    //
    // Summary:
    //     ///
    //     This hook is called when a client is stopped.
    //     ///
    public  void OnStopClient(){}
    //
    // Summary:
    //     ///
    //     This hook is called when a host is stopped.
    //     ///
    public  void OnStopHost(){}
    //
    // Summary:
    //     ///
    //     This hook is called when a server is stopped - including when a host is stopped.
    //     ///
    public  void OnStopServer(){}
    //
    // Summary:
    //     ///
    //     This causes the server to switch scenes and sets the networkSceneName.
    //     ///
    //
    // Parameters:
    //   newSceneName:
    //     The name of the scene to change to. The server will change scene immediately,
    //     and a message will be sent to connected clients to ask them to change scene also.
    public  void ServerChangeScene(string newSceneName){}
    //
    // Summary:
    //     ///
    //     This sets the address of the MatchMaker service.
    //     ///
    //
    // Parameters:
    //   newHost:
    //     Hostname of MatchMaker service.
    //
    //   port:
    //     Port of MatchMaker service.
    //
    //   https:
    //     Protocol used by MatchMaker service.
    public void SetMatchHost(string newHost, int port, bool https){}
    //
    // Summary:
    //     ///
    //     This sets up a NetworkMigrationManager object to work with this NetworkManager.
    //     ///
    //
    // Parameters:
    //   man:
    //     The migration manager object to use with the NetworkManager.
    public void SetupMigrationManager(NetworkMigrationManager man){}

 
}
