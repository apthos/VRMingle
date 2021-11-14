using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public GameObject Hair;
    public GameObject Glasses;
    public GameObject Beard;
    public GameObject Hats;
    //public GameObject PlayerSkinColor;
    public GameObject Shirt;
    public GameObject Jacket;
    //public GameObject Emote;

    int[] playerInfo = new int[6];

    public int[] PlayerInfo()
    {
        playerInfo[0] = Hair.GetComponent<AvatarAssetManager>().position();
        playerInfo[1] = Glasses.GetComponent<AvatarAssetManager>().position();
        playerInfo[2] = Beard.GetComponent<AvatarAssetManager>().position();
        playerInfo[3] = Hats.GetComponent<AvatarAssetManager>().position();
        playerInfo[4] = Shirt.GetComponent<AvatarAssetManager>().position();
        playerInfo[5] = Jacket.GetComponent<AvatarAssetManager>().position();

        Debug.Log("Player Info: " + playerInfo[1]);

        return playerInfo;
    }
}
