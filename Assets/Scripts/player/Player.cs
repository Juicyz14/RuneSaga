using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   private Rigidbody2D body;
   private SkillManager skillManager;
   BoxCollider2D groundCollider;

   private Collider2D col;


   private void Awake() {
      body = GetComponent<Rigidbody2D>();
      skillManager = GetComponent<SkillManager>();
      groundCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
   }

   // Use this for initialization
   private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

   private void FixedUpdate() {
      float h = Input.GetAxisRaw("Horizontal");
      bool toJump = Input.GetKeyDown(KeyCode.Space);

      Move(h, toJump);
   }

   void OnCollisionStay2D(Collision2D other) {
      if (other.gameObject.tag == "Platform" && Input.GetKeyDown(KeyCode.S)) {
         col = other.collider;
         DisableColliderOnPlatform();
         Invoke("DisableColliderOnPlatform", 0.5f);
      }
   }

   public void DisableColliderOnPlatform() {
      col.enabled = !col.enabled;
   }

   public SkillManager GetSkillManager() {
      return skillManager;
   }

   private void Move(float h, bool toJump) {
      const float speed = 3f;
      const float jumpForce = 400f;

      body.velocity = new Vector2(h * speed, body.velocity.y);

      if (toJump) {
         ContactFilter2D filter = new ContactFilter2D();
         filter.SetLayerMask(LayerMask.GetMask("Ground"));
         filter.useTriggers = true;

         if (groundCollider.IsTouching(filter)) {
            body.AddForce(new Vector2(0f, jumpForce));
         }
      }
   }
}
