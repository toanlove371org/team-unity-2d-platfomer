using UnityEngine;
using System.Collections;

public class BulletPickup : PickupItem {

	public GameObject bullet;
	public Texture bulletIcon;
	public float bulletTime = 45;

	protected override void AwakeBase (){
		base.AwakeBase ();
	}

	protected override void PickupEffect (Collider2D other) {
		GunPlayer gunPlayer = other.transform.GetComponentInChildren<GunPlayer>();
		gunPlayer.bullet = bullet;
		gunPlayer.SetGun(bullet.GetComponent<Bullet>().cooldown,
		                 bullet.GetComponent<Bullet>().speed,
		                 bullet.GetComponent<Bullet>().damage);


		gunPlayer.CalBulletTime(bulletTime);
		BulletHUD.Instance.SetIcon(bulletIcon);
	}

}
