using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	
	static public bool hasStarted;


	// Use this for initialization
	void Start () {
		hasStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x != 0)
			hasStarted = true;
	}
}
