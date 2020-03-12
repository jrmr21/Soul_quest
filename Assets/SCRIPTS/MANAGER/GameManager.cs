using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool        GameIsReady = true;
    private bool        flag        = true;

    // manager declaration
    public  GameObject  M_map;

        // main map
    public GameObject   MapMain1;
    public GameObject   MapMain2;

    private main_manager Player_main    = new main_manager();
    private main_manager IA_main        = new main_manager();


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
        this.GameIsReady    &= M_map.GetComponent<map_manager>().init_MapManager();
        this.GameIsReady    &= this.GetComponent<Shop_manager>().init_ShopManager();

        this.GameIsReady    &= this.Player_main.init_MainManager(ref this.MapMain1);
        this.GameIsReady    &= this.IA_main.init_MainManager(ref this.MapMain2);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GameIsReady)
        {
            if (flag)
            {
                GameObject t;

                for (int i = 0; i < 4; i++)
                {
                    t = this.GetComponent<Shop_manager>().GetRandomSpirit();
                    this.Player_main.AddToMain(ref t);

                    t = this.GetComponent<Shop_manager>().GetRandomSpirit();
                    this.IA_main.AddToMain(ref t);
                }

                flag =! flag;
            }
        }
    }
}
