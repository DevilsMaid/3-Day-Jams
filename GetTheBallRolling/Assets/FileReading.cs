using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class FileReading : MonoBehaviour {

	public Text bestLast;
	public GameObject ball;

	public int record;
	public int prev;

	// Use this for initialization
	void Start () {
		readFromSave ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Ball.hasStarted && ball.GetComponent<Rigidbody> ().IsSleeping ())
			writeToSave ();
	}

	void readFromSave(){
		StreamReader reader = new StreamReader ("Assets/save.txt");
		string tmp = reader.ReadToEnd ();
		reader.Close ();

		StringReader strReader = new StringReader (tmp);
		record = int.Parse(strReader.ReadLine ());
		prev = int.Parse(strReader.ReadLine ());

		tmp = "Best: " + record + "m\nLast: " + prev + "m";

		bestLast.text = tmp;
	}

	void writeToSave(){
		
		prev = Distance.dist;
		if (Distance.dist > record)
			record = Distance.dist;

		StreamWriter writer = new StreamWriter ("Assets/save.txt", false);
		writer.WriteLine (record.ToString());
		writer.WriteLine (prev.ToString());
		writer.Close ();
	}
}
