using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NEW SPIRIT", menuName = "SPIRIT")]
public class Spirit : ScriptableObject
{
    public new string   name;
    public float        life    = 200;
    public float        power   = 40;

    public Family       family;
    public Classe       classe;

    public GameObject   skin;

    public int          price = 3;
}
