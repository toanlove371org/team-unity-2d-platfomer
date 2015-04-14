using UnityEngine;
using System.Collections;

public class RocketPickup : PickupItem {

	public GameObject weapon;

	protected override void PickupEffect (Collider2D other) {
		// Increase the number of bombs the player has.
		other.GetComponent<LayWeapons>().SetWeapon(weapon, 1);
	}
}
