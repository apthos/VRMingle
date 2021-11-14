using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using PhotonHashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;

[System.Serializable]
public class DefaultRoom
{
    public string Name;
    public int sceneIndex;
    public int maxPlayer;
}

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public List<DefaultRoom> defaultRooms;
    public GameObject connectButton;
    public GameObject player;
    public PhotonHashtable clothesOptions = new PhotonHashtable();

    public void ConnectToServer()
    {
        GameObject textChild = connectButton.transform.GetChild(0).gameObject;
        textChild.GetComponent<TextMeshProUGUI>().text = "Connecting...";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server.");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined Lobby");
        InitializeRoom();
    }

    public void InitializeRoom()
    {
        // Prepare Player for room join
        int[] playerOptions = player.GetComponent<PlayerInformation>().PlayerInfo();
        clothesOptions["Hair"] = playerOptions[0];
        clothesOptions["Glasses"] = playerOptions[1];
        clothesOptions["Beard"] = playerOptions[2];
        clothesOptions["Hats"] = playerOptions[3];
        clothesOptions["Shirt"] = playerOptions[4];
        clothesOptions["Jacket"] = playerOptions[5];
        PhotonNetwork.LocalPlayer.SetCustomProperties(clothesOptions);

        // Connect player to room
        PhotonNetwork.LoadLevel("ParkMap");
        PhotonNetwork.JoinRandomOrCreateRoom(null, 2);
    }
}
