using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/VictimInfo", order = 1)]
public class VictimInfo : ScriptableObject
{
    public Sprite victimSprite;
    public string victimDesc;
}
