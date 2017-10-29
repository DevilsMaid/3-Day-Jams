using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public float torque;
	public GameObject bat;
	public GameObject ball;

	Vector3 previousPos;

	// Use this for initialization
	void Start () {
		previousPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton (0)) {
			float turn = Camera.main.ScreenToViewportPoint(Input.mousePosition).x - previousPos.x;
			bat.GetComponent<Rigidbody> ().AddTorque (transform.up * torque * turn);
		}
		previousPos = Camera.main.ScreenToViewportPoint (Input.mousePosition);

		if ((Ball.hasStarted && ball.GetComponent<Rigidbody> ().IsSleeping ()) && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene ("Level");
		}

		if(Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene ("Level");
		}
			
	}
}
