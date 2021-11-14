using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject cube;

    private GameObject spawnedPlayerPrefab;
    Player player;
    
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
        //Update the clothes on this prefab so it displays later
        //Make script on network player that makes a hash table of all player preferences
        //var Glasses = Instantiate(spawnedPlayerPrefab.GetComponent<NetworkPlayer>().playerProperties("glasses"), transform);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }

}
