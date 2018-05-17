using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Skills/MiningSkill/Ore")]
public class Ore : ScriptableObject {
   public int itemId = -1;

   // The damage the player must do before he can extract the ore.
   public int hp = 1;

   // How long does the ore take to respawn in seconds.
   public int respawnRate = 0;

   // How much xp is given when the ore is mined.
   public int xp = 0;

   // Level required to mine the ore.
   public int level = 1;
}
