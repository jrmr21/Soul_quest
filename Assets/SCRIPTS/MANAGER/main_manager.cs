using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_manager : SpiritList
{
    private bool        status      = false;
    private Vector3     MainPos;
    private float       step        = 1.52f;

    public GameObject   MapMain;

    public bool init_MainManager(ref GameObject map)
    {
#if (UNITY_DEBUG_MAIN_MANAGER)
        Debug.Log("init Main Manager");
#endif
            // create list of spirit
        this.InitList();

        this.MapMain = map;

        return (true);
    }

    public bool AddToMain(ref GameObject spirit)
    {
        if (this.GetListSize() < GlobalVar.MaxSpiritMain)
        {
            this.AddListObject(ref spirit);
            this.ListObject[(this.GetListSize() - 1)].GetComponent<spirit_brain>().SetPosition(
                this.MapMain.transform.GetChild(this.GetListSize() - 1).transform.position);

            return (true);
        }
        else
        {
            return (false);
        }
    }

}
