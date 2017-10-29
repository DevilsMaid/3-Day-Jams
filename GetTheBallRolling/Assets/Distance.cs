using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour {

	public GameObject ball;
	public Text txt;

	static public int dist;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Score: " + ((int)(ball.transform.position.x * -1)).ToString() + "m";
		dist = (int)(ball.transform.position.x * -1);
	}
}
