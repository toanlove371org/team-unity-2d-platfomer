﻿using UnityEngine;
using System.Collections;

public class EnemyBomber : EnemyBaseClass {
	
	public float moveSpeed = 2f;		// The speed the enemy moves at.
	public float deathSpinMin = -100f;			// A value to give the minimum amount of Torque when dying
	public float deathSpinMax = 100f;			// A value to give the maximum amount of Torque when dying
	public bool moveLeft = true;

	protected Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.
	[HideInInspector]
	public bool isFacingRight = true;
	
	protected override void AwakeBase ()
	{
		base.AwakeBase ();
		frontCheck = transform.Find("frontCheck").transform;
	}
	
	void Start() {
		if (moveLeft) {
			Flip();
		}
	}

	protected override void FixedUpdateBase ()
	{
		// Create an array of all the colliders in front of the enemy.
		Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);
		
		// Check each of the colliders.
		foreach(Collider2D c in frontHits)
		{
			// If any of the colliders is an Obstacle...
			if(c.tag == "Obstacle" || c.tag == "ChangeDirection")
			{
				// ... Flip the enemy and stop checking the other colliders.
				Flip ();
				break;
			}
		}
		
		// Set the enemy's velocity to moveSpeed in the x direction.
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);	
		
		
		base.FixedUpdateBase ();
	}

	protected override void DamagedEffect() {
		base.DamagedEffect();
		if (this.transform.FindChild("gun")) {
			this.transform.FindChild("gun").gameObject.SetActive(false);
		}
	}
	
	protected override void Death ()
	{
		base.Death ();
		// Allow the enemy to rotate and spin it by adding a torque.
		this.gameObject.GetComponent<Rigidbody2D>().fixedAngle = false;
		this.gameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(deathSpinMin,deathSpinMax));
		this.gameObject.GetComponent<Rigidbody2D>().mass = 1;
		this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
		if (this.transform.FindChild("gun")) {
			this.transform.FindChild("gun").gameObject.SetActive(false);
		}
		Destroy(this.gameObject, 3f);
	}
	
	public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
		isFacingRight = !isFacingRight;
	}
}
