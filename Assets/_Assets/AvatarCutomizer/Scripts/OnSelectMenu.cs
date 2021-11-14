using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectMenu : MonoBehaviour
{
    public GameObject BodyPartMenu;
    //public GameObject RightSideIndividualMenu;

    public void onSelect()
    {
        foreach (Transform child in BodyPartMenu.transform)
        {
            child.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(true);
        this.transform.parent.gameObject.SetActive(true);
    }

    public void onBackButton()
    {
        foreach (Transform child in BodyPartMenu.transform)
        {
            child.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            //this.transform.parent.gameObject.SetActive(false);
        }
    }
}
