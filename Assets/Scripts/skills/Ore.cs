using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Skills/MiningSkill/Ore")]
public class Ore : ScriptableObject {
   // The damage the player must do before he can extract the ore.
   public int hp;

   // How long does the ore take to respawn in seconds.
   public int respawnRate;

   // How much xp is given when the ore is mined.
   public int xp;

   // Level required to mine the ore.
   public int level;
}
