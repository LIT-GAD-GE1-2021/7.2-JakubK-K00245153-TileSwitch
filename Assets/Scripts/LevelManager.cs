using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    public GameObject tilemapRed;
    public GameObject tilemapGreen;
    private bool greenOn = true;
    private bool redOn = false;

    private void Awake()
    {
        instance = this;
    }

    public void GreenOff()
    {
        tilemapGreen.SetActive(false);
        tilemapRed.SetActive(true);
    }

    public void RedOff()
    {
        tilemapGreen.SetActive(true);
        tilemapRed.SetActive(false);
    }

    public void SwitchTile()
    {
        if (greenOn == true)
        {
            greenOn = false;
        }
        else if (greenOn == false)
        {
            greenOn = true;
        }

        if(greenOn == true)
        {
            RedOff();
        }
        else if (greenOn == false)
        {
            GreenOff();
        }
    }
}
