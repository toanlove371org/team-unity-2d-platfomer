using UnityEngine;
using System.Collections;

public class EnemyBullet : Bullet {
	protected override void OnTriggerEnter2DBase (Collider2D col) {
		base.OnTriggerEnter2DBase (col);

		switch(col.tag) {
		case "Player":
			col.gameObject.GetComponent<PlayerHealth>().GetDamage(damage);
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
