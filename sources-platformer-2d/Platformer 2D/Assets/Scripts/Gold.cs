﻿using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			Gold_Management.Instance.curGold++;
			gameObject.SetActive(false);

		}
	}
}
