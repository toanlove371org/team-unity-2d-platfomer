using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject explosion;		// Prefab of explosion effect.

	public float speed = 20f;
	public float damage = 1f;
	public float cooldown = 1f;		// in second
	public float lifeTime = 1f; 	// in second

	protected float direction;

	// Do not edit here
	void Start () {
		StartBase();
	}
	
	// Do not edit here
	void Update () {
		UpdateBase();
	}

	protected virtual void StartBase() {
		// Destroy the bullet after lifeTime seconds if it doesn't get destroyed before then.
		Destroy(gameObject, lifeTime);
	}

	protected virtual void UpdateBase() {

	}

	public void InitMove(float dir, float sp, float dam) {
		// Move the bullet
		SetMove(dir, sp, dam);

		// Create effect
		InitEffect();
	}

	void Move () {
		this.GetComponent<Rigidbody2D>().velocity =
			new Vector2(Mathf.Cos (Mathf.Deg2Rad * direction) * speed,
			            Mathf.Sin (Mathf.Deg2Rad * direction) * speed);
		this.transform.Rotate(Vector3.forward, direction + 180);
	}

	public virtual void InitEffect() {
		// create effect when this object is created
	}

	/// <summary>
	/// Set direction, speed, damage of bullet, then move it with
	/// Move() function
	/// </summary>
	/// <param name="dir">Dir. Direction of bullet</param>
	/// <param name="sp">Sp. Speed of bullet</param>
	/// <param name="dam">Dam. Damage of bullet</param>
	protected void SetMove(float dir, float sp, float dam) {
		direction = dir;
		speed = sp;
		damage = dam;
		Move();
	}


	protected void Explode () {
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
		// Destroy itself
		Destroy(this.gameObject);
	}
	
	
	void OnTriggerEnter2D (Collider2D col) {
		OnTriggerEnter2DBase(col);
	}

	protected virtual void OnTriggerEnter2DBase(Collider2D col) {
		//Overide this fuction
	}
}
