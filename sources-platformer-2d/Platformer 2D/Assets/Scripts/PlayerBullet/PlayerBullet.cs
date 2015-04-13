using UnityEngine;
using System.Collections;

public class PlayerBullet : Bullet {

	public override void InitEffect() {
		// Don't have any effect
	}
	
	protected override void OnTriggerEnter2DBase (Collider2D col) 
	{
		base.OnTriggerEnter2DBase (col);
		
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
}
