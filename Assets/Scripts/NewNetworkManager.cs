using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public struct PlayerSettings : NetworkMessage
{
    public bool isFast;
    public int posX;
    public int posZ;
}

public class NewNetworkManager : NetworkManager
{
    public GameObject Player1;
    public GameObject Player2;

    private bool spawnP2 = false;

    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<PlayerSettings>(SpawnPlayer);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        PlayerSettings player = new PlayerSettings
        {
            isFast = true,
            posX = 2,
            posZ = 2
        };
        print("test");
        NetworkClient.Send(player);
    }

    void SpawnPlayer(NetworkConnectionToClient conn, PlayerSettings player)
    {
        Debug.Log("Spawn player function");
        Debug.Log(player.isFast);
        GameObject gameobject;
        Vector3 playerPosition = new Vector3(player.posX, 0, player.posZ);

        if (player.isFast == true && spawnP2 == false)
        {
            Debug.Log("Spawn player 1");
            gameobject = Instantiate(Player1, new Vector3(-8, 0, 0), new Quaternion(0, 0, 0, 0));
            spawnP2 = true;
        }
        else if (spawnP2 == true)
        {
            Debug.Log("Spawn player 2");
            gameobject = Instantiate(Player2, new Vector3(8, 0, 0), new Quaternion(0, 0, 0, 0));
        }
        else
        {
            Debug.Log("Too many players!");
            gameobject = null;
        }

        NetworkServer.AddPlayerForConnection(conn, gameobject);
    }
}
/*
public class NewNetworkManager : NetworkManager
{

    public GameObject player1;
    public GameObject player2;

    public int playerNum = 1;


    public struct PlayerSettings : NetworkMessage
    {
        public bool isFast;
        public int posX;
        public int posZ;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<PlayerSettings>(SpawnPlayer);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        PlayerSettings player = new PlayerSettings
        {
            posX = 0,
            posZ = 0
        };
        print("test");
        NetworkClient.Send(player);
    }

    void SpawnPlayer(NetworkConnection conn, PlayerSettings player)
    {
        GameObject gameObject;
        Vector3 playerPosition = new Vector3(player.posX, 0, player.posZ);
        Debug.Log("Spawn player function");
        if (playerNum == 1)
        {
            Debug.Log("Create player 1");
            gameObject = Instantiate(player1, playerPosition, new Quaternion(0, 0, 0, 0));
            playerNum++;
        }
        else if (playerNum == 2)
        {
            Debug.Log("Create player 2");
            gameObject = Instantiate(player2, playerPosition, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            Debug.Log("Too many players");
        }
    }
}
*/