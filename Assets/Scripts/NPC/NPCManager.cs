using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    List<NPC> npcList;

    private void Awake()
    {
        npcList = new List<NPC>();
    }

    private void FixedUpdate()
    {
        
    }
}
