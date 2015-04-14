using UnityEngine;
using System.Collections;

public class LayWeapons : MonoBehaviour {

	public int number = 0;			// How many bombs the player has.
	public GameObject weapon;				// Prefab of the bomb.
	
	
	private GUITexture weaponHUD;			// Heads up display of whether the player has a bomb or not.
	
	
	void Awake ()
	{
		// Setting up the reference.
		weaponHUD = GameObject.Find("ui_bombHUD").GetComponent<GUITexture>();
	}
	
	
	void Update ()
	{
		// If the bomb laying button is pressed, the bomb hasn't been laid and there's a bomb to lay...
		if(Input.GetButtonDown("Fire2") && number > 0)
		{
			CreateWeapon();
		}
		
		// The bomb heads up display should be enabled if the player has bombs, other it should be disabled.
		weaponHUD.enabled = number > 0;
	}

	void CreateWeapon() {
		// Decrement the number of bombs.
		number--;

		// Instantiate the bomb prefab.
		Instantiate(weapon, transform.position, transform.rotation);
	}

	public void SetWeapon(GameObject wp, int numb) {
		if (weapon == wp) {
			number += numb;
		} else {
			weapon = wp;
			number = numb;
		}
	}
}
