using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool        GameIsReady = true;
    public GameObject  SpiritPefab;
    public  Spirit[]    scriptableObject;

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

        for (int i = 0; i < 2; i++)
        {
            GameObject test = Instantiate(SpiritPefab, new Vector3(2000 + (i *5), 2000, 0), Quaternion.identity);
            test.GetComponent<spirit_brain>().InitPrefab(this.gameObject, this.scriptableObject[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GameIsReady)
        {

        }
    }
}
