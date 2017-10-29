using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour {

	public static int score;
	public int scoreView;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreView = score;
		gameObject.GetComponent<Text> ().text = score.ToString ();
	}

}
