using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("LoadGame", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void LoadGame(){
		SceneManager.LoadScene ("Level1");
	}
}
