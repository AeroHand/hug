using UnityEngine;
using Assets;
using Assets.Helpers;
using System.Collections;

public class GPSmovemen : MonoBehaviour {

    public bool PCtest = false;

    public string gps_info = "";
    public int flash_num = 1;

    public float curlatitude;
    public float curlongitude;
    
    public Vector2 centertiletms;

    public Vector2 selfposition;
    private Vector2 originposition;
    private Vector3 targetmovement;
    private Vector3 tempotherpplv3;

    public Camera maincamera;

    public string positionurl = "https://test.xgameportal.com/platform/php/?method=updateUserPosition&username=";
    public string arounduserurl = "https://test.xgameportal.com/platform/php/?method=getNearbyUser&username=";
    public string logouturl = "https://test.xgameportal.com/platform/php/?method=logoutHugUser&username=";

    public GameObject otherpplPrefab;

    private string mx;
    private string my;

    private float timercount=0;
    private JSONObject usersData;
    // Use this for initialization
    void Start () {
        if (!Input.location.isEnabledByUser)
        {
            this.gps_info = "isEnabledByUser value is:" + Input.location.isEnabledByUser.ToString() + " Please turn on the GPS";
            
        }

        //make it as the origin point
    }
	
	// Update is called once per frame
	void Update () {

        if (PCtest)
        {
            curlatitude = 37.425885f;
            curlongitude = -122.144288f;
        }
        else {
            curlatitude = Input.location.lastData.latitude;
            curlongitude = Input.location.lastData.longitude;
        }
        
        
        //current mercator position
        selfposition = GM.LatLonToMeters(curlatitude, curlongitude);

        targetmovement = (selfposition - centertiletms).ToVector3xz();
        //Debug.Log(targetmovement);
        this.transform.position = Vector3.MoveTowards(transform.position,targetmovement,1);

        //check if login
        if (GameManager.Instance.logined)
        {
            //update position
            timercount += Time.deltaTime;
            if (timercount >= 0.05f)
            {
                timercount = 0;
                mx = selfposition.x.ToString("n0");
                mx = mx.Replace(",", "");
                my = selfposition.y.ToString("n0");
                my = my.Replace(",", "");
                positionurl = positionurl + GameManager.Instance.username + "&mercatorx=" + mx + "&mercatory=" + my;

                StartCoroutine(registeruserposition());
                //get around users
                arounduserurl = arounduserurl + GameManager.Instance.username + "&mercatorx=" + mx + "&mercatory=" + my;
                StartCoroutine(getAroundUser());
            }
        }
	}

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 600, 48), curlatitude.ToString());
        GUI.Label(new Rect(20, 50, 600, 48), curlongitude.ToString());
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
            Debug.Log("update position fail");
        }
    }

    public static int IntParseFast(string value)
    {
        int result = 0;
        int negativef = 1;
        for (int i = 0; i < value.Length; i++)
        {
            char letter = value[i];
            if (letter == '-')
            { negativef = -1; }
            else
            {
                if ((letter >= 48) && (letter <= 57))
                {
                    result = 10 * result + (letter - 48);
                }
            }
            
        }
        return result*negativef;
    }

    IEnumerator getAroundUser()
    {
        WWW www = new WWW(arounduserurl);
        yield return www;
        if (www.error == null)
        {
            GameManager.Instance.logined = true;
            usersData = new JSONObject(www.text);
            foreach (JSONObject j in usersData.list)
            {
                
                //every j is a unique user
                //check if the user is already in the scene
                GameObject temp = null;
                int unityposx = IntParseFast(j["mercatorx"].ToString());
                int unityposy = IntParseFast(j["mercatory"].ToString());

                Vector2 tempv2 = new Vector2(unityposx, unityposy);
                tempotherpplv3 = ( tempv2- centertiletms).ToVector3xz();
                if (GameManager.Instance.otherppl.TryGetValue(j["user_name"].ToString(),out temp))
                {
                    //yes, check its position, move it
                    temp.transform.position = Vector3.MoveTowards(temp.transform.position, tempotherpplv3, 1);
                }
                else
                {
                    //no, make it into the scene
                    GameObject tempotherppl = (Instantiate(otherpplPrefab, tempotherpplv3, this.transform.rotation) as GameObject);
                    tempotherppl.GetComponent<OtherPplBehavior>().yournametxt.text = j["user_name"].ToString();
                    tempotherppl.transform.GetChild(0).GetComponent<UIfaceCamera>().SourceCamera = maincamera;
                    GameManager.Instance.otherppl.Add(j["user_name"].ToString(), tempotherppl);
                }
                
                
            }
            
        }
        else
        {
            Debug.Log("update position fail");
        }
    }

    void OnApplicationQuit()
    {
        logouturl = logouturl + GameManager.Instance.username;
        StartCoroutine(logoutuser());
        Application.CancelQuit();
        
    }

    IEnumerator logoutuser()
    {
        WWW wwww = new WWW(logouturl);
        yield return wwww;
        if (wwww.error == null)
        {
            GameManager.Instance.logined = true;
            Debug.Log("logout success");
        }
        else
        {
            Debug.Log("login fail");
        }
        Application.Quit();
    }
}
