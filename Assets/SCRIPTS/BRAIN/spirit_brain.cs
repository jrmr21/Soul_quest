using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spirit_brain : MonoBehaviour
{
    private GameObject          Master;
    private Spirit     scriptableObject;
    
    private ProgressBarCircle   Pb;
    private string              name;
    private float               life;
    private Team                team;
    private GameObject          skin;


    public bool InitPrefab(GameObject Master, Spirit data)
    {
            // get tools
        this.Master             = Master;
        this.scriptableObject   = data;

            // change name
        this.transform.name     = this.scriptableObject.name;

            // set data
        this.name               = this.scriptableObject.name;
        this.life               = this.scriptableObject.life;
        this.team               = this.scriptableObject.team;

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
}
