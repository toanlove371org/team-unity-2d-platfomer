using UnityEngine;
using System.Collections;

public class Rocket : Bullet 
{
	void Start () 
	{
		// Destroy the rocket after 1 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 1);

	}

	public override void InitEffect() {
		// create 2 others bullet
		GameObject bulletInstance
			= (GameObject)Instantiate(
				this.gameObject, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
		bulletInstance.GetComponent<Rocket>().SetMove(direction + 25f, speed, damage);

		GameObject bulletInstance_2
			= (GameObject)Instantiate(
				this.gameObject, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
		bulletInstance_2.GetComponent<Rocket>().SetMove(direction - 25f, speed, damage);

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
