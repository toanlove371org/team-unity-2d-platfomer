using UnityEngine;
using System.Collections;

public class EnemyGun : Gun {

	protected override void StartBase () {
		base.StartBase();
		SetAutoFire(true);
	}

	public void SetAutoFire (bool fire) {
		isRapidFire = fire;
	}
}
