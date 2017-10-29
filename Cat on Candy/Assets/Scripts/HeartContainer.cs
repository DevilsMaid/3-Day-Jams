using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.lives == 3) {
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
			gameObject.transform.GetChild (1).gameObject.SetActive (true);
			gameObject.transform.GetChild (2).gameObject.SetActive (true);
		} else if (GameController.lives == 2) {
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
			gameObject.transform.GetChild (1).gameObject.SetActive (true);
			gameObject.transform.GetChild (2).gameObject.SetActive (false);
		} else if (GameController.lives == 1) {
			gameObject.transform.GetChild (0).gameObject.SetActive (true);
			gameObject.transform.GetChild (1).gameObject.SetActive (false);
			gameObject.transform.GetChild (2).gameObject.SetActive (false);
		} else if (GameController.lives <= 0) {
			gameObject.transform.GetChild (0).gameObject.SetActive (false);
			gameObject.transform.GetChild (1).gameObject.SetActive (false);
			gameObject.transform.GetChild (2).gameObject.SetActive (false);
		}
	}
}
