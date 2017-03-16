using UnityEngine;
using System.Collections;

public class UIfaceCamera : MonoBehaviour {

    public Camera SourceCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = SourceCamera.transform.rotation;
    }
}
