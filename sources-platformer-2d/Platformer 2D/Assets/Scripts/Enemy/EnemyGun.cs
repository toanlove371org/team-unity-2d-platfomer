using UnityEngine;
using System.Collections;

public class EnemyGun : Gun {
	
	protected bool seeTarget;
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
			if (enemyParent.GetComponent<EnemyBomber>().isFacingRight) {
				direction = 0;
			}
			else {
				direction = 180;
			}
			isRapidFire = true;
		}
		else {
			isRapidFire = false;
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			seeTarget = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "Player") {
			seeTarget = false;
		}
	}
}
