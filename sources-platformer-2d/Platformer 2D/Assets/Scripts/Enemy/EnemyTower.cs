using UnityEngine;
using System.Collections;

public class EnemyTower : EnemyBaseClass {

	private EnemyGun gun;

	protected override void AwakeBase (){
		base.AwakeBase ();

		gun = this.transform.FindChild("gun").GetComponent<EnemyGun>();
		gun.SetRapidFire(true);
	}

	public override void FixedUpdateBase ()
	{
		base.FixedUpdateBase ();

	}

	public override void Hurt (int damage)
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
