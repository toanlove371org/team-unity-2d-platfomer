using UnityEngine;
using System.Collections;

public class RocketWeapon : SpecialWeapon {

	public float speed = 15f;
	public GameObject explosion;			// Prefab of explosion effect.

	private float direction;

	protected override void AwakeBase (){
		base.AwakeBase ();
	}

	protected override void StartBase () {
		base.StartBase ();

		if (player.GetComponent<PlayerControl>().facingRight) {
			direction = 0;
		} else {
			direction = 180;
		}

		Move ();
	}

	void Move() {
		this.GetComponent<Rigidbody2D>().velocity =
			new Vector2(Mathf.Cos (Mathf.Deg2Rad * direction) * speed,
			            Mathf.Sin (Mathf.Deg2Rad * direction) * speed);
		this.transform.Rotate(Vector3.forward, direction + 180);
	}

	void OnTriggerEnter2D (Collider2D col) {
		switch(col.tag) {
		case "Enemy":
			col.gameObject.GetComponent<EnemyBaseClass>().Hurt(1);
			Explode();
			break;
		case "BombPickup":
			col.gameObject.GetComponent<Bomb>().Explode();
			
			// Destroy the bomb crate.
			Destroy (col.transform.root.gameObject);
			break;
		case "Obstacle":
		case "ground":
			Explode();
			break;
		default:
			break;
		}
	}

	void Explode() {
		Destroy(this.gameObject);
		// Instantiate the explosion prefab.
		Instantiate(explosion,transform.position, Quaternion.identity);
	}
}
