using UnityEngine;
using UnityEngine.UI;

public class MiningTextUI : MonoBehaviour {
   private Player player;
   private Text text;

	// Use this for initialization
	void Start () {
      EventManager.StartListening(EventTags.UpdateSkillUiEvent, UpdateUI);
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   private void UpdateUI() {
      SkillManager skillMgr = player.GetSkillManager();
      text.text = skillMgr.GetSkillLevel(SkillType.Mining) + " " + skillMgr.GetSkillXp(SkillType.Mining) + "/" + skillMgr.GetSkillXpNeeded(SkillType.Mining);
   }
}
