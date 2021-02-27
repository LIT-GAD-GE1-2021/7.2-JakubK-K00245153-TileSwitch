using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoSwitchController : MonoBehaviour
{
    private bool switchOff = true;
    public GameObject greentile;
    public GameObject redtile;
    public LevelManager LM;
    void Awake()
    {
        turnOff();
    }

    public void turnOn()
    {
        switchOff = false;
        LM.SwitchTile();
        Debug.Log("Someone entered the switch trigger");
    }

    public void turnOff()
    {
        switchOff = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.turnOn();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        this.turnOff();
    }
}

