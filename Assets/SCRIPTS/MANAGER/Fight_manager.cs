using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_manager : SpiritList
{
    
    public bool init_FightManager()
    {
#if (UNITY_DEBUG_FIGHT_MANAGER)
        Debug.Log("init fight Manager");
#endif
        // create list of gameObject
        this.InitList(2);

        return (true);
    }

    public int addToFightTab(GameObject character, string team)
    {
        if (string.Compare(team, GlobalVar.player_front) == 0)
        {
            this.AddListObject(ref character);

            Debug.Log("add 0");

            return (this.GetListSize() - 1);
        }
        else if (string.Compare(team, GlobalVar.player_back) == 0)
        {
            this.AddListObject(ref character, 1);

            Debug.Log("add 1 ");

            return (this.GetListSize(1) - 1);
        }

        return (-1);
    }

    public void removeToFightTab(int index, string team)
    {
        Debug.Log("rm player ");

        if (string.Compare(team, GlobalVar.player_front) == 0)
        {
                // update all value index before remove character
            for (int i = index; i < (this.GetListSize() - 1); i++)
            {
                int NewIndex = this.PeekListObject(index).GetComponent<spirit_brain>().GetIndexFight();

                this.PeekListObject(index).GetComponent<spirit_brain>().SetIndexFight(NewIndex - 1);
            }

            this.RemoveListObject(index);
        }
        else if (string.Compare(team, GlobalVar.player_back) == 0)
        {
            // update all value index before remove character
            for (int i = index; i < (this.GetListSize(1) - 1); i++)
            {
                int NewIndex = this.PeekListObject(index, 1).GetComponent<spirit_brain>().GetIndexFight();

                this.PeekListObject(index, 1).GetComponent<spirit_brain>().SetIndexFight(NewIndex - 1);
            }

                // remove character
            this.PeekListObject(index).GetComponent<spirit_brain>().SetIndexFight(-1);
            this.RemoveListObject(index, 1);
        }
    }

    public void StartFightMode()
    {
        for (int i = 0; i < this.GetListSize() ; i++)
        {
            this.PeekListObject(i).GetComponent<spirit_brain>().SetFight(true);

                // select random cible in ennemy tab
            int tmpCible = Random.Range(0, (this.GetListSize(1) - 1));

            this.PeekListObject(i).GetComponent<spirit_brain>().
                SetTarget(this.PeekListObject(tmpCible, 1).GetComponent<spirit_brain>().transform);
        }

        for (int i = 0; i < this.GetListSize(1); i++)
        {
            this.PeekListObject(i, 1).GetComponent<spirit_brain>().SetFight(true);

            // select random cible in ennemy tab
            int tmpCible = Random.Range(0, (this.GetListSize() - 1));

            this.PeekListObject(i, 1).GetComponent<spirit_brain>().
                SetTarget(this.PeekListObject(tmpCible).GetComponent<spirit_brain>().transform);
        }
    }

    public void EndFightMode()
    {
        for (int i = 0; i < this.GetListSize(); i++)
        {
            this.PeekListObject(i).GetComponent<spirit_brain>().SetTarget(null);
            this.PeekListObject(i).GetComponent<spirit_brain>().SetFight(false);
        }

        for (int i = 0; i < this.GetListSize(1); i++)
        {
            this.PeekListObject(i, 1).GetComponent<spirit_brain>().SetTarget(null);
            this.PeekListObject(i, 1).GetComponent<spirit_brain>().SetFight(false);
        }
    }
}
