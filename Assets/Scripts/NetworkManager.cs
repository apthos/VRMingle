using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using PhotonHashtable = ExitGames.Client.Photon.Hashtable;

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
    public GameObject roomUI;
    public PhotonHashtable clothesOptions;

    public void ConnectToServer()
    {
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
        SetClothesOptions();
        roomUI.SetActive(true);
    }
    public void SetClothesOptions()
    {
        clothesOptions = PhotonNetwork.LocalPlayer.CustomProperties;
        clothesOptions.Add("ID", PhotonNetwork.LocalPlayer.UserId);
        PhotonNetwork.LocalPlayer.SetCustomProperties(clothesOptions);
    }

    public void InitializeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Another player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
        PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("ID", out object newPlayerID);
        Debug.Log("New Player ID: " + newPlayerID);
    }
}
