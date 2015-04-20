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
			direction = Vector2.Angle(this.transform.position, player.position);
			
			isRapidFire = true;
		}
		else {
			isRapidFire = false;
		}
	}
}
