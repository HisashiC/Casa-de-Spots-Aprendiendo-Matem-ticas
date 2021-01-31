using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BadgeData", menuName = "RewardsData", order = 1)]
public class BadgeScriptable : ScriptableObject
{
    public List<Badge> achievements;
}

