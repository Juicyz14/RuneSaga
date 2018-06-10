using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPC : MonoBehaviour {

    private NPCManager manager;
    private Rigidbody2D body;

    BoxCollider2D groundCollider;

    int HP;

    private void Awake()
    {   
        
        body = GetComponent<Rigidbody2D>();
        groundCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        HP = 100;
    }

    private void FixedUpdate()
    {
        
    }

    public int getHP()
    {
        return HP;
    }

    public void setHP(int hp)
    {
        this.HP = hp;
    }
}
