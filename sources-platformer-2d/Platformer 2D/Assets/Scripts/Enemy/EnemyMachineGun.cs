using UnityEngine;
using System.Collections;

public class EnemyMachineGun : EnemyBomber {

//	protected EnemyGun gun;
//	protected bool seeTarget;
//
//	protected override void AwakeBase (){
//		base.AwakeBase ();
//
//		gun = this.transform.FindChild("gun").GetComponent<EnemyGun>();
//	}
//
//	protected override void FixedUpdateBase () {
//		base.FixedUpdateBase();
//
//		SetGunDirection();
//
//	}
//
//	protected virtual void SetGunDirection () {
//		if (seeTarget) {
//			gun.SetRapidFire(true);
//			if (this.isFacingRight) {
//				gun.direction = 0;
//			} else {
//				gun.direction = 180;
//			}
//		} else {
//			gun.SetRapidFire(false);
//		}
//	}
//
//	void OnTriggerEnter2D (Collider2D col) {
//		if (col.tag == "Player") {
//			seeTarget = true;
//		}
//	}
//
//	void OnTriggerExit2D(Collider2D col) {
//		if (col.tag == "Player") {
//			seeTarget = false;
//		}
//	}
}
