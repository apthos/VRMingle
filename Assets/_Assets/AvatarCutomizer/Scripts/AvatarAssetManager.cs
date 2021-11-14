using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAssetManager : MonoBehaviour
{
    public GameObject[] clothingObjects;
    int pos = 0;

    public void onRightClick()
    {
        //Cycle
        if (pos < clothingObjects.Length - 1)
        {
            pos++;
        }
        else
        {
            pos = 0;
        }

        //Destroy all children of the body part
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        var temp = Instantiate(clothingObjects[pos]);
        temp.transform.parent = this.transform;
    }

    public void onLeftClick()
    {
        //Cycle
        if (0 < pos)
        {
            pos--;
        }
        else
        {
            pos = clothingObjects.Length - 1;
        }

        //Destroy all children of the body part
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        var temp = Instantiate(clothingObjects[pos]);
        temp.transform.parent = this.transform;
    }
}
