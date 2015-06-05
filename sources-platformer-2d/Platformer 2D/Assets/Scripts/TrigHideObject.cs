using UnityEngine;
using System.Collections;

public class TrigHideObject : MonoBehaviour {

	//private GameObject[] childObjects;

	// Use this for initialization
	void Start () {
		SetActiveAll(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetActiveAll(bool value) {
		foreach (Transform child in this.transform) {
			child.gameObject.SetActive(value);
		}
	}
}
