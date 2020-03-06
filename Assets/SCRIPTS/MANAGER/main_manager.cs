using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_manager : SpiritList
{
    private bool status = false;
    private float start_pos = 0;


    public bool init_MainManager()
    {
#if (UNITY_DEBUG_MAIN_MANAGER)
        Debug.Log("init Main Manager");
#endif

            // create list of spirit
        this.InitList();

        return (true);
    }

    public void AddToMain(ref GameObject spirit)
    {
        Vector3 v = new Vector3(1994.7f + start_pos, 2000, -5.34f);

        this.start_pos += 1.35f;

        this.AddListObject(ref spirit);
        this.ListObject[(this.GetListSize() - 1)].GetComponent<spirit_brain>().SetPosition(v);

        Debug.Log("my size " + this.GetListSize() + " my name " + this.ListObject[(this.GetListSize() - 1)].GetComponent<spirit_brain>().GetName());
    }

}
