using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.33f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.layer == 8) {
			Destroy (gameObject);
			GameController.lives--;
		}
	}
}
