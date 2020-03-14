﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool        GameIsReady = true;
    private bool        flag        = true;

    // manager declaration
    public  GameObject  M_map;
    public  GameObject  Player_main;
    public  GameObject  IA_main;

    // main map
    public GameObject   MapMain1;
    public GameObject   MapMain2;


    // Start is called before the first frame update
    /*
     a 	b   R  (a & b)
    0 	0 	0
    0 	1 	0       this is the table of true to set this.GameIsReady
    1 	0 	0       because it's a flag to run the game.
    1 	1 	1
     * */
    void Start()
    {
        Screen.SetResolution(1280, 720, true);

        this.GameIsReady    &= M_map.GetComponent<map_manager>().init_MapManager();
        this.GameIsReady    &= this.GetComponent<Shop_manager>().init_ShopManager();

        this.GameIsReady    &= this.Player_main.GetComponent <main_manager>().init_MainManager(ref this.MapMain1);
        this.GameIsReady    &= this.IA_main.GetComponent<main_manager>().init_MainManager(ref this.MapMain2);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GameIsReady)
        {
            if (flag)
            {
                GameObject t;

                for (int i = 0; i < GlobalVar.MaxSpiritMain; i++)
                {
                    t = this.GetComponent<Shop_manager>().GetRandomSpirit();
                    this.Player_main.GetComponent<main_manager>().AddToMain(ref t);

                    t = this.GetComponent<Shop_manager>().GetRandomSpirit();
                    t.GetComponent<spirit_brain>().SetDragAndDrop(false);
                    this.IA_main.GetComponent<main_manager>().AddToMain(ref t);
                }

                flag =! flag;
            }
        }
    }
}
