using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pv : MonoBehaviour
{
    public ProgressBarCircle Life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame.
    void Update()
    {
        Life.BarValue = 100;
    }
}
