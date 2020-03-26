using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool        GameIsReady = true;
    private bool        flag        = true;

    private RaycastHit hit;
    private Ray ray;
    private Collider coll;

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


    private GameObject character;

    // use mouse
#if (UNITY_MOUSE_MODE)
    private void DragAndDrop()
    {
        this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                 //Debug.Log("cible1 " + this.hit.transform.name);
                        try
                        {
                            Debug.Log("cible1 " + this.hit.transform.name);
                            character = this.hit.transform.gameObject;
                            character.GetComponent<spirit_brain>().SetDragAndDrop(true);
                        }
                        catch
                        {
                            Debug.Log("ciff");
                            character = null;
                        }
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            //character.GetComponent<spirit_brain>().SetDragAndDrop(false);
            character = null;
        }
    }
#endif

    // use finger
#if (UNITY_FINGER_MODE)
    private void DragAndDrop()
    {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        if (Input.touchCount > 0)
        {
            this.ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (Physics.Raycast(ray, out hit, 100, layerMask))
                    {
                        //Debug.Log("cible1 " + this.hit.transform.name);
                        try
                        {
                            Debug.Log("cible1 " + this.hit.transform.name);
                            character = this.hit.transform.gameObject;
                            character.GetComponent<spirit_brain>().SetDragAndDrop(true);
                        }
                        catch
                        {
                            Debug.Log("ciff");
                            character = null;
                        }
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                {
                    //character.GetComponent<spirit_brain>().SetDragAndDrop(false);
                    character = null;
                }
            }
        }
    }
#endif

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

#if (UNITY_FINGER_MODE || UNITY_MOUSE_MODE)
            DragAndDrop();
#endif
        }
    }
}
