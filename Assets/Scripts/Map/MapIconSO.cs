using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MapIcon", order = 1)]
public class MapIconSO : ScriptableObject
{
    public string mascotName;
    public Sprite icon; // presumably a circle icon
}
