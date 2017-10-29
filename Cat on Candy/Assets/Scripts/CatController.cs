using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	public float maxSpeedX = 1f;
	public float maxSpeedY = 1f;
	private float trueMaxSpeedX = 1f;
	public float force = 10f;
	public float jumpForce = 10f;

	public float velocityX = 0f;
	public float velocityY = 0f;

	public bool grounded = false;
	public bool right = true;
	private Rigidbody2D rb;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, 0);
		rb.AddForce (movement * force);
		if (Input.GetButtonDown ("Jump") && grounded) {
			rb.velocity = new Vector2 (rb.velocity.x, 0);
			rb.AddForce (new Vector2 (0, jumpForce));
		}


		if (Input.GetKey (KeyCode.LeftShift)) {
			trueMaxSpeedX = maxSpeedX * 2;
		} else {
			trueMaxSpeedX = maxSpeedX;
		}


		if (rb.velocity.x >= trueMaxSpeedX) {
			rb.velocity = new Vector2 (trueMaxSpeedX, rb.velocity.y);
		}
		if (rb.velocity.x <= trueMaxSpeedX * -1) {
			rb.velocity = new Vector2 (trueMaxSpeedX * -1, rb.velocity.y);
		}
		if (rb.velocity.y >= maxSpeedY) {
			rb.velocity = new Vector2 (rb.velocity.x,maxSpeedY);
		}
		if (rb.velocity.y <= maxSpeedY * -1) {
			rb.velocity = new Vector2 (rb.velocity.x,maxSpeedY * -1);
		}

		if (rb.velocity.x > 0.001f) {
			right = true;
		}
		if (rb.velocity.x < -0.001f) {
			right = false;
		}

		if (right) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			gameObject.GetComponent<CapsuleCollider2D> ().offset = new Vector2 (0.4f, 0f);
		} else {
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			gameObject.GetComponent<CapsuleCollider2D> ().offset = new Vector2 (-0.4f, 0f);
		}

		velocityX = rb.velocity.x;
		velocityY = rb.velocity.y;

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.layer == 9) {
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.layer == 9) {
			grounded = false;
		}
	}
}
