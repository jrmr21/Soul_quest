using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritList : MonoBehaviour
{
    protected List<GameObject>  ListObject;

    protected void InitList()
    {
        this.ListObject = new List<GameObject>();
    }

    protected bool AddListObject(ref GameObject character)
    {
        this.ListObject.Add(character);
        return (true);
    }

    protected GameObject PopRandomListObject()
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
            tempo = this.ListObject[index];

            // remove this object to list
            this.ListObject.RemoveAt(index);
        }

            // return get object
        return (tempo);
    }

    protected GameObject PopListObject(int index)
    {
        GameObject tempo;

        if ((index > this.GetListSize()) || (index < 0))
            return (null);

            // copy object like
        tempo = this.ListObject[index];

            // remove this object to list
        this.ListObject.RemoveAt(index);

            // return get object
        return (tempo);
    }

    protected GameObject PeekListObject(int index)
    {
        if ((index > this.GetListSize()) || (index < 0))
            return (null);
 
        // return get object
        return (this.ListObject[index]);
    }

    protected int GetListSize()
    {
        return (this.ListObject.Count);
    }
}
