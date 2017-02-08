using UnityEngine;
using Assets.Helpers;
using System.Collections;

public class GPSmovemen : MonoBehaviour {
    public string gps_info = "";
    public int flash_num = 1;

    public float curlatitude;
    public float curlongitude;
    private Vector2 selfposition;
    private Vector2 originposition;
    private Vector3 targetmovement;
    // Use this for initialization
    void Start () {
        if (!Input.location.isEnabledByUser)
        {
            this.gps_info = "isEnabledByUser value is:" + Input.location.isEnabledByUser.ToString() + " Please turn on the GPS";
            
        }
        Input.location.Start(10.0f, 10.0f);
        //record start position
        curlatitude = Input.location.lastData.latitude;
        curlongitude = Input.location.lastData.longitude;
        originposition= GM.LatLonToMeters(curlatitude, curlongitude);
        //make it as the origin point
    }
	
	// Update is called once per frame
	void Update () {
        curlatitude = Input.location.lastData.latitude;
        curlongitude = Input.location.lastData.longitude;
        //current mercator position
        selfposition=GM.LatLonToMeters(curlatitude, curlongitude);

        targetmovement = (selfposition - originposition).ToVector3xz();

        this.transform.position = Vector3.MoveTowards(transform.position,targetmovement,1);

	}

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 600, 48), this.selfposition.ToString());
        GUI.Label(new Rect(20, 50, 600, 48), this.targetmovement.ToString());
    }
}
