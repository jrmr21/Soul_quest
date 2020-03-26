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
    public const int SizeOfTeam         = 2;
    public const int MaxSpiritOnBoard   = 10;
    public const int MaxSpiritMain      = 7;


    // you need 3 spirit per character (3 x all types of character)
    public const int SizeOfFusion   = 9;
    public static int SizeOfShop    = (9 * 
                            (Enum.GetValues(typeof(Classe)).Length * Enum.GetValues(typeof(Family)).Length));


    public static int SizeOfIthem = 4;//(Enum.GetValues(typeof(Classe)).Length * Enum.GetValues(typeof(Family)).Length);    // tempo value
}

