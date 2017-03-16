using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{

    protected GameManager() { } //good coding practices right here fucker
    public GameObject yourselfavatar;

    public string username;
    public bool logined = false;

    


    //others
    public Dictionary<string,GameObject> otherppl = new Dictionary<string,GameObject>();

    public void replay()
    {
        Application.LoadLevel(1);
    }

    public void lose()
    {
        Application.LoadLevel(2);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
