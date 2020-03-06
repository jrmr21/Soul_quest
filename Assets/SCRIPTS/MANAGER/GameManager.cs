using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool        GameIsReady = true;
    private bool        flag = true;

    // manager declaration
    public GameObject   M_map;


    // Start is called before the first frame update
    /*
     a 	b   R  (a & b)
    0 	0 	0
    0 	1 	0
    1 	0 	0
    1 	1 	1
     * */
    void Start()
    {
        this.GameIsReady    &= M_map.GetComponent<map_manager>().init_MapManager();
        this.GameIsReady    &= this.GetComponent<Shop_manager>().init_ShopManager();
        this.GameIsReady    &= this.GetComponent<main_manager>().init_MainManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GameIsReady)
        {
            if (flag)
            {
                GameObject t;
                t = this.GetComponent<Shop_manager>().GetRandomSpirit();
                this.GetComponent<main_manager>().AddToMain(ref t);

                t = this.GetComponent<Shop_manager>().GetRandomSpirit();
                this.GetComponent<main_manager>().AddToMain(ref t);

                flag =! flag;
            }
        }
    }
}
