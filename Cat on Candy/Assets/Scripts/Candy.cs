using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour {

	public GameObject special;

	void Start() {
		int c = Random.Range (1, 5);
		if (c == 1) {
			gameObject.transform.position = new Vector2 (Random.Range (-6f, 6f), -4.25f);
		} else if (c == 2) {
			gameObject.transform.position = new Vector2 (Random.Range (-5f, -2.25f), -2f);
		} else if (c == 3) {
			gameObject.transform.position = new Vector2 (Random.Range (5f, 2.25f), -2f);
		} else if (c == 4) {
			gameObject.transform.position = new Vector2 (Random.Range (-1.25f, 1.25f), 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.layer == 8) {
			Destroy (gameObject);
			CoinCounter.score++;
			if (gameObject.GetInstanceID() == special.GetInstanceID()) {
				GameController.lives++;
				if (GameController.lives > 3)
					GameController.lives = 3;
			}
		}
	}
}
