using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_manager : SpiritList
{
    public  GameObject  SpiritPefab;
    private GameObject  Canvas;

    // [Header("Scriptable Object:")]
    public  Spirit[]         m_scriptableObject;
    public  PictureShop      m_pictureShop;

    //  shop canevas status
    private bool            status      = false;

    //  tmp player
    private main_manager    TmpPlayer    = null;

    // button to enable shop
    private Button          BackButton;

    private Button[]        buttonCharacter;



    // need shop canvas
    public bool init_ShopManager(GameObject ui)
    {
#if (UNITY_DEBUG_SHOP_MANAGER)
        Debug.Log("init Shop Manager");
#endif
            // create list of gameObject
        this.InitList(2);

        this.Canvas = ui;

        this.BackButton = this.Canvas.transform.GetChild(1).GetComponent<Button>();

        // set listener button 
        this.BackButton.onClick.AddListener(disableShop);

        for (int i = 0; i < GlobalVar.MaxShopCharacter; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            this.Canvas.transform.GetChild(2).GetChild(i).GetComponentInChildren <Button>().onClick.AddListener(() => TaskOnClick(closureIndex));
        }

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


    public void TaskOnClick(int buttonIndex)
    {
        GameObject characterYouWant = this.PopListObject(buttonIndex, 1);

#if (UNITY_DEBUG_SHOP_MANAGER_DETAILS)
        Debug.Log("You have clicked the button #" + buttonIndex);
        Debug.Log("price " + characterYouWant.GetComponentInChildren<spirit_brain>().GetPrice() +
             " name " + characterYouWant.GetComponentInChildren<spirit_brain>().GetName());
#endif

            // check if you can buy
        if (characterYouWant.GetComponentInChildren<spirit_brain>().GetPrice() <=
             TmpPlayer.GetMoney())
        {
            // try to add to main
            if (TmpPlayer.AddToMain(ref characterYouWant))
            {
                TmpPlayer.SetMoney(TmpPlayer.GetMoney() - characterYouWant.GetComponentInChildren<spirit_brain>().GetPrice());
            }
            this.disableShop();
        }
        else
        {
            // show fail here
        }
    }

    public void initShopDisplay()
    {
        GameObject t = null;
        
        // warnning, not secure ton end SHOP !!
        for (int i = 0; i < GlobalVar.MaxShopCharacter; i++)
        {
            t = this.GetRandomSpirit();

            AddListObject(ref t, 1);  // WTF ?!! you can accept an null Object ?!!!

            this.Canvas.transform.GetChild(2).GetChild(i).GetComponentInChildren<Image>().sprite = 
               m_pictureShop.ListPicture[this.CheckName(t.GetComponent<spirit_brain>().GetName())];

            this.Canvas.transform.GetChild(2).GetChild(i).GetChild(0).GetComponentInChildren<Text>().text =
                t.GetComponent<spirit_brain>().GetPrice().ToString();
        }

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
        this.TmpPlayer  = null;

        int size        = this.GetListSize(1);
        GameObject t    = null;
        
        // warnning, not secure ton end SHOP !!
        // clear "Show table" and move character in table of shop
        for (int i = size; i > 0; i--)
        {
            t = this.PopListObject(i - 1, 1);

            AddListObject(ref t);
        }
        this.Canvas.SetActive(false);
    }

    public void SetDisplayMoney()
    {
        Canvas.transform.GetChild(4).GetComponentInChildren<Text>().text = TmpPlayer.GetMoney().ToString();
    }

    public void enableShop(main_manager client)
    {
        initShopDisplay();
        this.TmpPlayer = client;

        this.Canvas.SetActive(true);
        this.SetDisplayMoney();
    }

    private int CheckName(string name)
    {
        for (int j = 0; j < m_pictureShop.ListName.Length; j++)
        {
            if (string.Compare(name, m_pictureShop.ListName[j]) == 0)
            {
                return (j);
            }
        }
        return (0);
    }
}
