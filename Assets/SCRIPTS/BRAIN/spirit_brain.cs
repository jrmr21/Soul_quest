using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spirit_brain : MonoBehaviour
{
    private GameObject Master;
    private Spirit scriptableObject;

    private ProgressBarCircle   Pb;
    private string              m_name;
    private float               life;
    private Team                team;
    private GameObject          skin;
    private Vector3             origin_position;

    private bool EnableTouch    = false;
    private bool touchAct       = false;
    private Collider coll;
    private RaycastHit hit;
    private Ray ray;


    public bool InitPrefab(GameObject Master, ref Spirit data)
    {
        // get tools
        this.Master             = Master;
        this.scriptableObject   = data;

        // change name
        this.transform.name     = this.scriptableObject.name;

        // set data
        this.m_name     = this.scriptableObject.name;
        this.life       = this.scriptableObject.life;
        this.team       = this.scriptableObject.team;

        coll = this.GetComponentInChildren<Collider>();

        // create skin
        this.skin = Instantiate(this.scriptableObject.skin);
        this.skin.transform.parent = this.gameObject.transform;

        // move skin at 0, 0, 0
        this.SetPosition(this.transform.position);
        this.origin_position         = this.transform.position;


        //Debug.Log("pos " + this.skin.transform.position);

<<<<<<< HEAD

=======
#if (UNITY_FINGER_MODE || UNITY_MOUSE_MODE)
>>>>>>> 7336172901d9ced1d32c7674bd0323cff9467f38
        return (true);
#else
        return (false);
#endif
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
        Debug.Log("move "+ this.GetName() + " Spirit at " + vector);
#endif
        this.gameObject.transform.position  = vector;
    }

    public void SetDragAndDrop(bool status)
    {
#if (UNITY_DEBUG_BRAIN_DETAILS)
        Debug.Log("touch enable for" + this.GetName() + " is " + status);
#endif
        this.EnableTouch = status;
    }

<<<<<<< HEAD
    //     mouse version
=======

    //     mouse version example by Julien the BEST
    /*
>>>>>>> 7336172901d9ced1d32c7674bd0323cff9467f38
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
<<<<<<< HEAD
            Debug.Log(hit.transform.tag);
=======
            //Debug.Log(hit.transform.tag);
>>>>>>> 7336172901d9ced1d32c7674bd0323cff9467f38
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
<<<<<<< HEAD
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
=======
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
>>>>>>> 7336172901d9ced1d32c7674bd0323cff9467f38
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
<<<<<<< HEAD

    /*
=======
    */


    // use mouse
#if (UNITY_MOUSE_MODE)
    private void DragAndDrop()
    {
        this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << 9;
        layerMask = ~layerMask;


        if (Input.GetMouseButtonDown(0))
        {
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                this.origin_position = this.transform.position;
                touchAct = true;
            }
            //Debug.Log("i'm" + this.GetName());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchAct = false;
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                try
                {
                    if (string.Compare(this.hit.transform.gameObject.transform.parent.parent.name,"fight_main") == 0)
                    {
#if (UNITY_DEBUG_BRAIN_DETAILS)
                        Debug.Log("succes position !");
#endif
                        this.SetPosition(this.hit.transform.gameObject.transform.position);
                    }
                    else
                    {
#if (UNITY_DEBUG_BRAIN_DETAILS)
                        Debug.Log("bad position !");
#endif
                        this.SetPosition(this.origin_position);
                    }
                }
                catch
                {
#if (UNITY_DEBUG_BRAIN_DETAILS)
                    Debug.Log("wtf position !");
#endif
                    this.SetPosition(this.origin_position);
                }
                    // automatic disable touch
                this.SetDragAndDrop(false);
            }
        }

        if (touchAct == true)
        {
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                this.SetPosition(new Vector3(this.hit.point.x, this.hit.point.y + 2f, this.hit.point.z));
            }
        }
    }
#endif

    // use finger
#if (UNITY_FINGER_MODE)
>>>>>>> 7336172901d9ced1d32c7674bd0323cff9467f38
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
                        this.origin_position = this.transform.position;
                        touchAct = true;
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                {
                    touchAct = false;

                    if (Physics.Raycast(ray, out hit, 100, layerMask))
                    {
                        try
                        {
                            if (string.Compare(this.hit.transform.gameObject.transform.parent.parent.name,"fight_main") == 0)
                            {
#if (UNITY_DEBUG_BRAIN_DETAILS)
                                Debug.Log("succes position ! " + this.hit.transform.gameObject.transform.name);
#endif
                                this.SetPosition(this.hit.transform.gameObject.transform.position);
                            }
                            else
                            {
#if (UNITY_DEBUG_BRAIN_DETAILS)
                                Debug.Log("bad position !");
#endif
                                this.SetPosition(this.origin_position);
                            }
                        }
                        catch
                        {
#if (UNITY_DEBUG_BRAIN_DETAILS)
                            Debug.Log("wtf position !");
#endif
                            this.SetPosition(this.origin_position);
                        }
                            // automatic disable touch
                        this.SetDragAndDrop(false);
                    }
                }
            }

            if (touchAct == true)
            {
                if (Physics.Raycast(ray, out hit, 100, layerMask))
                {
                    this.transform.position = new Vector3(this.hit.point.x, this.hit.point.y + 2f, this.hit.point.z);
                }
            }
        }
    }
<<<<<<< HEAD
    */
=======
#endif

>>>>>>> 7336172901d9ced1d32c7674bd0323cff9467f38
    // Update is called once per frame
    void Update()
    {
        if (this.EnableTouch)
        {
#if (UNITY_FINGER_MODE || UNITY_MOUSE_MODE)
            DragAndDrop();
            Debug.Log("I'm touch enable " + this.GetName());
#endif
        }
    }
}
