using UnityEngine;
using System.Collections;

public class GunPlayer : Gun {

	private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.
	
	public GameObject defaultBullet;
	public float timeBullet;

	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
	}

	protected override void StartBase() {
		base.StartBase();
	}
	
	protected override void UpdateBase ()
	{
		if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.K)) {

			if (playerCtrl.dirVertical == 0) {
				if (playerCtrl.facingRight == true) {
					direction = 0;
				}
				else {
					direction = 180;
				}
			}
			else {
				if (playerCtrl.dirVertical > 0) {
					if (playerCtrl.dirHorizontal > 0) {
						direction = 45;
					}
					else if (playerCtrl.dirHorizontal < 0) {
						direction = 135;
					}
					else if (playerCtrl.dirHorizontal == 0) {
						direction = 90;
					}
				}
				else if (playerCtrl.dirVertical < 0) {
					if (playerCtrl.dirHorizontal > 0) {
						direction = 315;
					}
					else if (playerCtrl.dirHorizontal < 0) {
						direction = 225;
					}
					else if (playerCtrl.dirHorizontal == 0) {
						direction = 270;
					}
				}
			}
			
			isRapidFire = true;
		}
		else {
			isRapidFire = false;
		}

		base.UpdateBase();
	}

	protected override void Fire () {
		// ... set the animator Shoot trigger parameter and play the audioclip.
		anim.SetTrigger("Shoot");
		GetComponent<AudioSource>().Play();

		base.Fire();
	}

	public void CalBulletTime(float time) {
		if (timeBullet == 0) {
			timeBullet = time;
			StartCoroutine(RunBulletTime());
		} else {
			timeBullet += time;
		}
	}

	IEnumerator RunBulletTime() {
		if (timeBullet > 0) {

			timeBullet-=0.2f;
			BulletHUD.Instance.SetTime(timeBullet);
			yield return new WaitForSeconds(0.2f);
			StartCoroutine(RunBulletTime());
		}
		else {
			SetDefaultBullet();
		}
	}

	public void ResetBullet() {
		timeBullet = 0;
		BulletHUD.Instance.SetTime(timeBullet);
		SetDefaultBullet();
	}

	void SetDefaultBullet() {
		bullet = defaultBullet;
		this.SetGun(bullet.GetComponent<Bullet>().cooldown,
		            bullet.GetComponent<Bullet>().speed,
		            bullet.GetComponent<Bullet>().damage);
	}
}
