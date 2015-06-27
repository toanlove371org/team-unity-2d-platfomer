using UnityEngine;
using System.Collections;

public class TrigCheckDestroyed : MonoBehaviour {

	public GameObject objAction;
	public GameObject[] objConditions;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		CheckCondition();
	}

	bool CheckDestroyAll() {
		foreach (GameObject go in objConditions) {
			if (go != null) {
				return false;
			}
		}
		return true;
	}

	private void CheckCondition() {
		if (CheckDestroyAll()) {
			Action();
		}
	}

	protected virtual void Action() {
		Destroy(objAction);
		Destroy(this.gameObject);
	}

//	void OnTriggerEnter2D(Collider2D col) {
//		if (col.tag == "Player") {Debug.Log("Check");
//			CheckCondition();
//		}
//	}

	void CheckInCollider() {
		if (this.GetComponent<BoxCollider2D>().bounds.Contains(player.transform.position)) {
			CheckCondition();
		}
	}
}
