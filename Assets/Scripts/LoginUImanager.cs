using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using Facebook.Unity;
using System.Collections.Generic;

public class LoginUImanager : MonoBehaviour {

    public Text useremail;
    public GameObject afterloginUI;
    public GameObject beforeloginUI;
    public GameObject beforeloginUI2;
    public GPSmovemen scriptGPSmove;
    //public string userpassword;
    public string url = "https://test.xgameportal.com/platform/php/?method=registerHugUser&username=";
    
    public string positionurl = "https://test.xgameportal.com/platform/php/?method=updateUserPosition&username=";

    private string mx;
    private string my;
    /*
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            Debug.Log("failed to initialize the facebook sdk");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }

    

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    */
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnLoginClicked()
    {

        
        url = url + useremail.text;
        StartCoroutine(registeruser());
    }

    IEnumerator registeruser()
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            GameManager.Instance.username = useremail.text;
            afterloginUI.SetActive(true);
            beforeloginUI.SetActive(false);
            beforeloginUI2.SetActive(false);
            scriptGPSmove = GameManager.Instance.yourselfavatar.GetComponent<GPSmovemen>();
            mx = scriptGPSmove.selfposition.x.ToString("n0");
            mx = mx.Replace(",", "");
            my = scriptGPSmove.selfposition.y.ToString("n0");
            my = my.Replace(",", "");
            positionurl = positionurl + useremail.text + "&mercatorx=" + mx + "&mercatory=" + my;
            
            StartCoroutine(registeruserposition());
        }
        else
        {
            Debug.Log("login fail");
        }
    }

    IEnumerator registeruserposition()
    {
        WWW wwww = new WWW(positionurl);
        yield return wwww;
        if (wwww.error == null)
        {
            GameManager.Instance.logined = true;
            Debug.Log("register position success");
        }
        else
        {
            Debug.Log("login fail");
        }
    }

}
