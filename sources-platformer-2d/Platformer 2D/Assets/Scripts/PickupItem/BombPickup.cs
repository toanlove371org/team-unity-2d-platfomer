using UnityEngine;
using System.Collections;

public class BombPickup : PickupItem
{
	protected override void PickupEffect (Collider2D other) {
		// Increase the number of bombs the player has.
		other.GetComponent<LayBombs>().bombCount++;
	}
}
