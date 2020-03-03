using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child : MonoBehaviour
{
    private Collider body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!body.isTrigger)
        {
            Debug.Log("-- yo l asticot");
        }
    }
}
