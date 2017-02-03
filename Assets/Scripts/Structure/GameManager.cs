using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{

    protected GameManager() { } //good coding practices right here fucker

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
