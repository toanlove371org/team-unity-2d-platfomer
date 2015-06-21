using UnityEngine;
using System.Collections;

public class BossUFO : EnemyBaseClass {

	GameObject player;
	Rigidbody2D rigid;

	protected override void AwakeBase (){
		base.AwakeBase ();

		hpDamage = 20;
		player = GameObject.FindGameObjectWithTag("Player");
		//rigid = this.GetComponent<Rigidbody2D>();
	}

	protected override void FixedUpdateBase (){
		base.FixedUpdateBase ();

		this.transform.position = Vector2.Lerp(this.transform.position,
		                                              new Vector2(player.transform.position.x, this.transform.position.y),
		                                              Time.deltaTime * 1.0f);
	}

	protected override void Death (){
		base.Death ();

		// Destroy
		Destroy(this.gameObject);
	}
}
