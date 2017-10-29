using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

	public GameObject explosion;
	public GameObject indicator;
	private float spawnTime;

	private Vector2 startPos;
	private Vector2 endPos;
	private GameObject indicatorCurr;

	// Use this for initialization
	void Start () {
		spawnTime = Time.time;
		startPos = new Vector2 (Random.Range (-6f, 6f), 6f);
		int c = Random.Range (1, 5);
		if (c == 1) {
			endPos = new Vector2 (Random.Range (-6f, 6f), -4.25f);
		} else if (c == 2) {
			endPos = new Vector2 (Random.Range (-5f, -2.25f), -2f);
		} else if (c == 3) {
			endPos = new Vector2 (Random.Range (5f, 2.25f), -2f);
		} else if (c == 4) {
			endPos = new Vector2 (Random.Range (-1.25f, 1.25f), 0f);
		}
		indicatorCurr = Instantiate (indicator, endPos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnTime + 2f <= Time.time) {
			Instantiate (explosion, endPos, Quaternion.identity);
			Destroy (gameObject);
			Destroy (indicatorCurr);
		}
		float fracJourney = (Time.time - spawnTime) / 2;
		transform.position = Vector2.Lerp (startPos, endPos, fracJourney);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.layer == 8) {
			Destroy (gameObject);
			Destroy (indicatorCurr);
			GameController.lives--;
		}
	}
}
