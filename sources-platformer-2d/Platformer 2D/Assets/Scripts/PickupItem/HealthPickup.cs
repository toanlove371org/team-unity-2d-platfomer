using UnityEngine;
using System.Collections;

public class HealthPickup : PickupItem
{
	public float healthBonus;				// How much health the crate gives the player.


	private PickupSpawner pickupSpawner;	// Reference to the pickup spawner.


	protected override void AwakeBase ()
	{
		// Setting up the references.
		pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
		base.AwakeBase();
	}

	protected override void PickupEffect (Collider2D other) {
		// Get a reference to the player health script.
		PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

		// Increasse the player's health by the health bonus but clamp it at 100.
		playerHealth.health += healthBonus;
		playerHealth.health = Mathf.Clamp(playerHealth.health, 0f, 10f);

		// Update the health bar.
		playerHealth.UpdateHealthBar();

		// Trigger a new delivery.
		pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());
	}
}
