using UnityEngine;
using System.Collections;

public class MovingLand : MonoBehaviour {

	public float direction = 0;
	public float speed = 1f;
	public float freezTime = 1f;

	private float speedTemp;
	private bool isTriggered;

	// Use this for initialization
	void Start () {
		speedTemp = speed;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move() {
		this.GetComponent<Rigidbody2D>().velocity =
			new Vector2(Mathf.Cos (Mathf.Deg2Rad * direction) * speedTemp,
			            Mathf.Sin (Mathf.Deg2Rad * direction) * speedTemp);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "ChangeDirection") {
			speedTemp = 0;
			StartCoroutine(Freez(freezTime));
			if (col.GetComponent<ChangeDirection>()) {
				direction = col.GetComponent<ChangeDirection>().direction;
			} else {
				if(!isTriggered) {
					direction = direction + 180;
					isTriggered = true;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.tag=="ChangeDirection") {
			isTriggered = false;
		}
	}

	IEnumerator Freez(float time) {
		yield return new WaitForSeconds(time);
		speedTemp = speed;

	}
}
