using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UImanager : MonoBehaviour {

    public GameObject HomeInterface;
    public GameObject ChatInterface;
    public GameObject FriendsInterface;
    public GameObject ProfileInterface;
    public GameObject Topbar;
    public Text TopbarText;
    public GameObject listpanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onHomeBtnClick() {
        HomeInterface.SetActive(true);
        ChatInterface.SetActive(false);
        FriendsInterface.SetActive(false);
        ProfileInterface.SetActive(false);
        Topbar.SetActive(true);
        TopbarText.text = "Timeline";
    }

    public void onExploreBtnClick()
    {
        HomeInterface.SetActive(false);
        ChatInterface.SetActive(false);
        FriendsInterface.SetActive(false);
        ProfileInterface.SetActive(false);
        Topbar.SetActive(false);
    }

    public void onChatBtnClick()
    {
        HomeInterface.SetActive(false);
        ChatInterface.SetActive(true);
        FriendsInterface.SetActive(false);
        ProfileInterface.SetActive(false);
        Topbar.SetActive(true);
        TopbarText.text = "Chat";
    }

    public void onFriendsBtnClick()
    {
        HomeInterface.SetActive(false);
        ChatInterface.SetActive(false);
        FriendsInterface.SetActive(true);
        ProfileInterface.SetActive(false);
        Topbar.SetActive(true);
        TopbarText.text = "Friends";
    }

    public void onProfileBtnClick()
    {
        HomeInterface.SetActive(false);
        ChatInterface.SetActive(false);
        FriendsInterface.SetActive(false);
        ProfileInterface.SetActive(true);
        Topbar.SetActive(true);
        TopbarText.text = "Profile";
    }

    public void onCloseListBtnClick()
    {
        listpanel.SetActive(false);
    }

    public void onListShow()
    {
        listpanel.SetActive(true);
    }
}
