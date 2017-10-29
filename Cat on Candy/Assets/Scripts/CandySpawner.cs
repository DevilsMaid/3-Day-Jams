using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour {

	public float timer = 5;
	public GameObject candy1;
	public GameObject candy2;
	public GameObject candy3;
	public GameObject candy4;
	public GameObject candy5;
	public GameObject candy6;
	public GameObject candy7;
	public GameObject candy8;
	public GameObject candyS;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnCandy", 1f, timer);
	}

	void SpawnCandy (){
		int z = Random.Range (1, 90);
		if (0 < z && z <= 11) {
			Instantiate (candy1, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (11 < z && z <= 22) {
			Instantiate (candy2, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (22 < z && z <= 33) {
			Instantiate (candy3, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (33 < z && z <= 44) {
			Instantiate (candy4, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (44 < z && z <= 55) {
			Instantiate (candy5, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (55 < z && z <= 66) {
			Instantiate (candy6, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (66 < z && z <= 77) {
			Instantiate (candy7, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (77 < z && z <= 88) {
			Instantiate (candy8, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (z == 89) {
			Instantiate (candyS, new Vector3 (0, 0, 0), Quaternion.identity);
		}
	}
}
