using UnityEngine;
using System.Collections;

public class OtherPplUImanager : MonoBehaviour {

    public GameObject extraOtherPplUI;
    public GameObject listUI;

    void Start()
    {
        listUI = GameObject.FindGameObjectWithTag("MainUI");
    }

    public void onhoverstart()
    {
        extraOtherPplUI.SetActive(true);
    }


    public void onhoverend()
    {
        extraOtherPplUI.SetActive(false);
    }


    public void onclick()
    {
        listUI.GetComponent<UImanager>().onListShow();
    }
}
