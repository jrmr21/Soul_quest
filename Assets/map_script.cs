using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class map_script : MonoBehaviour
{
    // default we have 1 object
    public GameObject[] item    = new GameObject[1];
    public int[] time_item      = new int[1];

    // Start is called before the first frame update
    void Start()
    {
           // set default résolution
        Screen.SetResolution(1280, 720, true);

            // connect this object t with the objet "timer_script" in timer component 
        //t = timer_panel.GetComponent<timer_script>();
        //t.edit_text(" ");                          // init value to display

        //this.start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * this.game_time = (int)(Time.time - start_time);
  
        if (this.game_time > shop_time)
        {
            this.mod_fight_hero();
            
                // reset timer at 15s
            if (this.game_time > fight_time)
                this.start_time = Time.time;
        }
        else
        {
            this.mod_select_hero(this.game_time);
        }

        Debug.Log(this.game_time);
        */
    }

    private void mod_select_hero(int delay)
    {
        /*
            // if timer and heroes panel aren't present when you launch the round (select hero mod) you enable pannel
        if ((timer_panel.activeInHierarchy & heroes_panel.activeInHierarchy) == false)
        {
            timer_panel.SetActive(true);
            heroes_panel.SetActive(true);
        }
        else
        {
                // if all panel are here, you display dela-time to select your hero
            this.t.edit_text((shop_time - delay).ToString());
        }
        */
    }

    private void mod_fight_hero()
    {
        /*
            // if timer and heroes panel are present when you launch the round (fight game) you disable pannel
        if ((timer_panel.activeInHierarchy & heroes_panel.activeInHierarchy) == true)
        {
            timer_panel.SetActive(false);
            heroes_panel.SetActive(false);
        }
        */
    }
}
