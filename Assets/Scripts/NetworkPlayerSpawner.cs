using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    

    Player player;
    
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
        spawnedPlayerPrefab.GetComponent<NetworkPlayer>().player = PhotonNetwork.LocalPlayer;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Another player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);

        // INSTANTIATE THE OBJECTS USING THE CUSTOM PROPERTIES OF newPlayer BY CALLING LoadCustomization from NetworkPlayer script
        // spawnedPlayerPrefab.GetComponent<NetworkPlayer>().LoadCustomization();
        // WE NEED SOME WAY TO GRAB THE NetworkPlayer that corresponds to the newPlayer (maybe a find gameobject function)

        

        Debug.Log(newPlayer.CustomProperties["Glasses"]);
    }
}
