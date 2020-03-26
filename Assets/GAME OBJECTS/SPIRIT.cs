using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NEW SPIRIT", menuName = "SPIRIT")]
public class Spirit : ScriptableObject
{
    public new string   name;
    public float        life;

    public Family       family;
    public Classe       classe;
    public Team         team;

    public GameObject   skin;

}
