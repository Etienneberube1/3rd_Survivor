using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
[Serializable]

public class PlayerStats : ScriptableObject
{
    public float kill = 0;
    public float level = 10;
}
