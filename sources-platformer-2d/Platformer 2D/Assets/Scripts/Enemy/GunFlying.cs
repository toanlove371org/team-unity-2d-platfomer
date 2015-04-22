using UnityEngine;
using System.Collections;

public class GunFlying : EnemyGun {
	
	public float gunRange = 10f;
	private Transform player;
	
	protected override void StartBase () {
		base.StartBase();
		player = GameObject.Find("hero").transform;
		Debug.Log(AngleBetweenPoint(0, 0, -1f, -1f));
		Debug.Log(AngleBetweenPoint(0, 0, -1f, 0f));
	}
	
	protected override void SetDirection() {
		if (seeTarget) {
			direction = AngleBetweenPoint(this.transform.position.x, 
			                              this.transform.position.y, 
			                              player.position.x, 
			                              player.position.y);
			
			isRapidFire = true;
		}
		else {
			isRapidFire = false;
		}
	}

	float AngleBetweenPoint(float xA, float yA, float xB, float yB) {
		float Xa = xB - xA;
		float Ya = yB - yA;
//		return Mathf.Abs(
//			360 * ((Mathf.Abs(Ya) - Ya) / (2 * Mathf.Abs(Ya)))
//			- (int)(Mathf.Acos((Xa) / Mathf.Sqrt(Xa * Xa + Ya * Ya)) * 180 / Mathf.PI));

		return Mathf.Atan2(yB - yA, xB - xA) * Mathf.Rad2Deg;

//		return 2 * Mathf.Atan(Ya / (Mathf.Sqrt(Xa * Xa + Ya * Ya) + Xa)) * 180 / Mathf.PI;
	}
}
