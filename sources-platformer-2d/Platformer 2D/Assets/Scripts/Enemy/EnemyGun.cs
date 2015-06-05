using UnityEngine;
using System.Collections;

public class EnemyGun : Gun {
	
	protected bool seeTarget;
	protected Transform target;
	protected GameObject enemyParent;
	
	protected override void StartBase () {
		base.StartBase();
		enemyParent = this.transform.parent.gameObject;
	}
	
	protected override void UpdateBase () {
		base.UpdateBase ();
		
		SetDirection();
	}
	
	protected virtual void SetDirection() {
		if (seeTarget) {
			if (enemyParent.GetComponent<EnemyBomber>()) {
				if (enemyParent.GetComponent<EnemyBomber>().isFacingRight) {
					direction = 0;
				}
				else {
					direction = 180;
				}
			}
//			else if (enemyParent.GetComponent<EnemyTower>()) {
//				direction = 180;
//			}
			isRapidFire = true;
		}
		else {
			isRapidFire = false;
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			seeTarget = true;
			target = col.gameObject.transform;
		}
	}
	
	void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "Player") {
			seeTarget = false;
			target = null;
		}
	}
}
