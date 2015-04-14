using UnityEngine;
using System.Collections;

public class SpecialWeapon : MonoBehaviour {

	protected GameObject player;

	void Awake () {
		AwakeBase ();
	}

	// Do not edit
	void Start () {
		StartBase();
	}
	
	// Do not edit
	void Update () {
		UpdateBase();
	}

	protected virtual void AwakeBase () {
		player = GameObject.Find("hero");
	}

	protected virtual void StartBase() {

	}

	protected virtual void UpdateBase () {

	}
}
