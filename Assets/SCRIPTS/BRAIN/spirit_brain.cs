using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spirit_brain : MonoBehaviour
{
    private GameObject Master;
    private Spirit scriptableObject;

    private ProgressBarCircle Pb;
    private string name;
    private float life;
    private Team team;
    private GameObject skin;

    private bool EnableTouch = true;
    private bool touchAct = false;
    private Collider coll;
    private RaycastHit hit;
    private Ray ray;


    public bool InitPrefab(GameObject Master, Spirit data)
    {
        // get tools
        this.Master = Master;
        this.scriptableObject = data;

        // change name
        this.transform.name = this.scriptableObject.name;

        // set data
        this.name = this.scriptableObject.name;
        this.life = this.scriptableObject.life;
        this.team = this.scriptableObject.team;

        coll = this.GetComponentInChildren<Collider>();

        // create skin
        this.skin = Instantiate(this.scriptableObject.skin) as GameObject;
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
        return (this.name);
    }

    public Team GetTeam()
    {
        return (this.team);
    }

    public void SetPosition(Vector3 vector)
    {
        this.gameObject.transform.position += vector;
    }

    public void SetDragAndDrop(bool status)
    {
        this.EnableTouch = status;
    }

    //     mouse version
    private void DragAndDrop()
    {
        float decalageX = 1.475f;
        int Xinit = 1994;
        float Xcenter = 1994.7375f;

        float decalageZ = 1.425f;
        float Zinit = -5.8f;
        float Zcenter = -5.0875f;


        this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << 9;
        layerMask = ~layerMask;


        if (Input.GetMouseButtonDown(0))
        {
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                touchAct = true;
            }
            Debug.Log(hit.transform.tag);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchAct = false;
        }
        if (touchAct == true)
        {
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                Debug.Log(tag);
                transform.position = new Vector3(this.hit.point.x, this.hit.point.y + 2f, this.hit.point.z);
            }
        } else if (touchAct == false)
        {
            if (this.hit.point.y > 1999.9999 && this.hit.point.y < 2000.0001)
            {
                if (this.hit.point.x > Xinit && this.hit.point.x < Xinit + (decalageX) && this.hit.point.z > Zinit && this.hit.point.z < Zinit + (decalageZ))
                {
                    transform.position = new Vector3(Xcenter, this.hit.point.y, Zcenter);
                }
                if (this.hit.point.x > Xinit && this.hit.point.x < Xinit + (decalageX) && this.hit.point.z > Zinit + (decalageZ) && this.hit.point.z < Zinit + (decalageZ * 2))
                {
                    transform.position = new Vector3(Xcenter, this.hit.point.y, Zcenter + (decalageZ));
                }
                if (this.hit.point.x > Xinit && this.hit.point.x < Xinit + (decalageX) && this.hit.point.z > Zinit + (decalageZ * 2) && this.hit.point.z < Zinit + (decalageZ * 3))
                {
                    transform.position = new Vector3(Xcenter, this.hit.point.y, Zcenter + (decalageZ * 2));
                }
                if (this.hit.point.x > Xinit && this.hit.point.x < Xinit + (decalageX) && this.hit.point.z > Zinit + (decalageZ * 3) && this.hit.point.z < Zinit + (decalageZ * 4))
                {
                    transform.position = new Vector3(Xcenter, this.hit.point.y, Zcenter + (decalageZ * 3));
                }


                if (this.hit.point.x > Xinit + (decalageX) && this.hit.point.x < Xinit + (decalageX * 2) && this.hit.point.z > Zinit && this.hit.point.z < Zinit + (decalageZ))
                {
                    transform.position = new Vector3(Xcenter + (decalageX), this.hit.point.y, Zcenter);
                }
                if (this.hit.point.x > Xinit + (decalageX) && this.hit.point.x < Xinit + (decalageX * 2) && this.hit.point.z > Zinit + (decalageZ) && this.hit.point.z < Zinit + (decalageZ * 2))
                {
                    transform.position = new Vector3(Xcenter + (decalageX), this.hit.point.y, Zcenter + (decalageZ));
                }
                if (this.hit.point.x > Xinit + (decalageX) && this.hit.point.x < Xinit + (decalageX * 2) && this.hit.point.z > Zinit + (decalageZ * 2) && this.hit.point.z < Zinit + (decalageZ * 3))
                {
                    transform.position = new Vector3(Xcenter + (decalageX), this.hit.point.y, Zcenter + (decalageZ * 2));
                }
                if (this.hit.point.x > Xinit + (decalageX) && this.hit.point.x < Xinit + (decalageX * 2) && this.hit.point.z > Zinit + (decalageZ * 3) && this.hit.point.z < Zinit + (decalageZ * 4))
                {
                    transform.position = new Vector3(Xcenter + (decalageX), this.hit.point.y, Zcenter + (decalageZ * 3));
                }


                if (this.hit.point.x > Xinit + (decalageX * 2) && this.hit.point.x < Xinit + (decalageX * 3) && this.hit.point.z > Zinit && this.hit.point.z < Zinit + (decalageZ))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 2), this.hit.point.y, Zcenter);
                }
                if (this.hit.point.x > Xinit + (decalageX * 2) && this.hit.point.x < Xinit + (decalageX * 3) && this.hit.point.z > Zinit + (decalageZ) && this.hit.point.z < Zinit + (decalageZ * 2))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 2), this.hit.point.y, Zcenter + (decalageZ));
                }
                if (this.hit.point.x > Xinit + (decalageX * 2) && this.hit.point.x < Xinit + (decalageX * 3) && this.hit.point.z > Zinit + (decalageZ * 2) && this.hit.point.z < Zinit + (decalageZ * 3))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 2), this.hit.point.y, Zcenter + (decalageZ * 2));
                }
                if (this.hit.point.x > Xinit + (decalageX * 2) && this.hit.point.x < Xinit + (decalageX * 3) && this.hit.point.z > Zinit + (decalageZ * 3) && this.hit.point.z < Zinit + (decalageZ * 4))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 2), this.hit.point.y, Zcenter + (decalageZ * 3));
                }


                if (this.hit.point.x > Xinit + (decalageX * 3) && this.hit.point.x < Xinit + (decalageX * 4) && this.hit.point.z > Zinit && this.hit.point.z < Zinit + (decalageZ))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 3), this.hit.point.y, Zcenter);
                }
                if (this.hit.point.x > Xinit + (decalageX * 3) && this.hit.point.x < Xinit + (decalageX * 4) && this.hit.point.z > Zinit + (decalageZ) && this.hit.point.z < Zinit + (decalageZ * 2))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 3), this.hit.point.y, Zcenter + (decalageZ));
                }
                if (this.hit.point.x > Xinit + (decalageX * 3) && this.hit.point.x < Xinit + (decalageX * 4) && this.hit.point.z > Zinit + (decalageZ * 2) && this.hit.point.z < Zinit + (decalageZ * 3))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 3), this.hit.point.y, Zcenter + (decalageZ * 2));
                }
                if (this.hit.point.x > Xinit + (decalageX * 3) && this.hit.point.x < Xinit + (decalageX * 4) && this.hit.point.z > Zinit + (decalageZ * 3) && this.hit.point.z < Zinit + (decalageZ * 4))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 3), this.hit.point.y, Zcenter + (decalageZ * 3));
                }


                if (this.hit.point.x > Xinit + (decalageX * 4) && this.hit.point.x < Xinit + (decalageX * 5) && this.hit.point.z > Zinit && this.hit.point.z < Zinit + (decalageZ))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 4), this.hit.point.y, Zcenter);
                }
                if (this.hit.point.x > Xinit + (decalageX * 4) && this.hit.point.x < Xinit + (decalageX * 5) && this.hit.point.z > Zinit + (decalageZ) && this.hit.point.z < Zinit + (decalageZ * 2))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 4), this.hit.point.y, Zcenter + (decalageZ));
                }
                if (this.hit.point.x > Xinit + (decalageX * 4) && this.hit.point.x < Xinit + (decalageX * 5) && this.hit.point.z > Zinit + (decalageZ * 2) && this.hit.point.z < Zinit + (decalageZ * 3))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 4), this.hit.point.y, Zcenter + (decalageZ * 2));
                }
                if (this.hit.point.x > Xinit + (decalageX * 4) && this.hit.point.x < Xinit + (decalageX * 5) && this.hit.point.z > Zinit + (decalageZ * 3) && this.hit.point.z < Zinit + (decalageZ * 4))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 4), this.hit.point.y, Zcenter + (decalageZ * 3));
                }


                if (this.hit.point.x > Xinit + (decalageX * 5) && this.hit.point.x < Xinit + (decalageX * 6) && this.hit.point.z > Zinit && this.hit.point.z < Zinit + (decalageZ))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 5), this.hit.point.y, Zcenter);
                }
                if (this.hit.point.x > Xinit + (decalageX * 5) && this.hit.point.x < Xinit + (decalageX * 6) && this.hit.point.z > Zinit + (decalageZ) && this.hit.point.z < Zinit + (decalageZ * 2))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 5), this.hit.point.y, Zcenter + (decalageZ));
                }
                if (this.hit.point.x > Xinit + (decalageX * 5) && this.hit.point.x < Xinit + (decalageX * 6) && this.hit.point.z > Zinit + (decalageZ * 2) && this.hit.point.z < Zinit + (decalageZ * 3))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 5), this.hit.point.y, Zcenter + (decalageZ * 2));
                }
                if (this.hit.point.x > Xinit + (decalageX * 5) && this.hit.point.x < Xinit + (decalageX * 6) && this.hit.point.z > Zinit + (decalageZ * 3) && this.hit.point.z < Zinit + (decalageZ * 4))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 5), this.hit.point.y, Zcenter + (decalageZ * 3));
                }


                if (this.hit.point.x > Xinit + (decalageX * 6) && this.hit.point.x < Xinit + (decalageX * 7) && this.hit.point.z > Zinit && this.hit.point.z < Zinit + (decalageZ))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 6), this.hit.point.y, Zcenter);
                }
                if (this.hit.point.x > Xinit + (decalageX * 6) && this.hit.point.x < Xinit + (decalageX * 7) && this.hit.point.z > Zinit + (decalageZ) && this.hit.point.z < Zinit + (decalageZ * 2))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 6), this.hit.point.y, Zcenter + (decalageZ));
                }
                if (this.hit.point.x > Xinit + (decalageX * 6) && this.hit.point.x < Xinit + (decalageX * 7) && this.hit.point.z > Zinit + (decalageZ * 2) && this.hit.point.z < Zinit + (decalageZ * 3))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 6), this.hit.point.y, Zcenter + (decalageZ * 2));
                }
                if (this.hit.point.x > Xinit + (decalageX * 6) && this.hit.point.x < Xinit + (decalageX * 7) && this.hit.point.z > Zinit + (decalageZ * 3) && this.hit.point.z < Zinit + (decalageZ * 4))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 6), this.hit.point.y, Zcenter + (decalageZ * 3));
                }


                if (this.hit.point.x > Xinit + (decalageX * 7) && this.hit.point.x < Xinit + (decalageX * 8) && this.hit.point.z > Zinit && this.hit.point.z < Zinit + (decalageZ))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 7), this.hit.point.y, Zcenter);
                }
                if (this.hit.point.x > Xinit + (decalageX * 7) && this.hit.point.x < Xinit + (decalageX * 8) && this.hit.point.z > Zinit + (decalageZ) && this.hit.point.z < Zinit + (decalageZ * 2))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 7), this.hit.point.y, Zcenter + (decalageZ));
                }
                if (this.hit.point.x > Xinit + (decalageX * 7) && this.hit.point.x < Xinit + (decalageX * 8) && this.hit.point.z > Zinit + (decalageZ * 2) && this.hit.point.z < Zinit + (decalageZ * 3))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 7), this.hit.point.y, Zcenter + (decalageZ * 2));
                }
                if (this.hit.point.x > Xinit + (decalageX * 7) && this.hit.point.x < Xinit + (decalageX * 8) && this.hit.point.z > Zinit + (decalageZ * 3) && this.hit.point.z < Zinit + (decalageZ * 4))
                {
                    transform.position = new Vector3(Xcenter + (decalageX * 7), this.hit.point.y, Zcenter + (decalageZ * 3));
                }
            }
        }
    }

    /*
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
    */
    // Update is called once per frame
    void Update()
    {
        if (this.EnableTouch)
        {
            DragAndDrop();
        }
    }
}
