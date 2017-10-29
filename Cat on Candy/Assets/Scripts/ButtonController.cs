using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	public Sprite normal;
	public Sprite highlight;
	public bool start;
	public bool about;
	public bool exit;
	public bool main;

	void OnMouseEnter(){
		print ("in");
		gameObject.GetComponent<Image> ().sprite = highlight;
	}

	void OnMouseExit(){
		print ("out");
		gameObject.GetComponent<Image> ().sprite = normal;
	}

	void OnMouseUp(){
		print ("click");
		if (start) {
			SceneManager.LoadScene ("Level1");
		} else if (about) {
			
		} else if (exit) {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
		} else if (main) {
			SceneManager.LoadScene ("MainMenu");
		}
	}
}
