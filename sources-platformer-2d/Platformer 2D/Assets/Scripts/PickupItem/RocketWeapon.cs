using UnityEngine;
using System.Collections;

public class RocketWeapon : SpecialWeapon {

	public float rocketSpeed = 20f;
	public float rocketRadius = 10f;
	public float rocketForce = 100f;
	public float rocketDamage = 2f;
	public float lifeTime = 1.5f;
	public GameObject bomb;			// Prefab of bomb

	private float direction;

	protected override void AwakeBase (){
		base.AwakeBase ();
	}

	protected override void StartBase () {
		base.StartBase ();

		Destroy(this.gameObject, lifeTime); // destroy this rocket if it is not destroyed by others

		if (player.GetComponent<PlayerControl>().facingRight) {
			direction = 0;
		} else {
			direction = 180;
		}

		Move ();
	}

	void Move() {
		this.GetComponent<Rigidbody2D>().velocity =
			new Vector2(Mathf.Cos (Mathf.Deg2Rad * direction) * rocketSpeed,
			            Mathf.Sin (Mathf.Deg2Rad * direction) * rocketSpeed);
		this.transform.Rotate(Vector3.forward, direction + 180);
	}

	void OnTriggerEnter2D (Collider2D col) {
		switch(col.tag) {
		case "Enemy":
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
		GameObject bombTemp = (GameObject)Instantiate(bomb,transform.position, Quaternion.identity);
		bombTemp.GetComponent<Bomb>().SetBomb(rocketRadius, rocketForce, rocketDamage);
		bombTemp.GetComponent<Bomb>().Explode();
	}
}
