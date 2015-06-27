using UnityEngine;
using System.Collections;

public class StartScreenCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			FadeScene.LoadLevel(Application.loadedLevel + 1, 1f, 0.5f, Color.black);
		}
	}
}
