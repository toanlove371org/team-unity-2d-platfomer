using UnityEngine;
using System.Collections;

public class TrigMoveHero : MonoBehaviour {

	public Transform targetPosition;

	GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			player = col.gameObject;
			MoveToTarget();
		}
	}

	void MoveToTarget () {
		StartCoroutine(WaitToMove());
	}

	IEnumerator WaitToMove() {
		player.SetActive(false);
		yield return new WaitForSeconds(1);
		player.transform.position = targetPosition.position;
		player.SetActive(true);
	}
}
