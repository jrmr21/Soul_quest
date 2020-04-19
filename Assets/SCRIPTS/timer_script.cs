using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_script : MonoBehaviour
{
    private Text text_cpt;

    // Start is called before the first frame update
    void Start()
    {
        this.text_cpt = GetComponentInChildren<Text>();
        this.text_cpt.text = " ";
    }

        // set new text to display
    public void edit_text(string i_text)
    {
        this.text_cpt.text = i_text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
