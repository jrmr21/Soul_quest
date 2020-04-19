using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Drop : MonoBehaviour
{

    public bool touchAct = false;
    public Collider coll;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
    }
}
