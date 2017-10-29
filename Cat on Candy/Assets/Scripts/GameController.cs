using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static int lives;
	public int livesView;

	public GameObject star;

	// Use this for initialization
	void Start () {
		lives = 3;
		InvokeRepeating ("SpawnStar", 2f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		livesView = lives;
		if (lives < 0) {
			SceneManager.LoadScene ("GameOver");
		}
	}


	void SpawnStar (){
		Instantiate (star, new Vector3 (0, 10, 0), Quaternion.identity);
	}

}
