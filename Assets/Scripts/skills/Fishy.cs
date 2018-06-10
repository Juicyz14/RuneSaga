using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/FishingSkill/Fish")]
public class Fishy : ScriptableObject {

    public int itemId = -1;

    public int xp = 0;
    public int level = 1;

    public int catchProbability;
}
