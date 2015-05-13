using UnityEngine;
using System.Collections;

public class EnemyTower : EnemyBaseClass {

	protected override void AwakeBase (){
		base.AwakeBase ();

	}
	
	
	public override void Hurt (float damage)
	{
		base.Hurt (damage);
	}
	
	protected override void Death ()
	{
		base.Death ();
		Rigidbody2D[] rigs = GetComponents<Rigidbody2D>();
		foreach(Rigidbody2D r in rigs)
		{
			r.fixedAngle = false;
			r.isKinematic = false;
		}
	}
}
