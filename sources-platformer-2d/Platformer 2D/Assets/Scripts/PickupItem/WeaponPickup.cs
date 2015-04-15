using UnityEngine;
using System.Collections;

public class WeaponPickup : PickupItem {

	public GameObject weapon;
	public Texture weaponIcon;
	
	protected override void PickupEffect (Collider2D other) {
		// Increase the number of bombs the player has.
		other.GetComponent<LayWeapons>().SetWeapon(weapon, 1, weaponIcon);
	}
}
