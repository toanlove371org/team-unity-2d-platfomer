using UnityEngine;
using System.Collections;

public class GunFlying : EnemyGun {

	public float gunRange = 10f;
	private Transform player;

	protected override void StartBase () {
		base.StartBase();
		player = GameObject.Find("hero").transform;
	}

	protected override void SetDirection() {
		if (seeTarget) {
			direction = AngleBetweenPoint(this.transform.position, player.position);

			isRapidFire = true;
		}
		else {
			isRapidFire = false;
		}
	}

	float AngleBetweenPoint(Vector2 a, Vector2 b) {
		return Mathf.Atan2 (b.y - a.y, b.x - a.x);
	}
}
