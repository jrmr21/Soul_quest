using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_manager : SpiritList
{
    private bool                status = false;

    public GameObject           SpiritPefab;

    [Header("Scriptable Object:")]
    public Spirit[]             scriptableObject;


    public bool init_ShopManager()
    {
#if (UNITY_DEBUG_SHOP_MANAGER)
        Debug.Log("init Shop Manager");
#endif
            // create list of gameObject
        this.InitList();


        for (int i = 0; i < GlobalVar.SizeOfIthem; i++)     // count differents type of character
        {
            Spirit _test = (Spirit)ScriptableObject.CreateInstance(typeof(Spirit));
            _test = this.scriptableObject[i];


            for (int j = 0; j < GlobalVar.SizeOfFusion; j++)    // count multiple character for fusion
            {
                // create spirit
                GameObject NewSpirit = Instantiate(SpiritPefab, new Vector3(0, 0, 0), Quaternion.identity);
                
                // add skin to spirit
                NewSpirit.GetComponent<spirit_brain>().InitPrefab(this.gameObject, ref _test);
                
                // add new spirit to shop's list
                this.AddListObject(ref NewSpirit);
            }
#if (UNITY_DEBUG_SHOP_MANAGER_DETAILS)
            Debug.Log("create 3: " + this.scriptableObject[i].name);
#endif
        }
        
            // small checking
        if (this.GetListSize() == (GlobalVar.SizeOfFusion * GlobalVar.SizeOfIthem))
        {
#if (UNITY_DEBUG_SHOP_MANAGER)
            Debug.Log("succes to create " + this.GetListSize() + " Spirits");
#endif
            this.status = true;
        }
        else
        {
#if (UNITY_DEBUG_SHOP_MANAGER)
            Debug.Log("FAIL to create Spirits...");
#endif
            this.status = false;
        }
        return (this.status);
    }
    
    public GameObject GetRandomSpirit()
    {
        return (this.PopRandomListObject());
    }

    public bool GetStatus()
    {
        return (this.status);
    }
}