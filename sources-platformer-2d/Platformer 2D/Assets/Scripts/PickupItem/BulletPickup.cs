using UnityEngine;
using System.Collections;

public class BulletPickup : PickupItem {

	public GameObject bullet;
	public Texture bulletIcon;

	private BulletHUD bulletHUD;

	protected override void AwakeBase (){
		base.AwakeBase ();

		bulletHUD = GameObject.Find("ui_bulletHUD").GetComponent<BulletHUD>();
	}

	protected override void PickupEffect (Collider2D other) {
		GunPlayer gunPlayer = other.transform.GetComponentInChildren<GunPlayer>();
		gunPlayer.bullet = bullet;
		gunPlayer.SetGun(bullet.GetComponent<Bullet>().cooldown,
		                 bullet.GetComponent<Bullet>().speed,
		                 bullet.GetComponent<Bullet>().damage);

		bulletHUD.SetIcon(bulletIcon);
	}

}
