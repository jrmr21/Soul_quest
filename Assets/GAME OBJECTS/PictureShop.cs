using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NEW PictureShop", menuName = "PictureShop")]
public class PictureShop : ScriptableObject
{
    public string[] ListName;

    public Sprite[]  ListPicture;
}