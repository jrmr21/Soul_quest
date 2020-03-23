using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spirit_brain : MonoBehaviour
{
    private GameObject Master;
    private Spirit scriptableObject;

    private ProgressBarCircle Pb;
    private string m_name;
    private float life;
    private Team team;
    private GameObject skin;

    private bool EnableTouch = true;
    private bool touchAct = false;
    private Collider coll;
    private RaycastHit hit;
    private Ray ray;


    public bool InitPrefab(GameObject Master, ref Spirit data)
    {
        // get tools
        this.Master = Master;
        this.scriptableObject = data;

        // change name
        this.transform.name = this.scriptableObject.name;

        // set data
        this.m_name = this.scriptableObject.name;
        this.life   = this.scriptableObject.life;
        this.team   = this.scriptableObject.team;

        coll = this.GetComponentInChildren<Collider>();

        // create skin
        this.skin = Instantiate(this.scriptableObject.skin);
        this.skin.transform.parent = this.gameObject.transform;

        // move skin at 0, 0, 0
        this.skin.transform.position = this.transform.position;

        return (true);
    }

    public float GetLife()
    {
        return (this.life);
    }

    public string GetName()
    {
        return (this.m_name);
    }

    public Team GetTeam()
    {
        return (this.team);
    }

    public void SetPosition(Vector3 vector)
    {
#if (UNITY_DEBUG_BRAIN_DETAILS)
        Debug.Log("move Spirit at " + vector);
#endif
        this.gameObject.transform.position += vector;
    }

    public void SetDragAndDrop(bool status)
    {
        this.EnableTouch = status;
    }

    /*      mouse version
    private void DragAndDrop()
    {
        this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        if (Input.GetMouseButtonDown(0))
        {
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                touchAct = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchAct = false;
        }
        if (touchAct == true)
        {
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                transform.position = new Vector3(this.hit.point.x, this.hit.point.y + 2f, this.hit.point.z);
                if (this.hit.point.x < -3 && this.hit.point.x > -4)
                {
                    transform.position = new Vector3(-3.5f, this.hit.point.y + 2f, this.hit.point.z);
                }
                Debug.Log(this.hit.point.x);
            }
        }
    }*/

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
                    if (coll.Raycast(ray, out hit, 100.0f))
                    {
                        touchAct = true;
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                {
                    touchAct = false;
                }
            }
            if (touchAct == true)
            {
                if (Physics.Raycast(ray, out hit, 100, layerMask))
                {
                    transform.position = new Vector3(this.hit.point.x, this.hit.point.y + 2f, this.hit.point.z);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.EnableTouch)
        {
            DragAndDrop();
        }
    }
}
