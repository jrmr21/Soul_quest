using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_manager : MonoBehaviour
{
    private List<GameObject> ShopListObject;
    private bool            status = false;

    
    public bool GetStatus()
    {
        return (this.status);
    }

    public bool init_ShopManager()
    {
#if (UNITY_DEBUG_SHOP_MANAGER)
        Debug.Log("init Shop Manager");
#endif
        ShopListObject = new List<GameObject>();

        this.status = true;
        return (true);
    }

    public bool add_ShopManager()
    {
        return (true);
    }
}