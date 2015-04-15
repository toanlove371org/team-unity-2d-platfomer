using UnityEngine;
using System.Collections;

public class LayWeapons : MonoBehaviour {

	public int number = 0;			// How many bombs the player has.
	public GameObject weapon;				// Prefab of the bomb.
	
	
	private WeaponHUD weaponHUD;			// Heads up display of whether the player has a bomb or not.

	
	void Awake ()
	{
		// Setting up the reference.
		weaponHUD = GameObject.Find("ui_weaponHUD").GetComponent<WeaponHUD>();
	}
	
	
	void Update ()
	{
		// If the bomb laying button is pressed, the bomb hasn't been laid and there's a bomb to lay...
		if(Input.GetButtonDown("Fire2") && number > 0)
		{
			CreateWeapon();
		}

	}

	void CreateWeapon() {
		// Decrement the number of bombs.
		number--;

		// Instantiate the bomb prefab.
		Instantiate(weapon, transform.position, transform.rotation);

		// Update number weapon to WeaponHUD
		weaponHUD.SetNumber(number);
	}

	public void SetWeapon(GameObject wp, int numb, Texture icon) {
		if (weapon == wp) {
			number += numb;
		} else {
			weapon = wp;
			number = numb;
		}
		weaponHUD.SetIcon(icon);
		weaponHUD.SetNumber(number);
	}
}
