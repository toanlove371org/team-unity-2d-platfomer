using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject explosion;		// Prefab of explosion effect.

	public float speed = 0.5f;
	public float damage = 1f;

	protected float direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
