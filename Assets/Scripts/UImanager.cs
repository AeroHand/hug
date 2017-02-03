using UnityEngine;
using System.Collections;

public class UImanager : MonoBehaviour {

    public GameObject HomeInterface;
    public GameObject ChatInterface;
    public GameObject FriendsInterface;
    public GameObject ProfileInterface;

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
    }

    public void onExploreBtnClick()
    {
        HomeInterface.SetActive(false);
        ChatInterface.SetActive(false);
        FriendsInterface.SetActive(false);
        ProfileInterface.SetActive(false);
    }

    public void onChatBtnClick()
    {
        HomeInterface.SetActive(false);
        ChatInterface.SetActive(true);
        FriendsInterface.SetActive(false);
        ProfileInterface.SetActive(false);
    }

    public void onFriendsBtnClick()
    {
        HomeInterface.SetActive(false);
        ChatInterface.SetActive(false);
        FriendsInterface.SetActive(true);
        ProfileInterface.SetActive(false);
    }

    public void onProfileBtnClick()
    {
        HomeInterface.SetActive(false);
        ChatInterface.SetActive(false);
        FriendsInterface.SetActive(false);
        ProfileInterface.SetActive(true);
    }
}
