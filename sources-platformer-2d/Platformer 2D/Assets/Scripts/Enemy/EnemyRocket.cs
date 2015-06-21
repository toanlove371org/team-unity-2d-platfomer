using UnityEngine;
using System.Collections;

public class EnemyRocket : Bullet {
	public float bombForce = 100f;
	
	Rigidbody2D rb;
	Vector2 deltaPos;

	protected override void OnTriggerEnter2DBase (Collider2D col) {
		base.OnTriggerEnter2DBase (col);
		
		switch(col.tag) {
		case "Player":
			col.gameObject.GetComponent<PlayerHealth>().GetDamage(damage);
			rb = col.gameObject.GetComponent<Rigidbody2D>();
			deltaPos = rb.transform.position - this.transform.position;
			rb.AddForce(deltaPos.normalized * bombForce * 10f);

			Explode();
			break;
		case "Obstacle":
		case "ground":
			Explode();
			break;
		default:
			break;
		}
	}
}
