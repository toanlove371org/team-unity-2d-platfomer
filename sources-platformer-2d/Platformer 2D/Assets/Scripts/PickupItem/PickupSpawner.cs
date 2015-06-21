using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour
{
	public GameObject[] pickups;				// Array of pickup prefabs with the bomb pickup first and health second.
	public float pickupDeliveryTime = 5f;		// Delay on delivery.
	public float dropRangeLeft;					// Smallest value of x in world coordinates the delivery can happen at.
	public float dropRangeRight;				// Largest value of x in world coordinates the delivery can happen at.
	public float highHealthThreshold = 6f;		// The health of the player, above which only bomb crates will be delivered.
	public float lowHealthThreshold = 3f;		// The health of the player, below which only health crates will be delivered.


	private PlayerHealth playerHealth;			// Reference to the PlayerHealth script.
	private Transform playerTransform;
	private float playerPosX;
	private float dropPosX;
	private Vector2 dropPos;


	#region Singleton
	private static PickupSpawner instance;
	private PickupSpawner() {}
	public static PickupSpawner Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType(typeof(PickupSpawner)) as  PickupSpawner;
			}
			return instance;
		}
	}
	#endregion

	void Awake ()
	{
		// Setting up the reference.
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}


	void Start ()
	{
		// Start the first delivery.
		StartCoroutine(DeliverPickup());
	}


	public IEnumerator DeliverPickup()
	{
		// Wait for the delivery delay.
		yield return new WaitForSeconds(pickupDeliveryTime);
		CreatePickupItem();
	}

	void CreatePickupItem() {
		// Create a random x coordinate for the delivery in the drop range.
		playerPosX = playerTransform.position.x;
		dropPosX = Random.Range(playerPosX - dropRangeLeft, playerPosX + dropRangeRight);
		
		// Create a position with the random x coordinate.
		dropPos = new Vector3(dropPosX, 15f);
		
		// If the player's health is above the high threshold...
		if(playerHealth.health >= highHealthThreshold) {

			//Instantiate(pickups[0], dropPos, Quaternion.identity);
		}
		// Otherwise if the player's health is below the low threshold...
		else if(playerHealth.health <= lowHealthThreshold) {
			// ... instantiate a health pickup at the drop position.
			Instantiate(pickups[0], dropPos, Quaternion.identity);
		}
		// Otherwise...
		else
		{
			// ... instantiate a random pickup at the drop position.
			int pickupIndex = Random.Range(0, pickups.Length);
			Instantiate(pickups[pickupIndex], dropPos, Quaternion.identity);
		}
	}

	public void SpawnItem(int itemIndex) {
		// Create a random x coordinate for the delivery in the drop range.
		playerPosX = playerTransform.position.x;
		dropPosX = Random.Range(playerPosX - dropRangeLeft, playerPosX + dropRangeRight);
		
		// Create a position with the random x coordinate.
		dropPos = new Vector3(dropPosX, 15f);

		// Create
		Instantiate(pickups[itemIndex], dropPos, Quaternion.identity);
	}

	public void SpawnItem(int itemIndex, Vector2 pos) {
		// Create a random x coordinate for the delivery in the drop range.
		playerPosX = pos.x;
		dropPosX = Random.Range(playerPosX - dropRangeLeft, playerPosX + dropRangeRight);
		
		// Create a position with the random x coordinate.
		dropPos = new Vector3(dropPosX, 15f);
		
		// Create
		Instantiate(pickups[itemIndex], dropPos, Quaternion.identity);
	}
}
