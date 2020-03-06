using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class map_manager : MonoBehaviour
{
    private bool init_status = false;

    //create multiple list for differents Team
    private List<GameObject>[] MapListObject;



    public bool GetStatus()
    {
        return (this.init_status);
    }

    public bool init_MapManager()
    {
#if (UNITY_DEBUG_MAP_MANAGER)
        Debug.Log("init Map Manager");
#endif
        MapListObject = new List<GameObject>[GlobalVar.SizeOfTeam];

        // init tab of list
        for (int i = 0; i < GlobalVar.SizeOfTeam; i++)
        {
            MapListObject[i] = new List<GameObject>();
        }

        this.init_status = true;

        return (true);
    }

    public List<GameObject> GetList(Team get_team)
    {
#if (UNITY_DEBUG_MAP_MANAGER)
        Debug.Log("** ** Get List ** **");
        Debug.Log("Team cible: " + get_team);
#endif
        return (MapListObject[(int)get_team]);
    }


    public bool AddMapObject(GameObject person)
    {
#if (UNITY_DEBUG_MAP_MANAGER)
        Debug.Log("** ** Try to add person ** **");
#endif
        if (person == null)
        {
#if (UNITY_DEBUG_MAP_MANAGER)
            Debug.Log("Object is null");
#endif
            return (false);
        }
        else
        {
#if (UNITY_DEBUG_MAP_MANAGER)
            Debug.Log("Param not null");
#endif
            // check if we have a multiple character "in her Team List"
            if (this.MapListObject[(int)person.GetComponent<spirit_brain>().GetTeam()].IndexOf(person) > -1)
            {
#if (UNITY_DEBUG_MAP_MANAGER)
                Debug.Log("He exist !");
#endif
                return (false);
            }
            else
            {
#if (UNITY_DEBUG_MAP_MANAGER)
                Debug.Log("Succes add");
                Debug.Log("name : " + person.GetComponent<spirit_brain>().GetName());
                Debug.Log("Team " + (int)person.GetComponent<spirit_brain>().GetTeam());
#endif
                this.MapListObject[(int)person.GetComponent<spirit_brain>().GetTeam()].Add(person);
            }
        }        
        return (true);
    }
}
