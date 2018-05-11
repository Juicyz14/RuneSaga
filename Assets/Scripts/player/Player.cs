using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   private Rigidbody2D body;
   private SkillManager skillManager;


   private void Awake() {
      body = GetComponent<Rigidbody2D>();
      skillManager = GetComponent<SkillManager>();
   }

   // Use this for initialization
   private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

   private void FixedUpdate() {
      float h = Input.GetAxisRaw("Horizontal");
      float v = Input.GetAxisRaw("Vertical");

      Move(h, v);
   }

   public SkillManager GetSkillManager() {
      return skillManager;
   }

   private void Move(float h, float v) {
      const float speed = 3f;
      Vector3 movement = new Vector3(h, v, 0f);

      movement = movement.normalized * speed * Time.deltaTime;
      body.MovePosition(transform.position + movement);
   }
}
