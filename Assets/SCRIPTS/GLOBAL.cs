using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Family
{
    fire, water, wind, ground
}


public enum Classe
{
    archer, warrior, magician
}

public enum Team
{
    TeamA, TeamB
}

public class GlobalVar
{
    public const int SizeOfTeam     = 2;
    public const int MaxSpiritOnMap = 10;

    // you need 3 spirit per character (3 x all types of character)
    public int SizeOfShop           = (3 * 
                            (Enum.GetValues(typeof(Classe)).Length * Enum.GetValues(typeof(Family)).Length));


}

