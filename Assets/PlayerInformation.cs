using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public GameObject Hair;
    public GameObject Glasses;
    public GameObject Beard;
    public GameObject Hats;
    public GameObject PlayerSkinColor;
    public GameObject Shirt;
    public GameObject Jacket;
    //public GameObject Emote;

    int[] playerInfo;


    public int[] PlayerInfo()
    {
        playerInfo[0] = Hair.GetComponent<AvatarAssetManager>().pos;
        playerInfo[1] = Glasses.GetComponent<AvatarAssetManager>().pos;
        playerInfo[2] = Beard.GetComponent<AvatarAssetManager>().pos;
        playerInfo[3] = Hats.GetComponent<AvatarAssetManager>().pos;
        playerInfo[4] = PlayerSkinColor.GetComponent<AvatarAssetManager>().pos;
        playerInfo[5] = Shirt.GetComponent<AvatarAssetManager>().pos;
        playerInfo[6] = Jacket.GetComponent<AvatarAssetManager>().pos;

        return playerInfo;
    }
}
