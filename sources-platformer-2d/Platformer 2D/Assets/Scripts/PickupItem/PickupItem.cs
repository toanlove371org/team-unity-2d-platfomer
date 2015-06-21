using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour {

	public AudioClip pickupClip;		// Sound for when the bomb crate is picked up.
	
	
	private Animator anim;				// Reference to the animator component.
	private bool landed = false;		// Whether or not the crate has landed yet.
	
	private Transform parentObj;

	void Awake()
	{
		AwakeBase();
		parentObj = this.transform.parent;
	}

	protected virtual void AwakeBase() {
		// Setting up the reference.
		anim = transform.parent.gameObject.GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			// ... play the pickup sound effect.
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);
			
			// ... trigger effect
			PickupEffect(other);

			// Destroy the crate.
			//Destroy(transform.root.gameObject);
			//Destroy(this.gameObject);
			if(parentObj != null) {
				Destroy(parentObj.gameObject);
			} else {
				Destroy(this.gameObject);
			}
		}
		// Otherwise if the crate lands on the ground...
		else if(other.tag == "ground" && !landed)
		{
			// ... set the animator trigger parameter Land.
			anim.SetTrigger("Land");
			//transform.parent = null;
			this.transform.SetParent(parentObj.parent);
			Destroy(parentObj.gameObject);
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;		
		}
	}

	// When pickup item, trigger this effect
	protected virtual void PickupEffect (Collider2D other) {

	}
}
