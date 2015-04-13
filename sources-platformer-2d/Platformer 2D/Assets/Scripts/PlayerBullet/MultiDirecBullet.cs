using UnityEngine;
using System.Collections;

public class MultiDirecBullet : PlayerBullet {

	public override void InitEffect() {

		GameObject bulletInstance
						= (GameObject)Instantiate(
							this.gameObject, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
					bulletInstance.GetComponent<MultiDirecBullet>().SetMove(direction + 35f, speed, damage);
					
		GameObject bulletInstance_2
						= (GameObject)Instantiate(
							this.gameObject, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
					bulletInstance_2.GetComponent<MultiDirecBullet>().SetMove(direction - 35f, speed, damage);
	}
}
