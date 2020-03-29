using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool        GameIsReady = true;
    private bool        flag        = true;

    private int     flag_mode       = 0;
    private string  current_time    = "00";
    private double  start_time;
    private Text    text_cpt;

    public int fight_time       = 0;
    public int prepare_time     = 0;

    // manager declaration
    public  GameObject  M_map;

        // two players gameObject with all compomnent ( main map, fight map, main manager)
    public  GameObject  Player_back     = null;
    public  GameObject  Player_front    = null;

        // all UI
    public GameObject Canevas;


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

        this.start_time     = Time.time;

            // set count displayer
        this.text_cpt = this.Canevas.gameObject.transform.GetChild(2).GetComponentInChildren<Text>();
        this.text_cpt.text = current_time;

            // init all managers
        this.GameIsReady    &= M_map.GetComponent<map_manager>().init_MapManager();
        this.GameIsReady    &= this.GetComponent<Shop_manager>().init_ShopManager();
        this.GameIsReady    &= this.GetComponent<Touch_manager>().init_TouchManager();
        this.GameIsReady    &= this.GetComponent<Fight_manager>().init_FightManager();

            // init "main_map" in main manager
        this.GameIsReady    &= this.Player_back.transform.GetChild(0).GetComponent <main_manager>().init_MainManager(
            this.Player_back.transform.GetChild(0).GetChild(0).gameObject);

        this.GameIsReady    &= this.Player_front.transform.GetChild(0).GetComponent <main_manager>().init_MainManager(
            this.Player_front.transform.GetChild(0).GetChild(0).gameObject);


#if (UNITY_DEBUG_MANAGER)
        if (this.GameIsReady)
        {
            Debug.Log("SUCCES GAME-MANAGER INIT");
        }
        else
        {
            Debug.Log("FAIL GAME-MANAGER INIT !!!");
        }
#endif
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
                    this.Player_back.transform.GetChild(0).GetComponent<main_manager>().AddToMain(ref t);

                    t = this.GetComponent<Shop_manager>().GetRandomSpirit();
                    t.GetComponent<spirit_brain>().SetDragAndDrop(false);
                    this.Player_front.transform.GetChild(0).GetComponent<main_manager>().AddToMain(ref t);
                }

                flag =! flag;
            }


                // Prepare Mode
            if (this.flag_mode == 0)
            {
                if (((int)(Time.time - start_time)) > this.prepare_time)
                {
                    this.GetComponent<Touch_manager>().set_EnableTouch(false);

                    this.Canevas.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    this.Canevas.gameObject.transform.GetChild(1).gameObject.SetActive(false);

                    this.GetComponent<Fight_manager>().StartFightMode();

                    flag_mode   = 1;              //  go to fight mode
                    start_time  = Time.time;
                }
                else
                {
                    current_time = (this.prepare_time - ((int)(Time.time - start_time))).ToString();
                }
            }
                // Fight Mode
            else if(this.flag_mode == 1)
            {
                if (((int)(Time.time - start_time)) > this.fight_time)
                {
                    this.GetComponent<Touch_manager>().set_EnableTouch(true);

                    this.Canevas.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    this.Canevas.gameObject.transform.GetChild(1).gameObject.SetActive(true);

                    this.GetComponent<Fight_manager>().EndFightMode();

                    flag_mode   = 0;              //  go to prepare mode
                    start_time  = Time.time;
                }
                else
                {
                    current_time = (this.fight_time - ((int)(Time.time - start_time))).ToString();
                }
            }
            else
            {
                // future template
            }

            this.text_cpt.text = current_time;
        }
    }
}
