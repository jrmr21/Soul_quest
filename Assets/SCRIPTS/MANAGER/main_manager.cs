using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_manager : SpiritList
{
    //private static bool        status      = false;
    private Vector3     MainPos;
    private int         money       = 4;
    private int Life = 100;

    public GameObject   MapMain;

    public bool init_MainManager(GameObject map)
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
            if (this.AddListObject(ref spirit))
            {
#if (UNITY_DEBUG_MAIN_MANAGER_DETAILS)
                Debug.Log("SUCCES to ADD " + spirit.name);
#endif
                this.ListObject[0][this.GetListSize() - 1].GetComponent<spirit_brain>().SetPosition(
                    this.MapMain.transform.GetChild(this.GetListSize() - 1).transform.position);

                if (string.Compare(GlobalVar.player_front, this.transform.parent.name) == 0)
                {
                    this.ListObject[0][this.GetListSize() - 1].transform.Rotate(0, 180, 0);
                }

                this.ListObject[0][this.GetListSize() - 1].GetComponent<spirit_brain>().AttachToParent(this.gameObject);

                return (true);
            }
        }
#if (UNITY_DEBUG_MAIN_MANAGER_DETAILS)
        Debug.Log("FAIL to ADD spirit !! ");
#endif
        return (false);
    }



    public int GetMoney()
    {
        return (this.money);
    }

    public void SetMoney(int val)
    {
        this.money = val;
    }

    public int GetLife()
    {
        return (this.Life);
    }


}