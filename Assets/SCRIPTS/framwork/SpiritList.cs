using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritList : MonoBehaviour
{
        // we can have 5 list maximum !
    protected List<GameObject>[] ListObject = new List<GameObject>[5];

    protected void InitList(int size = 1)
    {
        for (int i = 0; i < size; i++)
        {
            this.ListObject[i] = new List<GameObject>();
        }
    }

    protected bool AddListObject(ref GameObject character, int list = 0)
    {
        if (character == null)
        {
            return (false);
        }
        else
        {
            this.ListObject[list].Add(character);
        }
        return (true);
    }

    protected GameObject PopRandomListObject(int list = 0)
    {
        GameObject tempo;

            // get random index
        int index = Random.Range(0, (this.GetListSize() - 1));

        if (index < 0)
        {
            return (null);
        }
        else
        {
            // copy object like
            tempo = this.ListObject[list][index];

            // remove this object to list
            this.ListObject[list].RemoveAt(index);
        }

            // return get object
        return (tempo);
    }

    protected GameObject PopListObject(int index, int list = 0)
    {
        GameObject tempo;

        if ((index > this.GetListSize()) || (index < 0))
            return (null);

            // copy object like
        tempo = this.ListObject[list][index];

        // remove this object to list
        this.ListObject[list].RemoveAt(index);

            // return get object
        return (tempo);
    }

    protected void RemoveListObject(int index, int list = 0)
    {
        this.ListObject[list].RemoveAt(index);
    }

    protected GameObject PeekListObject(int index, int list = 0)
    {
        if ((index > this.GetListSize()) || (index < 0))
            return (null);
 
        // return get object
        return (this.ListObject[list][index]);
    }

    protected int GetListSize(int list = 0)
    {
        return (this.ListObject[list].Count);
    }
}
