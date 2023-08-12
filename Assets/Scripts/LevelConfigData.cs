using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/level", fileName ="level_")]
public class LevelConfigData : ScriptableObject
{
    public int gold = 0;
    public float exp = 0;
    public GameObject _beePrefab;
}
