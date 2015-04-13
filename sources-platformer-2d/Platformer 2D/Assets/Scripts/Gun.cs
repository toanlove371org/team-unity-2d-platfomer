using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public GameObject bullet; 
	public float speedGun = 1f;		// 
	public float cooldownGun = 1f; 	// 
	public float direction = 0f;	// in degree
	public float damageGun = 1f;	// 
	
	protected bool isRapidFire = false;
	private float cooldownTick = 0;
	private float FPS = 60f;
	private Bullet bulletScript;
	private float cooldown;

	// Do not edit here
	void Start () {
		StartBase();
	}
	
	// Do not edit here
	void Update () {
		UpdateBase();
	}

	// Write Start() function here
	protected virtual void StartBase() {
		bulletScript = bullet.GetComponent<Bullet>();

	}

	protected virtual void UpdateBase() {
		RapidFire();
		cooldown = cooldownGun * bulletScript.cooldown;
	}
	
	protected virtual void Fire () {
		GameObject bulletInstance
			= (GameObject)Instantiate(
				bullet, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
		bulletInstance.GetComponent<Bullet>().InitMove(
			direction, speedGun * bulletScript.speed, damageGun * bulletScript.damage);
	}
	
	public void SetRapidFire (bool fire) {
		isRapidFire = fire;
	}


	void RapidFire () {
		if (isRapidFire) {
			if (cooldownTick <= 0) {
				Fire();
				cooldownTick = cooldown;
			} else {
				cooldownTick -= (1f/FPS);
			}
		}
		else if (cooldownTick > 0) {
			cooldownTick -= (1f/FPS);
		}
	}
}
