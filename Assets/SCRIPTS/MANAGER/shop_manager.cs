using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_manager : SpiritList
{
    private bool                status = false;

    public GameObject           SpiritPefab;
    public GameObject           Canvas;

    // [Header("Scriptable Object:")]
    public Spirit[]            m_scriptableObject;


    // button to enable shop
    private Button BackButton;

    // need shop canvas
    public bool init_ShopManager(GameObject ui)
    {
#if (UNITY_DEBUG_SHOP_MANAGER)
        Debug.Log("init Shop Manager");
#endif
            // create list of gameObject
        this.InitList();

        this.Canvas = ui;

        this.BackButton = this.Canvas.transform.GetChild(1).GetComponent<Button>();

        // set listener button 
        this.BackButton.onClick.AddListener(disableShop);

        for (int i = 0; i < GlobalVar.SizeOfIthem; i++)     // count differents type of character
        {
            for (int j = 0; j < GlobalVar.SizeOfFusion; j++)    // count multiple character for fusion
            {
                // create spirit
                //GameObject NewSpirit = new GameObject();

                GameObject NewSpirit = Instantiate(SpiritPefab, new Vector3(0, 0, 0), Quaternion.identity);

                // add skin to spirit
                NewSpirit.GetComponent<spirit_brain>().InitPrefab(this.gameObject, ref this.m_scriptableObject[i]);
                
                // add new spirit to shop's list
                this.AddListObject(ref NewSpirit);
            }
#if (UNITY_DEBUG_SHOP_MANAGER_DETAILS)
            Debug.Log("create 9: " + this.scriptableObject[i].name);
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

    public void disableShop()
    {
        this.Canvas.SetActive(false);
    }
}