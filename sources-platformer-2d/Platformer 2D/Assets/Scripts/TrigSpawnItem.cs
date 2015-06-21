using UnityEngine;
using System.Collections;

public class TrigSpawnItem : MonoBehaviour {

	public int itemIndex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			PickupSpawner.Instance.SpawnItem(itemIndex, this.transform.position);
			Destroy(this.gameObject);
		}
	}
}
