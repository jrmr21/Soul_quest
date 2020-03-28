using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_manager : MonoBehaviour
{
    private bool        EnableTouch = false;

    private RaycastHit  hit;
    private Ray         ray;
    private Collider    coll;
    private GameObject  character;


    public bool init_TouchManager()
    {
        this.EnableTouch = true;

        return (true);
    }

    public void set_EnableTouch(bool status)
    {
        this.EnableTouch = status;
    }


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
                try
                {
                    //Debug.Log("cible1 " + this.hit.transform.parent.name);
                    character = this.hit.transform.gameObject ;
                    character.GetComponent<spirit_brain>().SetDragAndDrop(true);
                }
                catch
                {
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
                        Debug.Log("cible1 " + this.hit.transform.name);
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
#if (UNITY_FINGER_MODE || UNITY_MOUSE_MODE)
        if (this.EnableTouch)
        {
            DragAndDrop();
        }
#endif
    }
}
