using UnityEngine;
using System.Collections;

public class Trig : MonoBehaviour {

	public GameObject objAction;
	public GameObject[] objConditions;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool CheckDestroyAll() {
		foreach (GameObject go in objConditions) {
			if (go != null) {
				return false;
			}
		}
		return true;
	}

	public void CheckCondition() {
		if (CheckDestroyAll()) {

		}
	}
}
