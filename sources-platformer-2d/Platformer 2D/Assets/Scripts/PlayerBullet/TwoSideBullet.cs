using UnityEngine;
using System.Collections;

public class TwoSideBullet : PlayerBullet {

	public override void InitEffect() {
		GameObject bulletInstance
			= (GameObject)Instantiate(
				this.gameObject, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
		bulletInstance.GetComponent<TwoSideBullet>().SetMove(direction + 180f, speed, damage);
	}
}
