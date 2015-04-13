using UnityEngine;
using System.Collections;

public class GunPlayer : Gun {

	private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.
	

	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
	}
	
	
	protected override void UpdateBase ()
	{
		if(Input.GetButtonDown("Fire1")) {

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
}
