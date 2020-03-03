using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    private Transform target;
    Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        Input.simulateMouseWithTouches = false;         // block 2 fingers bug
        //this.target.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                

                    newPosition.x = Input.mousePosition.x;
                    newPosition.y = Input.mousePosition.y;
                    //print("x/ " + newPosition.x + "  Y/" + newPosition.y);

                    print("case Y= " + (int)(newPosition.y - 67) / 48 +"| case X= " + (int)(newPosition.x - 225) / 90);


                newPosition.x = transform.position.x - 10;
                newPosition.y = transform.position.y;

                transform.position = newPosition;
                //transform.position = Vector2.MoveTowards(transform.position, newPosition, 5 * Time.deltaTime);
                
            }
        }
    }
}
